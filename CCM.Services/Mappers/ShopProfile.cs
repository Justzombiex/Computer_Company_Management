using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {

            CreateMap<CCM.Domain.Entities.Shops.Shop, ShopDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Location, o => o.MapFrom(s => s.Locaton));


            CreateMap<ShopDTO, CCM.Domain.Entities.Shops.Shop>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Location, o => o.MapFrom(s => s.Locaton));
        }

    }
}