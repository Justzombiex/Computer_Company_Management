using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Orders
{
    public class BuyOrder : Entity
    {
        #region Properties
        /// <summary>
        /// Cliente que realizo la compra
        /// </summary>
        [NotMapped]
        public Client Client { get; set; }

        /// <summary>
        /// PC que se va a comprar
        /// </summary>
        [NotMapped]
        public PC pC { get; set; }

        /// <summary>
        /// Unidades que va a comprar el cliente
        /// </summary>
        public int Units { get; set; }

        /// <summary>
        /// Fecha de creación de la orden.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Fecha en la que se ejecuta el pago.
        /// </summary>
        public DateTime? PaymentDay { get; set; }

        /// <summary>
        /// Indica si la orden de compra ya fue pagada;
        /// </summary>
        [NotMapped]
        public bool IsPayed => PaymentDay is not null;

        /// <summary>
        /// Precio total a pagar por la orden.
        /// </summary>
        [NotMapped]
        public Price TotalPrice => new Price(pC.Price.Currency, pC.Price.Value * Units);
        #endregion

        #region IDs

        /// <summary>
        /// ID del cliente para la base de datos
        /// </summary>
        public int ClientID { get; protected set; }

        /// <summary>
        /// ID de la PC que se va a comprar
        /// </summary>
        public int PCId { get; set; } 
        
        #endregion

        #region Constructors
        /// <summary>
        /// Para Migraciones
        /// </summary>
        protected BuyOrder () {}

        /// <summary>
        /// Crea una orden de compra
        /// </summary>
        /// <param name="client">Cliente que realiza la compra</param>
        /// <param name="pc">PC a vender</param>
        /// <param name="units">Cantidad de unidades vendidas</param>
        public BuyOrder (Client client, PC pc, int units = 1)
        {
            Client = client;
            pC = pc;
            Units = units;
            ClientID = client.Id;
            PCId = pc.Id;
        }
        #endregion
    }
}
