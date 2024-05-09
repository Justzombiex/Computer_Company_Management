using AutoMapper;
using CCM.DataAccess.Abstract.Components;
using CCM.Domain.Entities.Types;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class MicroprocesorService: Microprocesor.MicroprocesorBase
    {

        private IMicroprocesorRepository _microprocesorRepository;
        private IMapper _mapper;

        public MicroprocesorService(IMicroprocesorRepository repository, IMapper mapper)
        {
            _microprocesorRepository = repository;
            _mapper = mapper;
        }

        public override Task<MicroprocesorDTO> CreateMicroprocesor(CreateMicroprocesorRequest request, ServerCallContext context)
        {
            _microprocesorRepository.BeginTransaction();
            var microprocesor = _microprocesorRepository.Create(request.Model, request.ProcessorSpeed, request.Brand, (ConnectionType)request.ConnectionType);
            _microprocesorRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<MicroprocesorDTO>(microprocesor));
        }

        public override Task<NullableMicroprocesorDTO> GetMicroprocesor(GetRequest request, ServerCallContext context)
        {
            _microprocesorRepository.BeginTransaction();
            var microprocesor = _microprocesorRepository.Get(request.Id);
            _microprocesorRepository.CommitTransaction();

            var result = new NullableMicroprocesorDTO();
            if (microprocesor is not null)
                result.Microprocesor = _mapper.Map<MicroprocesorDTO>(microprocesor);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeleteMicroprocesor(MicroprocesorDTO request, ServerCallContext context)
        {
            var microprocesor = _mapper.Map<CCM.Domain.Entities.Components.Microprocesor>(request);
            _microprocesorRepository.BeginTransaction();
            _microprocesorRepository.Delete(microprocesor);
            _microprocesorRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

    }
}
