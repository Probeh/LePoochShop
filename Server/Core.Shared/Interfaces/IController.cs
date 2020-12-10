using System.Threading.Tasks;
using Core.Shared.Entities;
using Core.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Core.Shared.Interfaces
{
    public interface IController<TSource> where TSource : BaseModel<TSource>
    {
        // ======================================= //
        Task<IActionResult> CreateModel<TRequest>([FromBody] TRequest model);
        Task<IActionResult> SearchModels<TRequest>([FromQuery] SearchParams query);
        Task<IActionResult> SearchModel<TRequest>([FromRoute] int id);
        Task<IActionResult> UpdateModel<TRequest>([FromBody] TRequest model);
        Task<IActionResult> DeleteModel<TRequest>([FromRoute] int id);
        // ======================================= //
    }
}