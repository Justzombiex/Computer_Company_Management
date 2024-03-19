using CCM.Domain.Abstract;
using CCM.Domain.Entities.Persons;
using ComputerCompany.Domain.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela un cliente empresarial.
    /// </summary>
    public class EnterpriseClient
    {
        #region Properties
        public PhysicalLocation location;

        /// <summary>
        /// Ubicación geográfica de la sede de la empresa cliente.
        /// </summary>
        public PhysicalLocation Location { get => location; set => location = value; }

        #endregion

        #region Inicializacion
        /// <summary>
        /// Inicializa un objeto <see cref="EnterpriseClient"/>.
        /// </summary>
        /// <param name="location">Ubicación geográfica de la empresa.</param>
        public EnterpriseClient(PhysicalLocation location) => Location = location;
        #endregion

        #region Constructor por defecto
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public EnterpriseClient()
        {
        }
        #endregion
    }
}
