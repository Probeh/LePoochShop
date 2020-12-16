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
    public interface IAppointmentRepository : IModelRepository<AppointmentModel>
    {
        Task<ICollection<AppointmentModel>> SearchModels(SearchParams search);
    }
    public class AppointmentRepository : IAppointmentRepository
    {
        // ======================================= //
        private readonly ApplicationData _context;
        // ======================================= //
        public AppointmentRepository(ApplicationData context) => this._context = context;
        // ======================================= //

        public async Task<AppointmentModel> CreateModel(AppointmentModel model)
        {
            var result = (await _context.Set<AppointmentModel>().AddAsync(model)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteModel(int id)
        {
            _context.Set<AppointmentModel>()
                .Remove((await _context.Set<AppointmentModel>()
                    .FindAsync(id)));
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<AppointmentModel>> SearchModels(SearchParams search)
        {
            Func<AppointmentModel, bool> filter = (model) =>
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

            return await _context.Set<AppointmentModel>()
                .Where(x => filter(x))
                .Include(x => x.Owner)
                .Include(x => x.Pooch)
                .ToListAsync();
        }
        public async Task<AppointmentModel> SearchModel(int id)
        {
            return await _context.Set<AppointmentModel>()
                .FindAsync(id);
        }
        public async Task<ICollection<AppointmentModel>> SearchModels()
        {
            return await _context.Set<AppointmentModel>()
                .ToListAsync();
        }
        public async Task<AppointmentModel> UpdateModel(AppointmentModel source)
        {
            var result = _context.Set<AppointmentModel>()
                .Update(source).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}