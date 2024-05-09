using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class MicroprocesorProfile : Profile
    {
        public MicroprocesorProfile()
        {

            CreateMap<CCM.Domain.Entities.Components.Microprocesor, MicroprocesorDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.Model, o => o.MapFrom(s => s.Model))
                .ForMember(t => t.ConnectionType, o => o.MapFrom(s => s.ConnectionType))
                .ForMember(t => t.ProcessorSpeed, o => o.MapFrom(s => s.ProcessorSpeed));

            CreateMap<MicroprocesorDTO, CCM.Domain.Entities.Components.Microprocesor>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.Model, o => o.MapFrom(s => s.Model))
                .ForMember(t => t.ConnectionType, o => o.MapFrom(s => s.ConnectionType))
                .ForMember(t => t.ProcessorSpeed, o => o.MapFrom(s => s.ProcessorSpeed));
        }
    }
}
