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

        /// <summary>
        /// Prueba para crear un microprocesador
        /// </summary>
        /// <param name="model">Modelo del microprocesador</param>
        /// <param name="processorSpeed">Velocidad de procesamiento del microprocesador</param>
        /// <param name="brand">Marca del microprocesador</param>
        /// <param name="connectionType">Tipo de conexión del microprocesador</param>
        [DataRow("Core i3", 2, "Intel", ConnectionType.PGA )]
        [DataRow("Core i7", 2, "Intel", ConnectionType.ZIF)]
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

        /// <summary>
        /// Prueba para obtener un microprocesador
        /// </summary>
        /// <param name="id">Id del microprocesador</param>
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
            Assert.IsNotNull(loadedMicroprocesor);
        }

        /// <summary>
        /// Elimina un microprocesador de BD
        /// </summary>
        /// <param name="id">Identificador del microprocesador a eliminar</param>
        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Microprocesor(int id)
        {
            // Arrange
            _microprocesorRepository.BeginTransaction();

            // Execute
            var loadedMicroprocesor = _microprocesorRepository.Get(id);
            Assert.IsNotNull(loadedMicroprocesor);
            _microprocesorRepository.Delete(loadedMicroprocesor);
            _microprocesorRepository.PartialCommit();
            loadedMicroprocesor = _microprocesorRepository.Get(id);
            _microprocesorRepository.CommitTransaction();

            // Assert
            Assert.IsNull(loadedMicroprocesor);
        }
    }
}
