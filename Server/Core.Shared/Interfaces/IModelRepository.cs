using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Shared.Context;
using Core.Shared.Entities;
using Core.Shared.Helpers.Exceptions;
using Core.Shared.Models.DTOs;
using Core.Shared.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Core.Shared.Interfaces
{
    public interface IModelRepository<TSource> where TSource : BaseModel<TSource>
    {
        // ======================================= //
        Task<TSource> UpdateModel<TRequest>(TRequest model) where TRequest : BaseDTO<TRequest>;
        Task<TSource> CreateModel<TRequest>(TRequest model) where TRequest : BaseDTO<TRequest>;
        Task<TSource> SearchModel(int id);
        Task<ICollection<TSource>> SearchModels();
        Task DeleteModel(int id);
        // ======================================= //
    }
    public class ModelRepository<TSource> : IModelRepository<TSource> where TSource : BaseModel<TSource>
    {
        // ======================================= //
        private readonly ApplicationData _context;
        public ModelRepository(ApplicationData context) => this._context = context;
        // ======================================= //
        /* Complete generic context operations */
        // ======================================= //
        public virtual async Task<ICollection<TSource>> SearchModels() => await _context.Set<TSource>().ToListAsync();
        public virtual async Task<TSource> SearchModel(int id) =>
        await this.Process(callback: async() =>
            await _context.Set<TSource>().FindAsync(id));
        public virtual async Task DeleteModel(int id) =>
        await this.Process(callback: async() =>
            await _context.Set<TSource>().FindAsync(id));
        public virtual async Task<TSource> CreateModel<TRequest>(TRequest model) where TRequest : BaseDTO<TRequest> =>
            await this.Process(callback: async() =>
                await _context.Set<TSource>().AddAsync(model.ToSource<TSource>()) as TSource);
        public virtual async Task<TSource> UpdateModel<TRequest>(TRequest model) where TRequest : BaseDTO<TRequest> =>
            await this.Process(callback: async() =>
            {
                _context.Update<TSource>(model.ToSource<TSource>());
                return await _context.Set<TSource>().FindAsync(model.Id);
            });
        // ======================================= //
        protected async Task<TSource> Process(Func<Task<TSource>> callback)
        {
            try
            {
                TSource result = await callback.Invoke();
                await _context.SaveChangesAsync();
                return result;
            }
            catch (ApiException failure)
            {
                /* TODO: Log the exception */
                throw failure;
            }
            catch (Exception exception)
            {
                throw new ApiException(HttpCode.ServerError, new KeyValuePair<string, IConvertible>(typeof(TSource).GetType().Name, exception.TargetSite.Name));
            }
        }
    }
}