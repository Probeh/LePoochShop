using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Core.Shared.Interfaces;

namespace Core.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PoochesController : ControllerBase
    {
        // ======================================= //
        private readonly IConfiguration _config;
        private readonly IPoochRepository _repo;
        private readonly IMapper _mapper;
        // ======================================= //
        public PoochesController(IConfiguration config, IPoochRepository repo, IMapper mapper)
        {
            this._config = config;
            this._repo = repo;
            this._mapper = mapper;
        }
        // ======================================= //
    }
}