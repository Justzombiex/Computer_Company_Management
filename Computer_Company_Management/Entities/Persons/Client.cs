using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using CCM.Domain.Entities.Shops;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela un Cliente
    /// </summary>
    public abstract class Client : Entity
    {
        #region ID
        /// <summary>
        /// Identificador del cliente
        /// </summary>
        public int ClientId;

        [NotMapped]
        /// <sumary>
        /// Tienda donde compra el cliente
        /// <sumary>
        public Shop Shop { get; set; } 

        /// <summary>
        /// ID de la tienda donde compra el cliente
        /// </summary>
        public int ShopId { get; protected set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Client() { }

        
        #endregion

    }
}
