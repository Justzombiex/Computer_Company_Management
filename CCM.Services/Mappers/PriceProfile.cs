using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {

            CreateMap<CCM.Domain.Entities.Common.Price, PriceDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.MoneyType, o => o.MapFrom(s => s.Currency))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value));

            CreateMap<PriceDTO, CCM.Domain.Entities.Common.Price>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Currency, o => o.MapFrom(s => s.MoneyType))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value));

        }

    }
}
