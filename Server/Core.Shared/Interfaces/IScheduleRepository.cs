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
    public interface IScheduleRepository : IModelRepository<ScheduleModel>
    {
        Task<ICollection<ScheduleModel>> SearchModels(SearchParams search);
    }
    public class ScheduleRepository : IScheduleRepository
    {
        // ======================================= //
        private readonly ApplicationData _context;
        // ======================================= //
        public ScheduleRepository(ApplicationData context)
        {
            this._context = context;
        }
        // ======================================= //

        public async Task<ScheduleModel> CreateModel(ScheduleModel model)
        {
            var result = (await _context.Set<ScheduleModel>().AddAsync(model)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteModel(int id)
        {
            _context.Set<ScheduleModel>()
                .Remove((await _context.Set<ScheduleModel>()
                    .FindAsync(id)));
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<ScheduleModel>> SearchModels(SearchParams search)
        {
            Func<ScheduleModel, bool> filter = (model) =>
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

            return await _context.Set<ScheduleModel>()
                .Where(x => filter(x))
                .ToListAsync();
        }
        public async Task<ScheduleModel> SearchModel(int id)
        {
            return await _context.Set<ScheduleModel>()
                .FindAsync(id);
        }
        public async Task<ICollection<ScheduleModel>> SearchModels()
        {
            return await _context.Set<ScheduleModel>()
                .ToListAsync();
        }
        public async Task<ScheduleModel> UpdateModel(ScheduleModel source)
        {
            var result = _context.Set<ScheduleModel>()
                .Update(source).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}