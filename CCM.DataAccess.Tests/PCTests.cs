using CCM.Domain.Entities.Computers;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCM.DataAccess.Abstract.Computers;
using CCM.DataAccess.Abstract.Common;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.DataAccess.Abstract;
using CCM.DataAccess.Abstract.Components;

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

        [DataRow(1,1,1,1,1)]
        [DataRow(2,2,2,2,2)]
        [TestMethod]
        public  void Can_Create_PC(int hardDriveId, int microprocesorId, int rAMId, int motherBoardId, int priceId)
        {
            //Arrange
            _pCRepository.BeginTransaction();
            HardDrive hardDrive = ((IHardDriveRepository)_pCRepository).Get(hardDriveId);
            Assert.IsNotNull(hardDrive);
            Microprocesor microprocesor = ((IMicroprocesorRepository)_pCRepository).Get(microprocesorId);
            Assert.IsNotNull(microprocesor);
            RAM rAM = ((IRAMRepository)_pCRepository).Get(rAMId);
            Assert.IsNotNull(rAM);
            MotherBoard motherBoard = ((IMotherBoardRepository)_pCRepository).Get(motherBoardId);
            Assert.IsNotNull(motherBoard);
            Price price = ((IPriceRepository)_pCRepository).Get(priceId);
            Assert.IsNotNull(price);


            //Execute
            PC newPC = _pCRepository.Create(hardDrive, microprocesor, rAM, motherBoard, price);
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

        [DataRow(1,3.0)]
        [DataRow(2,4.0)]
        [TestMethod]
        public void Can_Update_PC(int pos, int memorySize )
        {
            //arrange
            _pCRepository.BeginTransaction();
            var pCs = _pCRepository.GetAllPC().ToList();
            Assert.IsNotNull(pCs);
            var pC = pCs.ElementAt(pos);
            Assert.IsNotNull(pC);

            //Execute
            pC.RAM.MemorySize = memorySize;
            _pCRepository.Update(pC);
            _pCRepository.PartialCommit();

            //Assert
            var updatedPC = _pCRepository.Get(pC.Id);
            Assert.IsNotNull(updatedPC);
            Assert.AreEqual(pC.RAMId, updatedPC.RAMId);
            Assert.AreEqual(pC.MotherBoardId, updatedPC.MotherBoardId);
        }

        [DataRow(2)]
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_PC(int pos)
        {
            //Arrange
            _pCRepository.BeginTransaction();
            var pCs = _pCRepository.GetAllPC();
            Assert.IsNotNull(pCs);
            var count = pCs.Count();
            var pC = pCs.ElementAt(pos);
            Assert.IsNotNull(pC);

            //Execute 
            _pCRepository.Delete(pC);
            _pCRepository.PartialCommit();

            //Assert
            pCs = _pCRepository.GetAllPC();
            Assert.AreEqual(count - 1, pCs.Count());
            var deletedpC = _pCRepository.Get(pC.Id);
            _pCRepository.CommitTransaction();
            Assert.IsNull(deletedpC);

        }
    }
}
