using CCM.DataAccess.Abstract.Persons;
using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IPhysicalLocationRepository
    {
        public PhysicalLocation Create(string country, string city, string address)
        {
            PhysicalLocation physicalLocation = new PhysicalLocation(country, city, address);
            _context.Add(physicalLocation);
            return physicalLocation;
        }

        public void Delete(PhysicalLocation physicalLocation)
        {
            _context.Remove(physicalLocation);
        }
         PhysicalLocation? IPhysicalLocationRepository.Get(int id)
        {
            return _context.Set<PhysicalLocation>().Find(id);
        }


    }
}
