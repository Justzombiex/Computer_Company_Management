using CCM.DataAccess.Abstract.Persons;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IWorkerRepository
    {
        public Worker Create(string workerid, JobType job, double salary)
        {
            Worker worker = new Worker(workerid, job, salary);
            _context.Add(worker);
            return worker;
        }

        public void Delete(Worker worker)
        {
            _context.Remove(worker);
        }

        public Worker? Get(int id)
        {
            return _context.Set<Worker>().Find(id);
        }

        public void Update(Worker worker)
        {
            _context.Update(worker);    
        }
    }
}
