using CCM.DataAccess.Abstract.Shops;
using CCM.Domain.Entities.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IShopsRepository
    {
        public Shop Create(string name, string address)
        {
            Shop shop = new Shop(name, address);
            _context.Add(shop);
            return shop;
        }

        public void Delete(Shop shop)
        {
            _context.Remove(shop);
        }

        public void Update(Shop shop)
        {
            _context.Remove(shop);
        }

        Shop? IShopsRepository.Get(int id)
        {
            return _context.Set<Shop>().Find(id);
        }
    }
}
