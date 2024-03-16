using CCM.DataAccess.Abstract.Components;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.Domain.Entities.Components;
using CCM.Domain.Entities.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Tests
{
    [TestClass]
    public class HardDriveTests
    {
        private IHardDriveRepository _hardDriveRepository;

        public HardDriveTests()
        {
            _hardDriveRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow("HDD", "Seagate", 2.0, ConnectionHardDriveType.SATA )]
        [DataRow("SSD", "Toshiba", 3.0, ConnectionHardDriveType.SATA2)]
        [TestMethod]
        public void Can_Create_HardDrive(string model, string brand, float storage, ConnectionHardDriveType connectionHardDriveType)
        {
            //Arrange
            _hardDriveRepository.BeginTransaction();

            //Execute
            HardDrive newHardDrive = _hardDriveRepository.Create(model, brand, storage, connectionHardDriveType);
            _hardDriveRepository.PartialCommit(); // Generando el id del nuevo elemento.
            HardDrive? loadedHardDrive = _hardDriveRepository.Get(newHardDrive.Id);
            _hardDriveRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedHardDrive);
            Assert.AreEqual(loadedHardDrive.Model, model);
            Assert.AreEqual(loadedHardDrive.Brand, brand);
            Assert.AreEqual(loadedHardDrive.Storage, storage);
            Assert.AreEqual(loadedHardDrive.ConnectionHardDriveType, connectionHardDriveType);
            
        }

        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_HardDrive(int id)
        {
            //Arrange
            _hardDriveRepository.BeginTransaction();

            //Execute
            var loadedHardDrive = _hardDriveRepository.Get(id);
            _hardDriveRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(_hardDriveRepository);
        }

        [DataRow(1, "SSD", "Toshiba", 3.0, ConnectionHardDriveType.SATA2)]
        [DataRow(2, "HDD", "Seagate", 2.0, ConnectionHardDriveType.SATA)]
        [TestMethod]
        public void Can_Update_HardDrive(int id, string model, string brand, float storage, ConnectionHardDriveType connectionHardDriveType)
        {
            //Arrange
            _hardDriveRepository.BeginTransaction();

            //Execute
            var loadedHardDrive = _hardDriveRepository.Get(id);
            Assert.IsNotNull(loadedHardDrive);
            var newHarDrive = new HardDrive(model, brand, storage, connectionHardDriveType) { Id = loadedHardDrive.Id };
            _hardDriveRepository.Update(newHarDrive);
            var modifyedHardDrive = _hardDriveRepository.Get(id);
            _hardDriveRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedHardDrive.Model, model);
            Assert.AreEqual(modifyedHardDrive.Brand, brand);
            Assert.AreEqual(modifyedHardDrive.Storage, storage);
            Assert.AreEqual(modifyedHardDrive.ConnectionHardDriveType, connectionHardDriveType);
        }
    }
}