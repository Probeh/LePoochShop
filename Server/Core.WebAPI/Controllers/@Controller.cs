using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Shared.Entities;
using Core.Shared.Helpers;
using Core.Shared.Helpers.Exceptions;
using Core.Shared.Interfaces;
using Core.Shared.Models.DTOs;
using Core.Shared.Models.Enums;
using Core.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Core.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public abstract class BaseController<TSource> : ControllerBase where TSource : BaseModel<TSource>
    {
        // ======================================= //
        private readonly Function<ClaimsPrincipal, int> claimUserId = (ClaimsPrincipal user) => int.Parse(user?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        private readonly IConfiguration _config;
        // ======================================= //
        private readonly IModelRepository<TSource> _repo;
        // ======================================= //
        protected BaseController(IConfiguration config, IModelRepository<TSource> repo)
        {
            this._config = config;
            this._repo = repo;
        }
        // ======================================= //
        /* Generic functional Http CRUD actions */
        // ======================================= //
        [HttpPut] /* CREATE a new model */
        public virtual Task<IActionResult> CreateModel<TRequest>([FromBody] TRequest model)
        {
            return null;
        }

        [HttpGet("{id}")] /* GET model by id */
        public virtual Task<IActionResult> SearchModel<TRequest>([FromRoute] int id)
        {
            return null;
        }

        [HttpGet] /* GET model/s via search query */
        public virtual async Task<IActionResult> SearchModels<TRequest>()
        {
            ICollection<TSource> items = await _repo.SearchModels();
            Response.SetPagination<TSource>(new Pagination<TSource>()?.Build(items));
            Response.GenerateToken(_config);
            return Ok(items);
        }

        [HttpPost] /* UPDATE existing resource */
        public virtual async Task<IActionResult> UpdateModel<TRequest>([FromBody] TRequest model) where TRequest : BaseDTO<TRequest>
        {
            if (model.Id != claimUserId.Invoke(User))
                return Unauthorized(HttpCode.MissingRoles);

            return await this.Process<TSource>(async() => await _repo.UpdateModel<TRequest>(model));;
        }

        [HttpDelete("{id}")] /* DELETE model by id */
        public virtual async Task<IActionResult> DeleteModel([FromRoute] int id)
        {
            Function<TSource, IActionResult> unauthorized =
                (source) => Unauthorized(HttpCode.MissingRoles);

            return await this.Process<TSource>(callback: async() =>
            {
                TSource model = await _repo.SearchModel(id);

                if (model.CreatorId == id)
                    await _repo.DeleteModel(id);

                else unauthorized.Invoke(model);
                return model;
            });
        }

        /* Encapsulated repetitive logic */
        protected async Task<IActionResult> Process<T>(Func<Task<T>> callback)
        {
            try
            {
                T results = await callback.Invoke();

                if (ModelState.IsValid)
                    return BadRequest(ModelState);

                if (results == null)
                    return NoContent();

                Response.GenerateToken(_config);
                return Ok(results);
            }
            catch (ApiException failure)
            {
                return StatusCode((int) failure.ErrorCode, failure.Parameters);
            }
            catch (Exception exception)
            {
                return StatusCode((int) HttpCode.ServerError, exception.Message);
            }
        }
    }
}