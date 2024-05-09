using AutoMapper;
using CCM.DataAccess.Abstract.Clients;
using CCM.DataAccess.Abstract.Persons;
using CCM.Domain.Entities.Persons;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class EnterpriseClientService : EnterpriseClient.EnterpriseClientBase
    {

        private IClientRepository _clientRepository;
        private IMapper _mapper;

        public EnterpriseClientService(IClientRepository repository, IMapper mapper)
        {
            _clientRepository = repository;
            _mapper = mapper;
        }

        public override Task<EnterpriseClientDTO> CreateEnterpriseClient(CreateEnterpriseClientRequest request, ServerCallContext context)
        {
            _clientRepository.BeginTransaction();
            var enterpriseclient = _clientRepository.Create(request.Brand, request.Location);
            _clientRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<EnterpriseClientDTO>(enterpriseClient));
        }

        public override Task<NullableEnterpriseClientDTO> GetEnterpriseClient(GetRequest request, ServerCallContext context)
        {
            _clientRepository.BeginTransaction();
            var enterpriseclient = _clientRepository.Get(request.Id);
            _clientRepository.CommitTransaction();

            var result = new NullableEnterpriseClientDTO();
            if (enterpriseclient is not null)
                result.EnterpriseClient = _mapper.Map<EnterpriseClientDTO>(enterpriseclient);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeleteEnterpriseClient(EnterpriseClientDTO request, ServerCallContext context)
        {
            var enterpriseclient = _mapper.Map<CCM.Domain.Entities.Persons.EnterpriseClient>(request);
            _clientRepository.BeginTransaction();
            _clientRepository.Delete(enterpriseClient);
            _clientRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

    }
}
