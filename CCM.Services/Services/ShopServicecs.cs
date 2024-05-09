using AutoMapper;
using CCM.DataAccess.Abstract.Shops;
using CCM.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CCM.Services.Services
{
    public class ShopService : Shop.ShopBase
    {
        private IShopsRepository _shopsRepository;
        private IMapper _mapper;

        public ShopService(IShopsRepository repository, IMapper mapper)
        {
            _shopsRepository = repository;
            _mapper = mapper;
        }
        public override Task<ShopDTO>CreateShop(CreateShopRequest request, ServerCallContext context)
        {
            _shopsRepository.BeginTransaction();
            //var shop = _shopsRepository.Create(request.name, request.)
            _shopsRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<ShopDTO>(shop));
        }

        public override Task<ShopDTO> GetShop(GetRequest request, ServerCallContext context)
        {
            _shopsRepository.BeginTransaction();
            var shop = _shopsRepository.Get(request.Id);
            _shopsRepository.CommitTransaction();

            var result = new NullableShopDTO();
            if (shop is not null)
                result.Shop = _mapper.Map<ShopDTO>(shop);

            return Task.FromResult(result);
        }

        public override Task<Empty> UpdateShop(ShopDTO request, ServerCallContext context)
        {
            var modifiedShop = _mapper.Map<CCM.Domain.Entities.Shops.Shop>(request);
            _shopsRepository.BeginTransaction();
            _shopsRepository.Update(modifiedShop);
            _shopsRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteShop(ShopDTO request, ServerCallContext context)
        {
            var shop = _mapper.Map<CCM.Domain.Entities.Shops.Shop>(request);
            _shopsRepository.BeginTransaction();
            _shopsRepository.Delete(shop);
            _shopsRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }


    }
}