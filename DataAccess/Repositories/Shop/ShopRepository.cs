using CCM.DataAccess.Abstract.Shops;
using CCM.Domain.Entities.Companies;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Persons;
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
        public Shop Create(string name, PhysicalLocation location)
        {
            Shop shop = new Shop(name, location);
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
