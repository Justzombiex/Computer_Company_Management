using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class PhysicalLocationProfile : Profile
    {
        public PhysicalLocationProfile()
        {

            CreateMap<CCM.Domain.Entities.Persons.PhysicalLocation, PhysicalLocationDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Country, o => o.MapFrom(s => s.Country))
                .ForMember(t => t.City, o => o.MapFrom(s => s.City))
                .ForMember(t => t.Address, o => o.MapFrom(s => s.Address));


            CreateMap<PhysicalLocationDTO, CCM.Domain.Entities.Persons.PhysicalLocation>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Country, o => o.MapFrom(s => s.Country))
                .ForMember(t => t.City, o => o.MapFrom(s => s.City))
                .ForMember(t => t.Address, o => o.MapFrom(s => s.Address));
        }

    }
}