using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Types
{
    /// <summary>
    /// Tipos de monedas a utilizar en la compra de PC
    /// </summary>
    public enum MoneyType
    {
        /// <summary>
        /// Moneda nacional.
        /// </summary>
        MN,
        /// <summary>
        /// Dolar estadounidense.
        /// </summary>
        USD,
        /// <summary>
        /// Moneda Libremente Convertible nacional.
        /// </summary>
        MLC,
        /// <summary>
        /// Euro. Moneda de la Unión Europea.
        /// </summary>
        Euro
    }
}
