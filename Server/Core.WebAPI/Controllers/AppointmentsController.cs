using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Shared.Helpers;
using Core.Shared.Interfaces;
using Core.Shared.Models.DTOs;
using Core.Shared.Models.Entities;
using Core.Shared.Models.Enums;
using Core.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;

namespace Core.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        // ======================================= //
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _repo;
        // ======================================= //
        public AppointmentsController(IConfiguration config, IAppointmentRepository repo, IMapper mapper)
        {
            this._config = config;
            this._repo = repo;
            this._mapper = mapper;
        }
        // ======================================= //
        [HttpGet]
        public async Task<IActionResult> SearchModels()
        {
            try
            {
                var source = await _repo.SearchModels();
                if (source == null || source?.Count == 0)
                    return NoContent();

                return Ok(_mapper.Map<ICollection<AppointmentDTO>>(source));
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpCode.ServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SearchModel([FromRoute] int id)
        {
            try
            {
                var source = await _repo.SearchModel(id);
                if (source == null)
                    return NoContent();

                return Ok(_mapper.Map<AppointmentDTO>(source));
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpCode.ServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchModels([FromQuery] SearchParams search)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ModelStateException();

                Pagination<AppointmentModel> source = await _repo.SearchModels(search);
                if (source == null || source?.Results?.Count == 0)
                    return NoContent();

                Response.SetPagination(source);
                return Ok(_mapper.Map<ICollection<AppointmentDTO>>(source.Results));
            }
            catch (ModelStateException)
            {
                return BadRequest(ModelState as IEnumerable<KeyValuePair<string, ModelStateEntry>>);
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpCode.ServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> CreateModel([FromBody] AppointmentDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ModelStateException();

                var source = await _repo.CreateModel(_mapper.Map<AppointmentModel>(model));
                return Ok(_mapper.Map<AppointmentDTO>(source));
            }
            catch (ModelStateException)
            {
                return BadRequest(ModelState as IEnumerable<KeyValuePair<string, ModelStateEntry>>);
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpCode.ServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateModel([FromBody] AppointmentDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ModelStateException();

                if (int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) != model.MemberId)
                    return Unauthorized();

                var source = await _repo.UpdateModel(_mapper.Map<AppointmentModel>(model));
                return Ok(_mapper.Map<ICollection<AppointmentDTO>>(source));
            }
            catch (ModelStateException)
            {
                return BadRequest(ModelState as IEnumerable<KeyValuePair<string, ModelStateEntry>>);
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpCode.ServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModel([FromRoute] int id)
        {
            try
            {
                await _repo.DeleteModel(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpCode.ServerError, ex.Message);
            }
        }
        // ======================================= //
    }
}