using CCM.DataAccess.Abstract.Companies;
using CCM.DataAccess.Abstract.Computers;
using CCM.DataAccess.Abstract.Persons;
using CCM.DataAccess.Abstract.Shops;
using CCM.DataAccess.Concrete;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.Domain.Entities.Companies;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Persons;
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

        [DataRow("TiendaA", 1)]
        [DataRow("TiendaB", 2)]
        [TestMethod]
        public void Can_Create_Shop(string name, int physicalLocationId)
        {
           
            //Arrange
            _shopsRepository.BeginTransaction();
            PhysicalLocation physicalLocation = ((IPhysicalLocationRepository)_shopsRepository).Get(physicalLocationId);
            Assert.IsNotNull(physicalLocation);

            //Execute
            Shop newShop = _shopsRepository.Create(name, physicalLocation);
            _shopsRepository.PartialCommit(); // Generando el id del nuevo elemento.
            Shop? loadedShop = _shopsRepository.Get(newShop.Id);
            _shopsRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedShop);
            Assert.AreEqual(loadedShop.ShopName, name);
            Assert.AreEqual(loadedShop.PhysicalLocationId, physicalLocationId);

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

        [DataRow(3, "TiendaC")]
        [DataRow(4, "TiendaD")]
        [TestMethod]
        public void Can_Update_Shop(int id, string name)
        {
            //Arrange
            _shopsRepository.BeginTransaction();
            var loadedShop = _shopsRepository.Get(id);
            Assert.IsNotNull (loadedShop);

            //Execute
            loadedShop.ShopName = name;
            _shopsRepository.Update(loadedShop);

            // Assert
            var modifyedShop = _shopsRepository.Get(id);
            _shopsRepository.CommitTransaction();


        }

        [DataRow(6)]
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
