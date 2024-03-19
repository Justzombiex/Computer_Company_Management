using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Types
{
    public enum JobType
    {
        /// <summary>
        /// Presidente de la compañía
        /// </summary>
        CEO,
        /// <summary>
        /// Administrador de la tienda
        /// </summary>
        MANAGER,
        /// <summary>
        /// Trabajador regular de la tienda
        /// </summary>
        STORECLERK
    }
}