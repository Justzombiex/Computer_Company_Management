using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Common;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela la ubicación geográfica de una entidad.
    /// </summary>
    public class PhysicalLocation : Entity
    {

        #region Properties

        /// <summary>
        /// País.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Ciudad.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Dirección local.
        /// </summary>
        public string Address { get; }

        #endregion

        #region Constructor
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected PhysicalLocation() { }

        /// <summary>
        /// Inicializa un objeto <see cref="PhysicalLocation"/>.
        /// </summary>
        /// <param name="country">País.</param>
        /// <param name="city">Ciudad.</param>
        /// <param name="address">Dirección.</param>
        public PhysicalLocation(string country, string city, string address)
        {
            Country = country;
            City = city;
            Address = address;
        }
        #endregion

        public override string ToString()
        {
            return $"{Country},{City},{Address}";
        }

    }
}
