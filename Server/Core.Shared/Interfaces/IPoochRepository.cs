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
    public interface IPoochRepository : IModelRepository<PoochModel>
    {
        Task<Pagination<PoochModel>> SearchModels(SearchParams search);
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
        public async Task<ICollection<PoochModel>> SearchModels()
        {
            return await _context.Set<PoochModel>()
                .Include(x => x.Appointments)
                .ToListAsync();
        }
        public async Task<Pagination<PoochModel>> SearchModels(SearchParams search)
        {
            Func<PoochModel, bool> filter = (model) =>
            {
                if (search.Date != null)
                    return (DateTime) search.Date == model.Created;
                else if (search.MinDate != null && search.MaxDate != null)
                    return (DateTime) search.MinDate <= model.Created && (DateTime) search.MaxDate >= model.Created;
                else if (search.MinDate != null)
                    return (DateTime) search.MinDate <= model.Created;
                else if (search.MaxDate != null)
                    return (DateTime) search.MaxDate >= model.Created;
                else if (search.Id != -1)
                    return search.Id == model.Id;
                else if (search.IsActive != -1)
                    return model.IsActive = search.IsActive == 1;

                return false;
            };

            IQueryable<PoochModel> models = _context
                .Set<PoochModel>()
                .Where(x => filter(x));

            switch ((OrderLevel) search.OrderBy)
            {
                case OrderLevel.Ascending:
                    models.OrderBy(x => x.Created);
                    break;
                case OrderLevel.Descending:
                    models.OrderByDescending(x => x.Created);
                    break;
            }

            Pagination<PoochModel> Pagination =
                new Pagination<PoochModel>(totalItems: models.Count(), currentPage: search.CurrentPage);

            models
                .Skip((search.CurrentPage - 1) * search.Results)
                .Take(search.Results)
                .Include(x => x.Appointments);

            return Pagination.Build(await models.ToListAsync());
        }
        public async Task<PoochModel> SearchModel(int id)
        {
            return await _context.Set<PoochModel>()
                .Include(x => x.Appointments)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<PoochModel> CreateModel(PoochModel model)
        {
            var result = (await _context.Set<PoochModel>()
                .AddAsync(model)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<PoochModel> UpdateModel(PoochModel source)
        {
            var result = _context.Set<PoochModel>()
                .Update(source).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteModel(int id)
        {
            _context.Set<PoochModel>()
                .Remove(await _context.Set<PoochModel>()
                    .FindAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}