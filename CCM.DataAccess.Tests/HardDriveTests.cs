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

        /// <summary>
        /// Prueba para  crear un disco duro
        /// </summary>
        /// <param name="model">Modelo del disco duro</param>
        /// <param name="brand">Marca del disco duro</param>
        /// <param name="storage">Capacidad dealmacenamiento del disco duro</param>
        /// <param name="connectionHardDriveType">Tipo de conexión del disco duro</param>
        [DataRow("HDD", "Seagate", 2, ConnectionHardDriveType.SATA )]
        [DataRow("SSD", "Toshiba", 3, ConnectionHardDriveType.SATA2)]
        [TestCategory("CreateTests"), TestMethod]
        public void Can_Create_HardDrive(string model, string brand, double storage, ConnectionHardDriveType connectionHardDriveType)
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

        /// <summary>
        /// Prueba para obtener un disco duro
        /// </summary>
        /// <param name="id">Id del disco duro</param>
        [DataRow(1)]
        [DataRow(2)]
        [TestCategory("GetTests"), TestMethod]
        public void Can_Get_HardDrive(int id)
        {
            //Arrange
            _hardDriveRepository.BeginTransaction();

            //Execute
            var loadedHardDrive = _hardDriveRepository.Get(id);
            _hardDriveRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedHardDrive);
        }

        /// <summary>
        /// Elimina un disco duro de BD
        /// </summary>
        /// <param name="id">Identificador del disco duro en BD</param>
        [DataRow(1)]
        [TestCategory("WipeTests"), TestMethod]
        public void Can_Delete_HardDrive(int id)
        {
            // Arrange
            _hardDriveRepository.BeginTransaction();

            // Execute
            var loadedHardDrive = _hardDriveRepository.Get(id);
            Assert.IsNotNull(loadedHardDrive);
            _hardDriveRepository.Delete(loadedHardDrive);
            _hardDriveRepository.PartialCommit();
            loadedHardDrive = _hardDriveRepository.Get(id);
            _hardDriveRepository.CommitTransaction();

            // Assert
            Assert.IsNull(loadedHardDrive);
        }
    }
}