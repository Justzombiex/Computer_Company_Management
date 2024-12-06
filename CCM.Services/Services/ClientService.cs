using AutoMapper;
using CCM.DataAccess.Abstract.Clients;
using CCM.DataAccess.Abstract.Persons;
using CCM.Domain.Entities.Persons;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class ClientService : Client.ClientBase
    {

        private IClientRepository _clientRepository;
        private IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
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

        public override Task<NullableClientDTO> GetClient(GetRequest request, ServerCallContext context)
        {
            _clientRepository.BeginTransaction();
            var client = _clientRepository.Get(request.Id);
            _clientRepository.CommitTransaction();

            var result = new NullableClientDTO();
            if (client is not null)
                result.Client = _mapper.Map<HClientDTO>(client);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeleteClient(ClientDTO request, ServerCallContext context)
        {
            var client = _mapper.Map<CCM.Domain.Entities.Persons.Client>(request);
            _clientRepository.BeginTransaction();
            _clientRepository.Delete(hardDrive);
            _clientRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

    }
}
