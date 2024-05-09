using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class RAMProfile : Profile
    {
        public RAMProfile()
        {

            CreateMap<CCM.Domain.Entities.Components.RAM, RAMDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.MemorySize, o => o.MapFrom(s => s.MemorySize))
                .ForMember(t => t.MemoryType, o => o.MapFrom(s => s.MemoryType));


            CreateMap<RAMDTO, CCM.Domain.Entities.Components.RAM>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.MemorySize, o => o.MapFrom(s => s.MemorySize))
                .ForMember(t => t.MemoryType, o => o.MapFrom(s => s.MemoryType));
        }

    }
}
