using System;
using AutoMapper;
using Core.Shared.Models.DTOs;
using Core.Shared.Models.Entities;
using Core.Shared.Models.Identity;

namespace Core.Shared.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, AccountDTO>()
                .ReverseMap();
            CreateMap<MemberModel, MemberDTO>()
                .ReverseMap();
            CreateMap<PoochModel, PoochDTO>()
                .ReverseMap();
            CreateMap<MemberModel, ProfileDTO>()
                .ReverseMap();
            CreateMap<PoochModel, ProfileDTO>()
                .ReverseMap();
            CreateMap<AppointmentModel, AppointmentDTO>()
                .ReverseMap();
        }
        public MappingProfiles(string profileName) : base(profileName) { }
        public MappingProfiles(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction) { }
    }
}