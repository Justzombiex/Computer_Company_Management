using AutoMapper;
using CCM.DataAccess.Abstract.Components;
using CCM.DataAccess.Abstract.Computers;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Types;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class PCService : CCM.GrpcProtos.PC.PCBase
    {

        private IPCRepository _pcRepository;
        private IMapper _mapper;

        public PCService(IPCRepository repository, IMapper mapper)

        {
            _pcRepository = repository;
            _mapper = mapper;
        }


        public override Task<PCDTO> CreatePC(CreatePCRequest request, ServerCallContext context)
        {
            _pcRepository.BeginTransaction();
            var harddrive = _mapper.Map<CCM.Domain.Entities.Components.HardDrive>(request.Harddrive);
            var microprocesor = _mapper.Map<CCM.Domain.Entities.Components.Microprocesor>(request.Microprocesor);
            var ram = _mapper.Map<CCM.Domain.Entities.Components.RAM>(request.Ram);
            var motherboard = _mapper.Map<CCM.Domain.Entities.Components.MotherBoard>(request.Motherboard);
            var price = _mapper.Map<CCM.Domain.Entities.Common.Price>(request.Price);
            var pc = _pcRepository.Create(harddrive, microprocesor, ram, motherboard, price);
            _pcRepository.CommitTransaction();

            return Task.FromResult(_mapper.Map<PCDTO>(pc));
        }

        public override Task<NullablePCDTO> GetPC(GetRequest request, ServerCallContext context)
        {
            _pcRepository.BeginTransaction();
            var pc = _pcRepository.Get(request.Id);
            _pcRepository.CommitTransaction();

            var result = new NullablePCDTO();
            if (pc is not null)

                result.Pc = _mapper.Map<PCDTO>(pc);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeletePC(PCDTO request, ServerCallContext context)
        {
            var pc = _mapper.Map<CCM.Domain.Entities.Computers.PC>(request);
            _pcRepository.BeginTransaction();
            _pcRepository.Delete(pc);
            _pcRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

    }
}
