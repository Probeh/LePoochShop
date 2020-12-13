using AutoMapper;
using Core.Shared.Interfaces;
using Core.Shared.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace Core.WebAPI.Controllers
{
    public class SchedulesController : BaseController<MemberModel>
    {
        // ======================================= //
        private readonly IConfiguration config;
        private readonly IModelRepository<MemberModel> models;
        private readonly IMapper mapper;
        // ======================================= //
        public SchedulesController(IConfiguration config, IModelRepository<MemberModel> models, IMapper mapper) : base(config, models, mapper)
        {
            this.config = config;
            this.models = models;
            this.mapper = mapper;
        }
        // ======================================= //
    }
}