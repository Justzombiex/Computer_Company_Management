using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Persons;

namespace CCM.DataAccess.Abstract.Persons
{
    /// <summary>
    /// Define las operaciones a realizar en base de datos con clientes 
    /// </summary>
    public interface IClientRepository : IRepository
    {
        Client Create() 
    }
}
