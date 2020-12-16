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
    public interface IMemberRepository : IModelRepository<MemberModel>
    {
        Task<Pagination<MemberModel>> SearchModels(SearchParams search);
    }
    public class MemberRepository : IMemberRepository
    {
        // ======================================= //
        private readonly ApplicationData _context;
        // ======================================= //
        public MemberRepository(ApplicationData context)
        {
            this._context = context;
        }
        // ======================================= //
        public async Task<ICollection<MemberModel>> SearchModels()
        {
            return await _context.Set<MemberModel>()
                .Include(x => x.Pooch)
                .Include(x => x.Appointments)
                .ToListAsync();
        }
        public async Task<Pagination<MemberModel>> SearchModels(SearchParams search)
        {
            Func<MemberModel, bool> filter = (model) =>
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

            IQueryable<MemberModel> models = _context
                .Set<MemberModel>()
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

            Pagination<MemberModel> pagination =
                new Pagination<MemberModel>(totalItems: models.Count(), currentPage: search.CurrentPage);

            models
                .Skip((search.CurrentPage - 1) * search.Results)
                .Take(search.Results)
                .Include(x => x.Pooch)
                .Include(x => x.Appointments);

            return pagination.Build(await models.ToListAsync());
        }
        public async Task<MemberModel> SearchModel(int id)
        {
            return await _context.Set<MemberModel>()
                .Include(x => x.Pooch)
                .Include(x => x.Appointments)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<MemberModel> CreateModel(MemberModel model)
        {
            var result = (await _context.Set<MemberModel>()
                .AddAsync(model)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<MemberModel> UpdateModel(MemberModel source)
        {
            var result = _context.Set<MemberModel>()
                .Update(source).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteModel(int id)
        {
            _context.Set<MemberModel>()
                .Remove(await _context.Set<MemberModel>()
                    .FindAsync(id));
            await _context.SaveChangesAsync();
        }

    }
}