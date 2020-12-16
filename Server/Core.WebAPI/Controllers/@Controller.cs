using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Core.Shared.Helpers;
using Core.Shared.Interfaces;
using Core.Shared.Models.Entities;
using Core.WebAPI.Extensions;

namespace Core.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public abstract class BaseController<TSource> : ControllerBase where TSource : BaseModel<TSource>
    {
        // ======================================= //
        private readonly IConfiguration _config;
        private readonly IModelRepository<TSource> _repo;
        private readonly IMapper _mapper;
        // ======================================= //
        protected BaseController(IConfiguration config, IModelRepository<TSource> repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._config = config;
            this._repo = repo;
        }
        // ======================================= //
        /* Generic functional Http CRUD actions */
        // ======================================= //
        [HttpPut] /* CREATE a new model */
        protected virtual async Task<IActionResult> CreateModel<TRequest, TResponse>([FromBody] TRequest model) =>
        Ok(_mapper.Map<TResponse>(await _repo.CreateModel(_mapper.Map<TSource>(model))));
        [HttpPost] /* UPDATE existing resource */
        protected virtual async Task<IActionResult> UpdateModel<TRequest>([FromBody] TRequest model) =>
        Ok(_mapper.Map<TRequest>(await _repo.UpdateModel(_mapper.Map<TSource>(model))));
        [HttpGet("{id}")] /* GET model by id */
        protected virtual async Task<IActionResult> SearchModel<TResponse>([FromRoute] int id) =>
        Ok(_mapper.Map<TResponse>(await _repo.SearchModel(id)));
        [HttpGet] /* GET model/s via search query */
        protected virtual async Task<IActionResult> SearchModels<TResponse>()
        {
            ICollection<TSource> items = await _repo.SearchModels();
            Response.SetPagination(new Pagination<TSource>()?.Build(items));
            return Ok(_mapper.Map<ICollection<TResponse>>(items));
        }

        [HttpDelete("{id}")] /* DELETE model by id */
        protected virtual async Task<IActionResult> DeleteModel<TRequest>([FromRoute] int id)
        {
            var model = await _repo.SearchModel(id);
            return Ok(_mapper.Map<TRequest>(model));
        }
    }
}