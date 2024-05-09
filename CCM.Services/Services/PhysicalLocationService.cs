using AutoMapper;
using CCM.DataAccess.Abstract.Persons;
using CCM.Domain.Entities.Types;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services { 
    public class PhysicalLocationService : PhysicalLocation.PhysicalLocationBase
    {
        private IPhysicalLocationRepository _physicallocationRepository;
        private IMapper _mapper;

        public PhysicalLocationService(IPhysicalLocationRepository physicallocationRepository, IMapper mapper)
        {
            _physicallocationRepository = physicallocationRepository;   
            _mapper = mapper;
        }

        public override Task<PhysicalLocationDTO> CreatePhysicalLocation(CreatePhysicalLocationRequest request, ServerCallContext context)
        {
            _physicallocationRepository.BeginTransaction();
            var physicalLocation = _physicallocationRepository.Create(request.country,request.city,request.address);
            _physicallocationRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<PhysicalLocationDTO>(physicalLocations));
        }
        public override Task<NullablePhysicalLocationDTO> GetPhysicalLocation(GetRequest request, ServerCallContext context)
        {
            _physicallocationRepository.BeginTransaction();
            var physicalLocation = _physicallocationRepository.Get(request.Id);
            _physicallocationRepository.CommitTransaction();

            var result = new NullablePhysicalLocationDTO();
            if (physicalLocation is not null)
                result.PhysicalLocation = _mapper.Map<PhysicalLocationDTO>(physicalLocation);

            return Task.FromResult(result);
        }
        public override Task<Empty> UpdatePhysicalLocation(PhysicalLocationDTO request, ServerCallContext context)
        {
            var modifiedPhysicalLocation = _mapper.Map<CCM.Domain.Entities.Common.Price>(request);
            _physicallocationRepository.BeginTransaction();
            _physicallocationRepository.Update(modifiedPhysicalLocation);
            _physicallocationRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeletePhysicalLocation(PhysicalLocationDTO request, ServerCallContext context)
        {
            var physicalLocation = _mapper.Map<CCM.Domain.Entities.Persons.PhysicalLocation>(request);
            _physicallocationRepository.BeginTransaction();
            _physicallocationRepository.Delete(physicalLocation);
            _physicallocationRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }
    }


}