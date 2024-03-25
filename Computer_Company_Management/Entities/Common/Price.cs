using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Common
{
    /// <summary>
    /// Precio de una entidad de la tienda de computadoras.
    /// </summary>
    public class Price : Entity
    {
        #region Properties

        /// <summary>
        /// Divisa a en la que se expresa el valor del automóvil.
        /// </summary>
        public MoneyType Currency { get; set; }

        /// <summary>
        /// Valor del precio.
        /// </summary>
        public double Value { get; set; }

        #endregion
        /// <summary>
        /// Requerido por EntityFrameworkRequerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Price() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Price"/>
        /// </summary>
        /// <param name="moneyType">Divisa a en la que se expresa el valor de lla PC.</param>
        /// <param name="value">Valor del precio.</param>
        public Price(MoneyType moneyType, double value)
        {
            Currency = moneyType;
            Value = value;
        }
    }
}
