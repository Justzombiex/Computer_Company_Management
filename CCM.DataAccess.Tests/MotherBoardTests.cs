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
    public class MotherBoardTests
    {
        private IMotherBoardRepository _motherBoardRepository;

        public MotherBoardTests()
        {
            _motherBoardRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        /// <summary>
        /// Prueba para crear una motherboard
        /// </summary>
        /// <param name="model">Moddelo de la motherboard</param>
        /// <param name="brand">Marca de la motherboard</param>
        /// <param name="connectionType">Tipo de conexión de la motherboard</param>
        [DataRow("ROG Strix", "ASUS", ConnectionType.PGA)]
        [DataRow("MAG Z790", "MSI", ConnectionType.ZIF)]
        [TestMethod]
        public void Can_Create_MotherBoard(string model, string brand, ConnectionType connectionType)
        {
            //Arrange
            _motherBoardRepository.BeginTransaction();

            //Execute
            MotherBoard newMotherBoard = _motherBoardRepository.Create(model, brand, connectionType);
            _motherBoardRepository.PartialCommit(); // Generando el id del nuevo elemento.
            MotherBoard? loadedMotherBoard = _motherBoardRepository.Get(newMotherBoard.Id);
            _motherBoardRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedMotherBoard);
            Assert.AreEqual(loadedMotherBoard.Model, model);
            Assert.AreEqual(loadedMotherBoard.Brand, brand);
            Assert.AreEqual(loadedMotherBoard.ConnectionType, connectionType);
        }

        /// <summary>
        /// Prueba para obtener una motherboard
        /// </summary>
        /// <param name="id">Id de la motherboard</param>
        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_MotherBoard(int id)
        {
            //Arrange
            _motherBoardRepository.BeginTransaction();

            //Execute
            var loadedMotherBoard = _motherBoardRepository.Get(id);
            _motherBoardRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedMotherBoard);
        }

        /// <summary>
        /// Elimina una motherboard de BD
        /// </summary>
        /// <param name="id">Identificador de la motherboard en BD</param>
        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_MotherBoard(int id)
        {
            // Arrange
            _motherBoardRepository.BeginTransaction();

            // Execute
            var loadedMotherBoard = _motherBoardRepository.Get(id);
            Assert.IsNotNull(loadedMotherBoard);
            _motherBoardRepository.Delete(loadedMotherBoard);
            _motherBoardRepository.PartialCommit();
            loadedMotherBoard = _motherBoardRepository.Get(id);
            _motherBoardRepository.CommitTransaction();

            // Assert
            Assert.IsNull(loadedMotherBoard);
        }
    }
}
