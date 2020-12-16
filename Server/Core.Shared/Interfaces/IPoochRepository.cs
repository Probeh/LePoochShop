using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Shared.Context;
using Core.Shared.Helpers;
using Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Shared.Interfaces
{
    public interface IPoochRepository : IModelRepository<PoochModel>
    {
        Task<ICollection<PoochModel>> SearchModels(SearchParams search);
    }
    public class PoochRepository : IPoochRepository
    {
        // ======================================= //
        private readonly ApplicationData _context;
        // ======================================= //
        public PoochRepository(ApplicationData context)
        {
            this._context = context;
        }
        // ======================================= //

        public async Task<PoochModel> CreateModel(PoochModel model)
        {
            var result = (await _context.Set<PoochModel>().AddAsync(model)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteModel(int id)
        {
            _context.Set<PoochModel>()
                .Remove((await _context.Set<PoochModel>()
                    .FindAsync(id)));
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<PoochModel>> SearchModels(SearchParams search)
        {
            Func<PoochModel, bool> filter = (model) =>
            {
                if (search.Date != null && (DateTime) search.Date == model.Created)
                    return true;
                if (search.Id > 0 && search.Id == model.Id)
                    return true;
                if (search.IsActive != -1)
                    return search.IsActive == 1;
                if (search.MinDate == null && search.MaxDate != null && (DateTime) search.MaxDate >= model.Created)
                    return true;
                if (search.MinDate != null && (DateTime) search.MinDate <= model.Created)
                    if (search.MaxDate == null || search.MaxDate != null && (DateTime) search.MaxDate >= model.Created)
                        return true;
                return false;
            };

            return await _context.Set<PoochModel>()
                .Where(x => filter(x))
                .ToListAsync();
        }
        public async Task<PoochModel> SearchModel(int id)
        {
            return await _context.Set<PoochModel>()
                .FindAsync(id);
        }
        public async Task<ICollection<PoochModel>> SearchModels()
        {
            return await _context.Set<PoochModel>()
                .ToListAsync();
        }
        public async Task<PoochModel> UpdateModel(PoochModel source)
        {
            var result = _context.Set<PoochModel>()
                .Update(source).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}