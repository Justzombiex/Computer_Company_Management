using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CCM.Domain.Entities.Company
{
    public class Company
    {
        #region Properties
        /// <summary>
        /// Arreglo de Tiendas que tiene la compañia
        /// </summary>
        public List <Shop> Shops{ get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Crea una compañia <see cref="Company"/>
        /// </summary>
        protected Company()
        {
            Shops = new List<Shop>();
        }
       #endregion
    }
}
