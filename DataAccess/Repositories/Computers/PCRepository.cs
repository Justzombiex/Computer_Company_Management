using CCM.DataAccess.Abstract.Computers;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Components;
using CCM.Domain.Entities.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IPCRepository
    {
        public PC Create(HardDrive hardDrive, Microprocesor microprocesor, RAM rAM, MotherBoard motherBoard, Price price)
        {
            PC pC = new PC(hardDrive, microprocesor, rAM, motherBoard, price);
            _context.Add(pC);
            return pC;
        }
        public void Delete(PC pc)
        {
            _context.Remove(pc);
        }
        public IEnumerable<PC> GetAllPC()
        {
            return _context.Set<PC>().ToList();
        }
        public void Update(PC pc)
        {
            _context.Update(pc);
        }
        PC? IPCRepository.Get(int id)
        {
            return _context.Set<PC>().Find(id);
        }
    }
}
