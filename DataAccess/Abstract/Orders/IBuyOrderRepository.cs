using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Orders;
using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Abstract.Orders
{
    /// <summary>
    /// Operaciones que se pueden realizar en BD con las Ordenes de Compra
    /// </summary>
    public interface IBuyOrderRepository : IRepository
    {
        /// <summary>
        /// Crea una orden de compra en una BD
        /// </summary>
        /// <param name="client">Cliente</param>
        /// <param name="pc">Computadora</param>
        /// <param name="units">Unidades</param>
        /// <returns></returns>
        BuyOrder Create(Client client, PC pc, int units);
        /// <summary>
        /// Obtiene una orden de compra de una BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BuyOrder? Get(int id);
        /// <summary>
        /// Actualiza una Orden de Compra en una BD
        /// </summary>
        /// <param name="buyOrder">Orden de Compra</param>
        /// <returns></returns>
        void Update(BuyOrder buyOrder);
        /// <summary>
        /// Elimina una Orden de Compra de una BD
        /// </summary>
        /// <param name="buyOrder">Orden de Compra</param>
        /// <returns></returns>
        void Delete(BuyOrder buyOrder);
    }
}
