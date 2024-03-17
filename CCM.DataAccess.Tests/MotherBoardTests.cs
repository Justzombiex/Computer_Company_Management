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

        [DataRow(1, "MAG Z790", "MSI", ConnectionType.ZIF)]
        [DataRow(2, "ROG Strix", "ASUS", ConnectionType.PGA)]
        [TestMethod]
        public void Can_Update_MotherBoard(int id, string model, string brand, ConnectionType connectionType)
        {
            //Arrange
            _motherBoardRepository.BeginTransaction();

            //Execute
            var loadedMicroprocesor = _motherBoardRepository.Get(id);
            Assert.IsNotNull(loadedMicroprocesor);
            var newMotherBoard = new MotherBoard(model, brand, connectionType) { Id = loadedMicroprocesor.Id };
            _motherBoardRepository.Update(newMotherBoard);
            var modifyedMotherBoard = _motherBoardRepository.Get(id);
            _motherBoardRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedMotherBoard.Model, model);
            Assert.AreEqual(modifyedMotherBoard.Brand, brand);
            Assert.AreEqual(modifyedMotherBoard.ConnectionType, connectionType);
        }
    }
}
