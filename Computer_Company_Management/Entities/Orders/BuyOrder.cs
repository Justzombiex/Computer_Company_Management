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
        #endregion

        #region IDs
        /// <summary>
        /// ID del cliente para la base de datos
        /// </summary>
        public int ClientID { get; set; }
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
        public BuyOrder (Client client, PC pc, int units)
        {
            Client = client;
            pC = pc;
            Units = units;
        }
        #endregion
    }
}
