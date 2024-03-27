using CCM.Domain.Entities.Common;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.Domain.Entities.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.DataAccess.Abstract.Common;

namespace CCM.DataAccess.Tests
{
    [TestClass]
    public class PriceTests
    {
        private IPriceRepository _priceRepository;

        public PriceTests()
        {
            _priceRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        /// <summary>
        /// Prueba para crear un precio
        /// </summary>
        /// <param name="moneyType">Tipo de moneda del precio</param>
        /// <param name="value">Valor del precio</param>
        [DataRow(MoneyType.Euro, 500)]
        [DataRow(MoneyType.MN, 70000)]
        [TestMethod]
        public void Can_Create_Price(MoneyType moneyType, double value)
        {
            // Arrange
            _priceRepository.BeginTransaction();

            // Execute
            Price newPrice = _priceRepository.Create(moneyType, value);
            _priceRepository.PartialCommit(); // Generando id del nuevo elemento.
            Price? loadedPrice = _priceRepository.Get(newPrice.Id);
            _priceRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedPrice);
            Assert.AreEqual(loadedPrice.Currency, moneyType);
            Assert.AreEqual(loadedPrice.Value, value);
        }

        /// <summary>
        /// Prueba para para obtener un precio
        /// </summary>
        /// <param name="id">Id del precio</param>
        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Price(int id)
        {
            // Arrange
            _priceRepository.BeginTransaction();

            // Execute
            var loadedPrice = _priceRepository.Get(id);
            _priceRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedPrice);
        }

        /// <summary>
        /// Prueba paraactualizar un precio
        /// </summary>
        /// <param name="id">Id del precio</param>
        /// <param name="moneyType">Tipo de moneda</param>
        /// <param name="value">Valor del precio</param>
        [DataRow(1, MoneyType.USD, 6200)]
        [DataRow(2, MoneyType.MLC, 8000)]
        [TestMethod]
        public void Can_Update_Price(int id, MoneyType moneyType, double value)
        {
            // Arrange
            _priceRepository.BeginTransaction();
            var loadedPrice = _priceRepository.Get(id);
            Assert.IsNotNull(loadedPrice);


            // Execute
            loadedPrice.Currency = moneyType;
            loadedPrice.Value = value;
            _priceRepository.Update(loadedPrice);

            // Assert
            var modifyedPrice = _priceRepository.Get(id);
            _priceRepository.CommitTransaction();
            Assert.AreEqual(modifyedPrice.Currency, moneyType);
            Assert.AreEqual(modifyedPrice.Value, value);
        }

        /// <summary>
        /// Prueba para borrar el precio
        /// </summary>
        /// <param name="id">Id del precio</param>
        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Price(int id)
        {
            // Arrange
            _priceRepository.BeginTransaction();

            // Execute
            var loadedPrice = _priceRepository.Get(id);
            Assert.IsNotNull(loadedPrice);
            _priceRepository.Delete(loadedPrice);
            _priceRepository.PartialCommit();
            loadedPrice = _priceRepository.Get(id);
            _priceRepository.CommitTransaction();

            // Assert
            Assert.IsNull(loadedPrice);
        }

    }
}
