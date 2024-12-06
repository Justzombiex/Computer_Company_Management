using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class MotherboardProfile : Profile
    {
        public MotherboardProfile()
        {

            CreateMap<CCM.Domain.Entities.Components.MotherBoard, MotherBoardDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.Model, o => o.MapFrom(s => s.Model))
                .ForMember(t => t.ConnectionType, o => o.MapFrom(s => s.ConnectionType));

            CreateMap<MotherBoardDTO, CCM.Domain.Entities.Components.MotherBoard>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.Model, o => o.MapFrom(s => s.Model))
                .ForMember(t => t.ConnectionType, o => o.MapFrom(s => s.ConnectionType));
        }
    }
}
