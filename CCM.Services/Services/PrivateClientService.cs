using AutoMapper;
using CCM.DataAccess.Abstract.Clients;
using CCM.DataAccess.Abstract.Persons;
using CCM.Domain.Entities.Persons;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class PrivateClientService : PrivateClient.PrivateClientBase
    {

        private IClientRepository _clientRepository;
        private IMapper _mapper;

        public PrivateClientService(IClientRepository repository, IMapper mapper)
        {
            _clientRepository = repository;
            _mapper = mapper;
        }

        public override Task<PrivateClientDTO> CreatePrivateClient(CreatePrivateClientRequest request, ServerCallContext context)
        {
            _clientRepository.BeginTransaction();
            var privateclient = _clientRepository.Create(request.Name, request.CI, request.Age);
            _clientRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<PrivateClientDTO>(privateClient));
        }

        public override Task<NullablePrivateClientDTO> GetPrivateClient(GetRequest request, ServerCallContext context)
        {
            _clientRepository.BeginTransaction();
            var privateclient = _clientRepository.Get(request.Id);
            _clientRepository.CommitTransaction();

            var result = new NullableClientDTO();
            if (privateclient is not null)
                result.PrivateClient = _mapper.Map<PrivateClientDTO>(privateclient);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeletePrivateClient(PrivateClientDTO request, ServerCallContext context)
        {
            var privateclient = _mapper.Map<CCM.Domain.Entities.Persons.PrivateClient>(request);
            _clientRepository.BeginTransaction();
            _clientRepository.Delete(privateClient);
            _clientRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

    }
}
