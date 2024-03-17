using CCM.Domain.Entities.Computers;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.DataAccess.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.DataAccess.Abstract.Computers;

namespace CCM.DataAccess.Tests
{
    [TestClass]
    public class PCTests
    {
        private IPCRepository _pCRepository;

        public PCTests()
        {
            _pCRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow(1,1,1,1)]
        [DataRow(2,2,2,2)]
        [TestMethod]
        public  void Can_Create_PC(int hardDriveId, int microprocesorId, int rAMId, int motherBoardId)
        {
            //Arrange
            _pCRepository.BeginTransaction();

            //Execute
            PC newPC = _pCRepository.Create(hardDriveId, microprocesorId, rAMId, motherBoardId);
            _pCRepository.PartialCommit(); // Generando el id del nuevo elemento.
            PC? loadedPC = _pCRepository.Get(newPC.Id);
            _pCRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedPC);
            Assert.AreEqual(loadedPC.HardDriveId, hardDriveId);
            Assert.AreEqual(loadedPC.MicroprocesorId, microprocesorId);
            Assert.AreEqual(loadedPC.RAMId, rAMId);
            Assert.AreEqual(loadedPC.MotherBoardId, motherBoardId);
        }

        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_PC(int id)
        {
            //Arrange
            _pCRepository.BeginTransaction();

            //Execute
            var loadedPC = _pCRepository.Get(id);
            _pCRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedPC);
        }

        [DataRow(1,2,2,2,2)]
        [DataRow(2,3,3,3,3)]
        [TestMethod]
        public void Can_Update_PC(int id, int hardDriveId, int microprocesorId, int rAMId, int motherBoardId)
        {
            //Arrange
            _pCRepository.BeginTransaction();

            //Execute
            var loadedPC = _pCRepository.Get(id);
            Assert.IsNotNull(loadedPC);
            var newPC = new PC(hardDriveId, microprocesorId, rAMId, motherBoardId) { Id = loadedPC.Id };
            _pCRepository.Update(newPC);
            var modifyedPC = _pCRepository.Get(id);
            _pCRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedPC.HardDriveId, hardDriveId);
            Assert.AreEqual(modifyedPC.MicroprocesorId, microprocesorId);
            Assert.AreEqual(modifyedPC.RAMId, rAMId);
            Assert.AreEqual(modifyedPC.MotherBoardId, motherBoardId);
        }
    }
}
