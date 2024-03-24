using CCM.Domain.Abstract;
using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Common;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela un cliente empresarial.
    /// </summary>
    public class EnterpriseClient : Client, IBrand
    {
        #region Properties
        public string Brand { get; set; }

        public PhysicalLocation location;

        /// <summary>
        /// Ubicación geográfica de la sede de la empresa cliente.
        /// </summary>
        public PhysicalLocation Location { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected EnterpriseClient() { }

        /// <summary>
        /// Inicializa una empresa cliente <see cref="EnterpriseClient"/>.
        /// </summary>
        /// <param name="brand">Marca de la empresa.</param>
        /// <param name="location">Ubicación geográfica de la empresa.</param>
        public EnterpriseClient(string brand, PhysicalLocation location)
        {
            Brand = brand;
            Location = location;
        }
        #endregion


    }
}
