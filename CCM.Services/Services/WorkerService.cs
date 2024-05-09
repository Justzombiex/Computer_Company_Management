using AutoMapper;
using CCM.DataAccess.Abstract.Persons;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class WorkerService : Worker.WorkerBase
    {

        private IWorkerRepository _workerRepository;
        private IMapper _mapper;  

        public WorkerService(IWorkerRepository repository, IMapper mapper)
        {
            _workerRepository = repository;
            _mapper = mapper;
        }

        public override Task<WorkerDTO> CreateWorker (CreateWorkerRequest request, ServerCallContext context)
        {
            _workerRepository.BeginTransaction();
            var worker = _workerRepository.Create(request.Workerid,(Domain.Entities.Types.JobType)request.Job, request.Salary);
            _workerRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<WorkerDTO>(worker));
        }

        public override Task<NullableWorkerDTO> GetWorker(GetRequest request, ServerCallContext context)
        {
            _workerRepository.BeginTransaction();
            var worker = _workerRepository.Get(request.Id);
            _workerRepository.CommitTransaction();

            var result = new NullableWorkerDTO();
            if (worker is not null)
                result.Worker = _mapper.Map<WorkerDTO>(worker);

            return Task.FromResult(result);
        }

        public override Task<Empty> UpdateWorker(PriceDTO request, ServerCallContext context)
        {
            var modifiedWorker = _mapper.Map<CCM.Domain.Entities.Common.Entity>(request);
            _workerRepository.BeginTransaction();
            _workerRepository.Update(modifiedWorker);
            _workerRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteWorker(WorkerDTO request, ServerCallContext context)
        {
            var worker = _mapper.Map<CCM.Domain.Entities.Common.Entity>(request);
            _workerRepository.BeginTransaction();
            _workerRepository.Delete(worker);
            _workerRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }
    }
}
