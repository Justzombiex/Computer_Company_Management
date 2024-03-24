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
    public class RAMTests
    {
        private IRAMRepository _rAMRepository;

        public RAMTests()
        {
            _rAMRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        /// <summary>
        /// Prueba para crear una motherboard
        /// </summary>
        /// <param name="memorySize">Capacidad de memoria de la RAM</param>
        /// <param name="brand">Marca de la RAM</param>
        /// <param name="memoryType">Tipo de memoria de la RAM</param>
        [DataRow(16, "Kingston", MemoryType.DDR)]
        [DataRow(8, "Corsair", MemoryType.DDR2)]
        [TestMethod]
        public void Can_Create_MotherBoard(int memorySize, string brand, MemoryType memoryType)
        {
            //Arrange
            _rAMRepository.BeginTransaction();

            //Execute
            RAM newRAM = _rAMRepository.Create(memorySize, brand, memoryType);
            _rAMRepository.PartialCommit(); // Generando el id del nuevo elemento.
            RAM? loadedRAM = _rAMRepository.Get(newRAM.Id);
            _rAMRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedRAM);
            Assert.AreEqual(loadedRAM.Brand, brand);
            Assert.AreEqual(loadedRAM.MemorySize, memorySize);
            Assert.AreEqual(loadedRAM.MemoryType, memoryType);
        }

        /// <summary>
        /// Prueba para obtener una RAM
        /// </summary>
        /// <param name="id">Id de la RAM</param>
        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_RAM(int id)
        {
            //Arrange
            _rAMRepository.BeginTransaction();

            //Execute
            var loadedRAM = _rAMRepository.Get(id);
            _rAMRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedRAM);
        }

        /// <summary>
        /// Prueba para  eliminar una RAM
        /// </summary>
        /// <param name="id">Id de la RAM</param>
        /// <param name="memorySize">Capacidad de memoria de la RAM</param>
        /// <param name="brand">Marca de la RAM</param>
        /// <param name="memoryType">Tipo de memoria de la RAM</param>
        [DataRow(1, 4.0, "Corsair", MemoryType.DDR2)]
        [DataRow(2, 6.0, "Kingston", MemoryType.DDR )]
        [TestMethod]
        public void Can_Update_RAM(int id, int memorySize, string brand, MemoryType memoryType)
        {
            //Arrange
            _rAMRepository.BeginTransaction();

            //Execute
            var loadedRAM = _rAMRepository.Get(id);
            Assert.IsNotNull(loadedRAM);
            var newRAM = new RAM(memorySize, brand, memoryType) { Id = loadedRAM.Id };
            _rAMRepository.Update(newRAM);
            var modifyedRAM = _rAMRepository.Get(id);
            _rAMRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedRAM.Brand, brand);
            Assert.AreEqual(modifyedRAM.MemorySize, memorySize);
            Assert.AreEqual(modifyedRAM.MemoryType, memoryType);
            
        }
    }
}
