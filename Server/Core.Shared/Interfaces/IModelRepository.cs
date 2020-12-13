using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Shared.Context;
using Core.Shared.Models.Entities;

namespace Core.Shared.Interfaces
{
    public interface IModelRepository<TSource> where TSource : BaseModel<TSource>
    {
        // ======================================= //
        Task<TSource> UpdateModel(TSource source);
        Task<TSource> CreateModel(TSource model);
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
        public virtual async Task<TSource> CreateModel(TSource model) =>
        await this.Process(callback: async() =>
            (await _context.Set<TSource>().AddAsync(model)).Entity);
        public virtual async Task<TSource> UpdateModel(TSource source) =>
        await this.Process(callback: async() =>
            await _context.Set<TSource>().FindAsync(source.Id));
        // ======================================= //
        protected async Task<TSource> Process(Func<Task<TSource>> callback)
        {
            try
            {
                TSource result = await callback.Invoke();
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception failure)
            {
                /* TODO: Log the exception */
                throw failure;
            }
        }
    }
}