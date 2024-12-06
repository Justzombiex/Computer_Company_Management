using CCM.DataAccess.Abstract.Orders;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Orders;
using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IBuyOrderRepository
    {
        public BuyOrder Create(Client client, PC pc, int units)
        { 
            BuyOrder buyOrder = new BuyOrder(client, pc, units);
            _context.Add(buyOrder);
            return buyOrder;
        }

        public void Delete(BuyOrder buyOrder)
        {
            _context.Remove(buyOrder);
        }

        public void Update(BuyOrder buyOrder)
        {
            _context.Update(buyOrder);
        }

        BuyOrder? IBuyOrderRepository.Get(int id)
        {
            return _context.Set<BuyOrder>().Find(id);
        }
    }
}
