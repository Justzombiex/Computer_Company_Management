using CCM.DataAccess.Abstract.Clients;
using CCM.DataAccess.Abstract.Computers;
using CCM.DataAccess.Abstract.Orders;
using CCM.DataAccess.Abstract.Persons;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Orders;
using CCM.Domain.Entities.Persons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Tests
{
    [TestClass]
    public class BuyOrderTests
    {
        private IBuyOrderRepository _buyOrderRepository;

        public BuyOrderTests()
        {
            _buyOrderRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());    
        }
        /// <summary>
        /// Prueba para crear una orden de compra
        /// </summary>
        /// <param name="clientId">ID del Cliente</param>
        /// <param name="pcId">ID de la PC</param>
        /// <param name="units">Unidades</param>
        [DataRow(1,1,1)]
        [DataRow(2,2,2)]
        [TestCategory("CreateTests3"),TestMethod]
        public void Can_Create_BuyOrder(int clientId, int pcId, int units)
        {
            //Arrange
            _buyOrderRepository.BeginTransaction();
            
            var client = ((IClientRepository)_buyOrderRepository).GetAll().ElementAtOrDefault(clientId);
            Assert.IsNotNull(client);
            PC pc = ((IPCRepository)_buyOrderRepository).Get(pcId);
            Assert.IsNotNull(pc);

            BuyOrder newBuyOrder = _buyOrderRepository.Create(client, pc, units);
            _buyOrderRepository.PartialCommit();
            BuyOrder? loadedBuyOrder = _buyOrderRepository.Get(newBuyOrder.Id);
            _buyOrderRepository.CommitTransaction();

            Assert.IsNotNull(loadedBuyOrder);
            Assert.AreEqual(newBuyOrder.Client, client);
            Assert.AreEqual(newBuyOrder.pC, pc);
            Assert.AreEqual(newBuyOrder.Units, units);
        }
        /// <summary>
        /// Prueba para obtener una orden de compra
        /// </summary>
        /// <param name="id">Id de la orden solicitada</param>
        [DataRow(1)]
        [TestCategory("GetTests"), TestMethod]
        public void Can_Get_BuyOrder (int id)
        {
            _buyOrderRepository.BeginTransaction();

            var loadedBuyOrder = _buyOrderRepository.Get(id);
            _buyOrderRepository.CommitTransaction ();

            Assert.IsNotNull(loadedBuyOrder);
        }

        /// <summary>
        /// Prueba para actualizar una orden de compra
        /// </summary>
        /// <param name="id">Id de la Orden</param>
        /// <param name="units">Cantidad de unidades a actualizar</param>
        [DataRow(1, 10)]
        [TestCategory("UpdateTests"), TestMethod]
        public void Can_Update_BuyOrder (int id, int units)
        {
            // Arrange
            _buyOrderRepository.BeginTransaction();
            var loadedBuyOrder = _buyOrderRepository.Get(id);
            Assert.IsNotNull(loadedBuyOrder);


            // Execute
            loadedBuyOrder.Units = units;
            _buyOrderRepository.Update(loadedBuyOrder);

            // Assert
            var modifyedBuyOrder = _buyOrderRepository.Get(id);
            _buyOrderRepository.CommitTransaction();
            Assert.AreEqual(modifyedBuyOrder.Units, units);
        }
        /// <summary>
        /// Prueba para borrar una orden de compra
        /// </summary>
        /// <param name="id">Id de la orden de compra a eliminar</param>
        [DataRow(2)]
        [TestCategory("WipeTests"), TestMethod]
        public void Can_Delete_BuyOrder (int id)
        {
            _buyOrderRepository.BeginTransaction ();

            var loadedBuyOrder = _buyOrderRepository.Get(id);
            Assert.IsNotNull(loadedBuyOrder);
            _buyOrderRepository.Delete(loadedBuyOrder);
            _buyOrderRepository.PartialCommit ();  
            loadedBuyOrder = _buyOrderRepository.Get(id);
            _buyOrderRepository.CommitTransaction () ;

            Assert.IsNull(loadedBuyOrder);

        }

    }
}
