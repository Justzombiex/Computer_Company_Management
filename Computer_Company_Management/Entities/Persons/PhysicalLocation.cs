﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerCompany.Domain.Entities.People
{
    /// <summary>
    /// Modela la ubicación geográfica de una entidad.
    /// </summary>
    public class PhysicalLocation
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

        public override string ToString()
        {
            return $"{Country},{City},{Address}";
        }

    }
}