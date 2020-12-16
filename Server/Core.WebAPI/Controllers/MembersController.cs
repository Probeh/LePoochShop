using AutoMapper;
using Core.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Core.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        // ======================================= //
        private readonly IConfiguration _config;
        private readonly IMemberRepository _repo;
        private readonly IMapper _mapper;
        // ======================================= //
        public MembersController(IConfiguration config, IMemberRepository repo, IMapper mapper)
        {
            this._config = config;
            this._repo = repo;
            this._mapper = mapper;
        }
        // ======================================= //
    }
}