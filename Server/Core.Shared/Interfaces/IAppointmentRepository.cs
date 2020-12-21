using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Shared.Context;
using Core.Shared.Helpers;
using Core.Shared.Models.Entities;
using Core.Shared.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Core.Shared.Interfaces
{
    public interface IAppointmentRepository : IModelRepository<AppointmentModel>
    {
        Task<Pagination<AppointmentModel>> SearchModels(SearchParams search);
    }
    public class AppointmentRepository : IAppointmentRepository
    {
        // ======================================= //
        private readonly ApplicationContext _context;
        // ======================================= //
        public AppointmentRepository(ApplicationContext context) => this._context = context;
        // ======================================= //
        public async Task<ICollection<AppointmentModel>> SearchModels()
        {
            return await _context.Set<AppointmentModel>()
                .Include(x => x.Member)
                .Include(x => x.Pooch)
                .ToListAsync();
        }
        public async Task<Pagination<AppointmentModel>> SearchModels(SearchParams search)
        {
            Func<AppointmentModel, bool> filter = (model) =>
            {
                if (search.Date != null)
                    return (DateTime) search.Date == model.Date;
                else if (search.MinDate != null && search.MaxDate != null)
                    return (DateTime) search.MinDate <= model.Date && (DateTime) search.MaxDate >= model.Date;
                else if (search.MinDate != null)
                    return (DateTime) search.MinDate <= model.Date;
                else if (search.MaxDate != null)
                    return (DateTime) search.MaxDate >= model.Date;
                else if (search.Id != -1)
                    return search.Id == model.Id;
                else if (search.IsActive != -1)
                    return model.IsActive = search.IsActive == 1;

                return false;
            };

            IQueryable<AppointmentModel> models = _context
                .Set<AppointmentModel>()
                .Where(x => filter(x));

            switch ((OrderLevel) search.OrderBy)
            {
                case OrderLevel.Ascending:
                    models.OrderBy(x => x.Date);
                    break;
                case OrderLevel.Descending:
                    models.OrderByDescending(x => x.Date);
                    break;
            }

            Pagination<AppointmentModel> pagination =
                new Pagination<AppointmentModel>(totalItems: models.Count(), currentPage: search.CurrentPage);

            models
                .Skip((search.CurrentPage - 1) * search.Results)
                .Take(search.Results)
                .Include(x => x.Member)
                .Include(x => x.Pooch);

            return pagination.Build(await models.ToListAsync());
        }
        public async Task<AppointmentModel> SearchModel(int id)
        {
            return await _context.Set<AppointmentModel>()
                .Include(x => x.Member)
                .Include(x => x.Pooch)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<AppointmentModel> CreateModel(AppointmentModel model)
        {
            var result = (await _context.Set<AppointmentModel>()
                .AddAsync(model)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<AppointmentModel> UpdateModel(AppointmentModel source)
        {
            var result = _context.Set<AppointmentModel>()
                .Update(source).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteModel(int id)
        {
            _context.Set<AppointmentModel>()
                .Remove(await _context.Set<AppointmentModel>()
                    .FindAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}