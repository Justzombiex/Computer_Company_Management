using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class HardDriveProfile : Profile
    {
        public HardDriveProfile()
        {

            CreateMap<CCM.Domain.Entities.Components.HardDrive, HardDriveDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.Model, o => o.MapFrom(s => s.Model))
                .ForMember(t => t.ConnectionHardDrivesType, o => o.MapFrom(s => s.ConnectionHardDriveType))
                .ForMember(t => t.Storage, o => o.MapFrom(s => s.Storage));

            CreateMap<HardDriveDTO, CCM.Domain.Entities.Components.HardDrive>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.Model, o => o.MapFrom(s => s.Model))
                .ForMember(t => t.ConnectionHardDriveType, o => o.MapFrom(s => s.ConnectionHardDrivesType))
                .ForMember(t => t.Storage, o => o.MapFrom(s => s.Storage));
        }

    }
}