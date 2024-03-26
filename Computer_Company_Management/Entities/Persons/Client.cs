using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using CCM.Domain.Entities.Orders;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela un Cliente
    /// </summary>
    public abstract class Client : Entity
    {
        ///hacer lo necesario para la herencia de cliente empresarial y de cliente privado 
        ///agragar los id de physicallocation

        #region IDs
        /// <summary>
        /// Identificador del cliente
        /// </summary>
        public int ClientId;

        [NotMapped]
        /// <sumary>
        /// Orden de compra del cliente
        /// <sumary>
        public BuyOrder buyOrder { get; set; } 

        /// <summary>
        /// ID de la orden de compra
        /// </summary>
        public int BuyOrderId { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Client() { }

        /// <summary>
        /// Inicializando el cliente
        /// </summary>
        /// <param name="buy_Order"></param>
        public Client(BuyOrder buy_Order)
        {
            buyOrder = buy_Order;
            BuyOrderId = buy_Order.Id;

        }
        #endregion

    }
}
