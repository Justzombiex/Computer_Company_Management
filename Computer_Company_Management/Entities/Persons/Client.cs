using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Common;

namespace CCM.Domain.Entities.Persons
{
    #region Constructor
    /// <summary>
    /// Modela un cliente de la tienda de computadoras.
    /// </summary>
    public abstract class Client : Entity
    {

    }

    /// <summary>
    /// Requerido por EntityFrameworkCore para migraciones.
    /// </summary>
    protected Client() { }
    #endregion
}
