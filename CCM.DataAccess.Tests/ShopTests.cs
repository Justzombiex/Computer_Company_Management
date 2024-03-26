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

        [DataRow("TiendaA", "Calle_51")]
        [DataRow("TiendaB", "Calle_49")]
        [TestMethod]
        public void Can_Create_Shop(string name, int physicalLocationId, int companyId, int pCId, int workerId)
        {
           
            //Arrange
            _shopsRepository.BeginTransaction();
            PhysicalLocation physicalLocation = ((IPhysicalLocationRepository)_shopsRepository).Get(physicalLocationId);
            Assert.IsNotNull(physicalLocation);
            Company company = ((ICompaniesRepository)_shopsRepository).Get(companyId);
            Assert.IsNotNull(company);
            PC pC = ((IPCRepository)_shopsRepository).Get(pCId);
            Assert.IsNotNull(pC);
            Worker worker = ((IWorkerRepository)_shopsRepository).Get(workerId);
            Assert.IsNotNull(company);

            //Execute
            Shop newShop = _shopsRepository.Create(name, physicalLocation, company, pC, worker);
            _shopsRepository.PartialCommit(); // Generando el id del nuevo elemento.
            Shop? loadedShop = _shopsRepository.Get(newShop.Id);
            _shopsRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedShop);
            Assert.AreEqual(loadedShop.ShopName, name);
            Assert.AreEqual(loadedShop.PhysicalLocationId, physicalLocationId);
            Assert.AreEqual(loadedShop.CompanyId, companyId);
            Assert.AreEqual(loadedShop.Products.Find(pCId).Id, pCId);
            Assert.AreEqual(loadedShop.Workers.Find(workerId).Id, workerId);

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
        public void Can_Update_Shop(int id, string name, PhysicalLocation location, Company company, PC pC, Worker worker  )
        {
            _shopsRepository.BeginTransaction();

            var loadedShop = _shopsRepository.Get(id);
            Assert.IsNotNull(loadedShop);
            var newShop = new Shop(name, location, company, pC, worker) { Id = loadedShop.Id };
            _shopsRepository.Update(newShop);
            var modifyedShop = _shopsRepository.Get(id);
            _shopsRepository.CommitTransaction();

            Assert.AreEqual(modifyedShop.ShopName, name);
            Assert.AreEqual(modifyedShop.Location, location);
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
