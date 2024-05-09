using CCM.DataAccess.Abstract.Components;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IRAMRepository
    {
        public RAM Create(double memorySize, string brand, MemoryType memoryType)
        {
           RAM rAM = new RAM(memorySize, brand, memoryType);
            _context.Add(rAM);
            return rAM;
        }

        public void Delete(RAM rAM)
        {
            _context.Remove(rAM);
        }

        RAM? IRAMRepository.Get(int id)
        {
            return _context.Set<RAM>().Find(id);
        }
    }
}
