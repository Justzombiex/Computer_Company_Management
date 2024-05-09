using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {

            CreateMap<CCM.Domain.Entities.Companies.Company, CompanyDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name));
                

            CreateMap<CompanyDTO, CCM.Domain.Entities.Companies.Company>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name));

        }
}