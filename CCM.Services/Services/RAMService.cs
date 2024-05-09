using AutoMapper;
using CCM.DataAccess.Abstract.Components;
using CCM.Domain.Entities.Types;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class RAMService : RAM.RAMBase
    {

        private IRAMRepository _ramRepository;
        private IMapper _mapper;

        public RAMService(IRAMRepository repository, IMapper mapper)
        {

            _ramRepository = repository;
            _mapper = mapper;
        }

        public override Task<RAMDTO> CreateRAM(CreateRAMRequest request, ServerCallContext context)
        {
            _ramRepository.BeginTransaction();
            var ram = _ramRepository.Create(request.MemorySize, request.Brand, (MemoryType)request.MemoryType);
            _ramRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<RAMDTO>(ram));
        }

        public override Task<NullableRAMDTO> GetRAM(GetRequest request, ServerCallContext context)
        {
            _ramRepository.BeginTransaction();
            var ram = _ramRepository.Get(request.Id);
            _ramRepository.CommitTransaction();

            var result = new NullableRAMDTO();
            if (ram is not null)
                result.Ram = _mapper.Map<RAMDTO>(ram);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeleteRAM(RAMDTO request, ServerCallContext context)
        {
            var price = _mapper.Map<CCM.Domain.Entities.Components.RAM>(request);
            _ramRepository.BeginTransaction();
            _ramRepository.Delete(price);
            _ramRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }
    }
}
        
