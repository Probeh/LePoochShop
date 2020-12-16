using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Shared.Models.Entities;

namespace Core.Shared.Interfaces
{
    public interface IModelRepository<TSource> where TSource : BaseModel
    {
        // ======================================= //
        Task<ICollection<TSource>> SearchModels();
        Task<TSource> SearchModel(int id);
        Task<TSource> CreateModel(TSource model);
        Task<TSource> UpdateModel(TSource source);
        Task DeleteModel(int id);
        // ======================================= //
    }
}