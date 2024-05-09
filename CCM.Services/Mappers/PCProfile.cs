using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class PCProfile : Profile
    {
        public PCProfile()
        {

            CreateMap<CCM.Domain.Entities.Computers.PC, PCDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Harddrive, o => o.MapFrom(s => s.HardDrive))
                .ForMember(t => t.Ram, o => o.MapFrom(s => s.RAM))
                .ForMember(t => t.Microprocesor, o => o.MapFrom(s => s.Microprocesors))
                .ForMember(t => t.Motherboard, o => o.MapFrom(s => s.MotherBoard));

            CreateMap<PCDTO, CCM.Domain.Entities.Computers.PC>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.HardDrive, o => o.MapFrom(s => s.Harddrive))
                .ForMember(t => t.RAM, o => o.MapFrom(s => s.Ram))
                .ForMember(t => t.Microprocesors, o => o.MapFrom(s => s.Microprocesor))
                .ForMember(t => t.MotherBoard, o => o.MapFrom(s => s.Motherboard));
        }
    }
}
