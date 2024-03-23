using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela un Cliente
    /// </summary>
    public abstract class Client : Entity
    {
        /// <summary>
        /// Para migraciones
        /// </summary>
        protected Client() { }

    }
}
