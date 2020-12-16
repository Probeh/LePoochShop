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
    public interface IMemberRepository : IModelRepository<MemberModel>
    {
        Task<ICollection<MemberModel>> SearchModels(SearchParams search);
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

        public async Task<MemberModel> CreateModel(MemberModel model)
        {
            var result = (await _context.Set<MemberModel>().AddAsync(model)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteModel(int id)
        {
            _context.Set<MemberModel>()
                .Remove((await _context.Set<MemberModel>()
                    .FindAsync(id)));
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<MemberModel>> SearchModels(SearchParams search)
        {
            Func<MemberModel, bool> filter = (model) =>
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

            return await _context.Set<MemberModel>()
                .Where(x => filter(x))
                .Include(x => x.Appointments)
                .Include(x => x.Pooch)
                .ToListAsync();
        }
        public async Task<MemberModel> SearchModel(int id)
        {
            return await _context.Set<MemberModel>()
                .FindAsync(id);
        }
        public async Task<ICollection<MemberModel>> SearchModels()
        {
            return await _context.Set<MemberModel>()
                .ToListAsync();
        }
        public async Task<MemberModel> UpdateModel(MemberModel source)
        {
            var result = _context.Set<MemberModel>()
                .Update(source).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}