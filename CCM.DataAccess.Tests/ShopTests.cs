using CCM.DataAccess.Abstract.Shops;
using CCM.DataAccess.Concrete;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.Domain.Entities.Shops;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Tests
{
    [TestClass]
    public class ShopTests
    {
        private IShopsRepository _shopsRepository;

        public ShopTests()
        {
            _shopsRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow("TiendaA", "Calle_51")]
        [DataRow("TiendaB", "Calle_49")]
        [TestMethod]
        public void Can_Create_Shop(string name, string address)
        {
            Shop newShop = _shopsRepository.Create(name, address);
            _shopsRepository.PartialCommit();
            Shop? loadedShop = _shopsRepository.Get(newShop.Id);
            _shopsRepository.CommitTransaction();

            Assert.IsNotNull(loadedShop);
            Assert.AreEqual(loadedShop.ShopName, name);
            Assert.AreEqual(loadedShop.ShopAddress, address);
        }

        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Shop(int id)
        {
            _shopsRepository.BeginTransaction();

            var loadedShop = _shopsRepository.Get(id);
            _shopsRepository.CommitTransaction();

            Assert.IsNotNull(loadedShop);
        }

        [DataRow(1, "TiendaA", "Calle_51")]
        [DataRow(2, "TiendaB", "Calle_49")]
        [TestMethod]
        public void Can_Update_Shop(int id, string name, string address)
        {
            _shopsRepository.BeginTransaction();

            var loadedShop = _shopsRepository.Get(id);
            Assert.IsNotNull(loadedShop);
            var newShop = new Shop(name, address) { Id = loadedShop.Id };
            _shopsRepository.Update(newShop);
            var modifyedShop = _shopsRepository.Get(id);
            _shopsRepository.CommitTransaction();

            Assert.AreEqual(modifyedShop.ShopName, name);
            Assert.AreEqual(modifyedShop.ShopAddress, address);
        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Shop(int id)
        {
            _shopsRepository.BeginTransaction();

            var loadedShop = _shopsRepository.Get(id);
            Assert.IsNotNull(loadedShop);
            _shopsRepository.Delete(loadedShop);
            _shopsRepository.PartialCommit();
            loadedShop = _shopsRepository.Get(id);
            _shopsRepository.CommitTransaction();

            Assert.IsNull(loadedShop);
        }
    }
}
