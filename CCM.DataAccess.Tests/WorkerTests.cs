using CCM.DataAccess.Abstract.Persons;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.Domain.Entities.Persons;
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
    public class WorkerTests
    {
        private IWorkerRepository _workerRepository;

        public WorkerTests()
        {
            _workerRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }
        /// <summary>
        /// Prueba para Crear un Trabajador
        /// </summary>
        /// <param name="workerid">ID del trabajador</param>
        /// <param name="job">Ocupacion</param>
        /// <param name="salary">Salario</param>
        [DataRow("ABC001", JobType.STORECLERK, 20.00)]
        [DataRow("DEF002", JobType.CLEANING, 10.00)]
        [TestCategory("CreateTests"), TestMethod]
        public void Can_Create_Worker(string workerid, JobType job, double salary)
        {
            //crear
            _workerRepository.BeginTransaction();
            //ejecutar
            Worker newWorker = _workerRepository.Create(workerid, job, salary);
            _workerRepository.PartialCommit();//Generando un nuevo ID
            Worker? loadedWorker = _workerRepository.Get(newWorker.Id);
            _workerRepository.CommitTransaction();
            //Assert
            Assert.IsNotNull(loadedWorker);
            Assert.IsNotNull(loadedWorker._WorkerID, workerid);
            Assert.AreEqual(loadedWorker.Job, job);
            Assert.AreEqual(loadedWorker.Salary, salary);

        }
        /// <summary>
        /// Prueba para Obtener un trabajador
        /// </summary>
        /// <param name="id"></param>
        [DataRow(1)]
        [DataRow(2)]
        [TestCategory("GetTests"), TestMethod]
        public void Can_Get_Worker(int id)
        {
            _workerRepository.BeginTransaction();

            var loadedWorker = _workerRepository.Get(id);
            _workerRepository.CommitTransaction();

            Assert.IsNotNull(loadedWorker);
        }
        /// <summary>
        /// Prueba para actualizar el trabajador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workerid"></param>
        /// <param name="job"></param>
        /// <param name="salary"></param>
        [DataRow(1, JobType.MANAGER, 30.00)]
        [DataRow(2, JobType.TECHNICIAN, 40.00)]
        [TestCategory("UpdateTests"), TestMethod]
        public void Can_Update_Worker(int id, JobType job, double salary)
        {
            //Arrange
            _workerRepository.BeginTransaction();
            var loadedWorker = _workerRepository.Get(id);
            Assert.IsNotNull(loadedWorker);

            //Execute
            loadedWorker.Job = job;
            loadedWorker.Salary = salary;
            _workerRepository.Update(loadedWorker);

            // Assert
            var modifyedShop = _workerRepository.Get(id);
            _workerRepository.CommitTransaction();
        }

        /// <summary>
        /// Prueba para Borrar un trabajador
        /// </summary>
        /// <param name="id"></param>
        [DataRow(1)]
        [TestCategory("WipeTests"), TestMethod]
        public void Can_Delete_Worker(int id)
        {
            _workerRepository.BeginTransaction();

            var loadedWorker = _workerRepository.Get(id);
            Assert.IsNotNull(loadedWorker);
            _workerRepository.Delete(loadedWorker);
            _workerRepository.PartialCommit();
            loadedWorker = _workerRepository.Get(id);
            _workerRepository.CommitTransaction();

            Assert.IsNull(loadedWorker);
        }

    }
}
