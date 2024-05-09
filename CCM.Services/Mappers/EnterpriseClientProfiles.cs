using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class EnterpriseClientProfile : Profile
    {
        public EnterpriseClientProfile()
        {

            CreateMap<CCM.Domain.Entities.Persons.EnterpriseClient, EnterpriseClientDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.Location, o => o.MapFrom(s => s.Location));

            CreateMap<EnterpriseClientDTO, CCM.Domain.Entities.Persons.EnterpriseClient>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.Location, o => o.MapFrom(s => s.Location));
        }

    }
}