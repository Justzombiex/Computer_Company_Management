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
    public class MicroprocesorTests
    {
        private IMicroprocesorRepository _microprocesorRepository;

        public MicroprocesorTests()
        {
            _microprocesorRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow("Core i3", 2.0, "Intel", ConnectionType.PGA )]
        [DataRow("Core i7", 2.5, "Intel", ConnectionType.ZIF)]
        [TestMethod]
        public void Can_Create_Microprocesor(string model, int processorSpeed, string brand, ConnectionType connectionType)
        {
            //Arrange
            _microprocesorRepository.BeginTransaction();

            //Execute
            Microprocesor newMicroprocesor = _microprocesorRepository.Create(model, processorSpeed, brand, connectionType);
            _microprocesorRepository.PartialCommit(); // Generando el id del nuevo elemento.
            Microprocesor? loadedMicroprocesor = _microprocesorRepository.Get(newMicroprocesor.Id);
            _microprocesorRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedMicroprocesor);
            Assert.AreEqual(loadedMicroprocesor.Model, model);
            Assert.AreEqual(loadedMicroprocesor.ProcessorSpeed, processorSpeed);
            Assert.AreEqual(loadedMicroprocesor.Brand, brand);
            Assert.AreEqual(loadedMicroprocesor.ConnectionType, connectionType);
            

        }

        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Microprocesor(int id)
        {
            //Arrange
            _microprocesorRepository.BeginTransaction();

            //Execute
            var loadedMicroprocesor = _microprocesorRepository.Get(id);
            _microprocesorRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(_microprocesorRepository);
        }

        [DataRow(1, "Core i7", 2.5, "Intel", ConnectionType.ZIF)]
        [DataRow(2, "Core i3", 2.0, "Intel", ConnectionType.PGA)]
        [TestMethod]
        public void Can_Update_Microprocesor(int id, string model, int processorSpeed, string brand, ConnectionType connectionType)
        {
            //Arrange
            _microprocesorRepository.BeginTransaction();

            //Execute
            var loadedMicroprocesor = _microprocesorRepository.Get(id);
            Assert.IsNotNull(loadedMicroprocesor);
            var newMicroprocesor = new Microprocesor(model, processorSpeed, brand, connectionType) { Id = loadedMicroprocesor.Id };
            _microprocesorRepository.Update(newMicroprocesor);
            var modifyedMicroprocesor = _microprocesorRepository.Get(id);
            _microprocesorRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedMicroprocesor.Model, model);
            Assert.AreEqual(modifyedMicroprocesor.ProcessorSpeed, processorSpeed);
            Assert.AreEqual(modifyedMicroprocesor.Brand, brand);
            Assert.AreEqual(modifyedMicroprocesor.ConnectionType, connectionType);
            
        }
    }
}
