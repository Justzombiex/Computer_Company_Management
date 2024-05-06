﻿using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {

            CreateMap<CCM.Domain.Entities.Persons.PrivateClient, PrivateClientDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.CI, o => o.MapFrom(s => s.CI))
                .ForMember(t => t.Age, o => o.MapFrom(s => s.Age));

            CreateMap<PrivateClientDTO, CCM.Domain.Entities.Persons.PrivateClient>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.CI, o => o.MapFrom(s => s.CI))
                .ForMember(t => t.Age, o => o.MapFrom(s => s.Age));
        }

    }
}