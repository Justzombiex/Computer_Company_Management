using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class BuyOrderProfile : Profile
    {
        public BuyOrderProfile()
        {

            CreateMap<CCM.Domain.Entities.Orders.BuyOrder, BuyOrderDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.EnterpriseClient, o => o.MapFrom(s => s.EnterpriseClient))
                .ForMember(t => t.PC, o => o.MapFrom(s => s.PC))
                .ForMember(t => t.Units, o => o.MapFrom(s => s.Units));



            CreateMap<BuyOrderDTO, CCM.Domain.Entities.Orders.BuyOrder>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.EnterpriseClient, o => o.MapFrom(s => s.EnterpriseClient))
                .ForMember(t => t.PC, o => o.MapFrom(s => s.PC))
                .ForMember(t => t.Units, o => o.MapFrom(s => s.Units));
        }

    }
}