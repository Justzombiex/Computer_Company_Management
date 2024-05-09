using AutoMapper;
using CCM.DataAccess.Abstract.Components;
using CCM.Domain.Entities.Types;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class MotherBoardService : MotherBoard.MotherBoardBase
    {

        private IMotherBoardRepository _motherboardRepository;
        private IMapper _mapper;

        public MotherBoardService(IMotherBoardRepository repository, IMapper mapper)

        {
            _motherboardRepository = repository;
            _mapper = mapper;
        }

        public override Task<MotherBoardDTO> CreateMotherBoard(CreateMotherBoardRequest request, ServerCallContext context)
        {
            _motherboardRepository.BeginTransaction();
            var motherboard = _motherboardRepository.Create(request.Model, request.Brand, (ConnectionType)request.ConnectionType);
            _motherboardRepository.CommitTransaction();

            return Task.FromResult(_mapper.Map<MotherBoardDTO>(motherboard));
        }

        public override Task<NullableMotherBoardDTO> GetMotherBoard(GetRequest request, ServerCallContext context)
        {
            _motherboardRepository.BeginTransaction();
            var motherboard = _motherboardRepository.Get(request.Id);
            _motherboardRepository.CommitTransaction();

            var result = new NullableMotherBoardDTO();
            if (motherboard is not null)

                result.Motherboard = _mapper.Map<MotherBoardDTO>(motherboard);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeleteMotherBoard(MotherBoardDTO request, ServerCallContext context)
        {
            var motherboard = _mapper.Map<CCM.Domain.Entities.Components.MotherBoard>(request);
            _motherboardRepository.BeginTransaction();
            _motherboardRepository.Delete(motherboard);
            _motherboardRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

    }
}
