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

        public override Task<Empty> UpdateCompany(CompanyDTO request, ServerCallContext context)
        {
            var modifiedCompany = _mapper.Map<CCM.Domain.Entities.Companies.Company>(request);
            _companiesRepository.BeginTransaction();
            _companiesRepository.Update(modifiedCompany);
            _companiesRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCompany(CompanyDTO request, ServerCallContext context)
        {
            var company = _mapper.Map<CCM.Domain.Entities.Companies.Company>(request);
            _companiesRepository.BeginTransaction();
            _companiesRepository.Delete(company);
            _companiesRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }
    }
}