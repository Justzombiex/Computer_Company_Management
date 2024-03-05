using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Types
{
    /// <summary>
    /// Tipo de conexión del microprocesador y la motherboard
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// Land Grid Array
        /// </summary>
        LGA,
        /// <summary>
        /// Pin Grid Array
        /// </summary>
        PGA,
        /// <summary>
        /// Zero Insertion Force
        /// </summary>
        ZIF,
        /// <summary>
        /// Ball Grid Array
        /// </summary>
        BGA,
        /// <summary>
        /// Dual In-Line Package
        /// </summary>
        DIP
    }
}
