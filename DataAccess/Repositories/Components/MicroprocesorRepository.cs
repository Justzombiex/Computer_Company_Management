using CCM.DataAccess.Abstract.Components;
using CCM.Domain.Entities.Components;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IMicroprocesorRepository
    {
        public Microprocesor Create(string model, int processorSpeed, string brand, ConnectionType connectionType)
        {
            Microprocesor microprocesor = new Microprocesor(model, processorSpeed, brand, connectionType);
            _context.Add(microprocesor);
            return microprocesor;
        }

        public void Delete(Microprocesor microprocesor)
        {
            _context.Remove(microprocesor);
        }

        Microprocesor? IMicroprocesorRepository.Get(int id)
        {
            return _context.Set<Microprocesor>().Find(id);
        }
    }
}
