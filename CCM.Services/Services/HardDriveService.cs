using AutoMapper;
using CCM.DataAccess.Abstract.Components;
using CCM.Domain.Entities.Types;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class HardDriveService : HardDrive.HardDriveBase
    {

        private IHardDriveRepository _hardDriveRepository;
        private IMapper _mapper;

        public HardDriveService(IHardDriveRepository repository, IMapper mapper)
        {
            _hardDriveRepository = repository;
            _mapper = mapper;
        }

        public override Task<HardDriveDTO> CreateHardDrive(CreateHardDriveRequest request, ServerCallContext context)
        {
            _hardDriveRepository.BeginTransaction();
            var hardDrive = _hardDriveRepository.Create(request.Model, request.Brand, request.Storage, (ConnectionHardDriveType)request.ConnectionHardDrivesType);
            _hardDriveRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<HardDriveDTO>(hardDrive));
        }

        public override Task<NullableHardDriveDTO> GetHardDrive(GetRequest request, ServerCallContext context)
        {
            _hardDriveRepository.BeginTransaction();
            var hardDrive = _hardDriveRepository.Get(request.Id);
            _hardDriveRepository.CommitTransaction();

            var result = new NullableHardDriveDTO();
            if (hardDrive is not null)
                result.Harddrive = _mapper.Map<HardDriveDTO>(hardDrive);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeleteHardDrive(HardDriveDTO request, ServerCallContext context)
        {
            var hardDrive = _mapper.Map<CCM.Domain.Entities.Persons.HardDrive>(request);
            _hardDriveRepository.BeginTransaction();
            _hardDriveRepository.Delete(hardDrive);
            _hardDriveRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

    }
}
