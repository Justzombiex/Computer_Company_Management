using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Common
{
    /// <summary>
    /// Modela el precio
    /// </summary>
    internal class Price : Entity
    {
        #region Properties
        /// <summary>
        /// Tipo de Moneda
        /// </summary>
        public MoneyType Currency { get; set; } 
        /// <summary>
        /// Cantidad de dinero
        /// </summary>
        public double Quantity { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Para migraciones
        /// </summary>
        protected Price () {}
        /// <summary>
        /// Crea un objeto de tipo <see cref="Price"/>
        /// </summary>
        /// <param name="currency">Tipo de moneda</param>
        /// <param name="quantity"></param>
        public Price (MoneyType currency, double quantity)
        {
            Currency = currency;   
            Quantity = quantity;
        }
        #endregion

    }
}
