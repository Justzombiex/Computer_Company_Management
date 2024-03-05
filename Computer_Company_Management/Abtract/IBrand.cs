using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Abstract
{
    /// <summary>
    /// Establece los miembros que debe tener una entidad que posee una marca.
    /// </summary>
    public interface IBrand
    {
        #region Properties
        /// <summary>
        /// Modela una marca
        /// </summary>
        public string Brand { get; }
        #endregion
    }
}
