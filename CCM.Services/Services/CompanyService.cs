using AutoMapper;
using CCM.DataAccess.Abstract.Companies;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services { 
    public class CompanyService : Company.CompanyBase
    {
        private ICompaniesRepository _companiesRepository;
        private IMapper _mapper;

        public CompanyService(ICompaniesRepository companiesRepository, IMapper mapper)
        {
            _companiesRepository = companiesRepository; 
            _mapper = mapper;
        }
        public override Task<CompanyDTO> CreateCompany(CreateCompanyRequest request, ServerCallContext context)
        {
            _companiesRepository.BeginTransaction();
            var company = _companiesRepository.Create(request.name);
            _companiesRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<CompanyDTO>(company));
        }

        public override Task<Empty> UpdatePrice(PriceDTO request, ServerCallContext context)
        {
            var modifiedPrice = _mapper.Map<CCM.Domain.Entities.Common.Price>(request);
            _priceRepository.BeginTransaction();
            _priceRepository.Update(modifiedPrice);
            _priceRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }


    }
}