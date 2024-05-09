using AutoMapper;
using CCM.DataAccess.Abstract.Orders;
using CCM.Domain.Entities.Persons;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class BuyOrderService: BuyOrder.BuyOrderBase
    {
        private IBuyOrderRepository _buyOrderRepository;
        private IMapper _mapper;

        public BuyOrderService(IBuyOrderRepository repository, IMapper mapper)
        {
            _buyOrderRepository = repository;
            _mapper = mapper;
        }

        public override Task<BuyOrderTDO> CreateBuyOrder(CreateBuyOrderRequest request, ServerCallContext context)
        {
            _buyOrderRepository.BeginTransaction();
            var client = _mapper.Map<CCM.Domain.Entities.Orders.BuyOrder>(request.Client);
            var pc = _mapper.Map<CCM.Domain.Entities.Orders.BuyOrder>(request.PC);
            var units = _mapper.Map<CCM.Domain.Entities.Orders.BuyOrder>(request.units);
            var buyOrder = _buyOrderRepository.Create(client, pc, units);
            _buyOrderRepository.CommitTransaction();

            return Task.FromResult(_mapper.Map<BuyOrderDTO>(buyOrder));
        }

        public override Task<NullableBuyOrderDTO> GetBuyOrder(GetRequest request, ServerCallContext context)
        {
            _buyOrderRepository.BeginTransaction();
            var buyOrder = _buyOrderRepository.Get(request.Id);
            _buyOrderRepository.CommitTransaction();

            var result = new NullableBuyOrderDTO();
            if (buyOrder is not null)

                result.Pc = _mapper.Map<BuyOrderDTO>(buyOrder);

            return Task.FromResult(result);
        }

        public override Task<Empty> DeleteBuyOrder(BuyOrderDTO request, ServerCallContext context)
        {
            var buyOrder = _mapper.Map<CCM.Domain.Entities.Orders.BuyOrder>(request);
            _buyOrderRepository.BeginTransaction();
            _buyOrderRepository.Delete(buyOrder);
            _buyOrderRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }


    }
}


