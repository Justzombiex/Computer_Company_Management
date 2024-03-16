using CCM.DataAccess.Abstract.Computers;
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
        public PC Create(int hardDriveId, int microprocesorId, int rAMId, int motherBoardId)
        {
            PC pC = new PC(hardDriveId, microprocesorId, rAMId, motherBoardId);
            _context.Add(pC);
            return pC;
        }
        public void Delete(PC pc)
        {
            _context.Remove(pc);
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
