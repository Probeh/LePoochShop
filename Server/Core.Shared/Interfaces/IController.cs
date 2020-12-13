using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Shared.Helpers;
using Core.Shared.Models.Entities;

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