using CCM.DataAccess.Abstract.Clients;
using CCM.DataAccess.Abstract.Persons;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.Domain.Entities.Persons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Tests
{
    [TestClass]
    public class ClientTests
    {

        private IClientRepository _clientRepository;


        public ClientTests()
        {
            _clientRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [TestCategory("CreateTests") , TestMethod]
        [DataRow("021027", "Laura", 21)]
        [DataRow("010203", "Jaime", 22)]
        public void Can_Create_PrivateClient(string cI, string name = "", int age = -1)
        {
            // Arrange
            _clientRepository.BeginTransaction();
            PrivateClient? newClient;
            // Execute

            if (age != -1)
                newClient = _clientRepository.CreatePrivateClient( cI, name, age);
            else
                newClient = _clientRepository.CreatePrivateClient(cI, name);

            _clientRepository.PartialCommit();
            var loadedClient = _clientRepository.GetClient<PrivateClient>(newClient.Id);
            _clientRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedClient);
            Assert.AreEqual(loadedClient.Name, newClient.Name);
            Assert.AreEqual(loadedClient.Age, newClient.Age);
        }

        [TestCategory("CreateTests2"), TestMethod]
        [DataRow("CEDAI", 1)]
        [DataRow("EMSIFARMA", 2)]
        public void Can_Create_EnterpriseClient(string brand, int physicalLocationId)
        {
            // Arrange
            _clientRepository.BeginTransaction();
            var physicalLocation = ((IPhysicalLocationRepository)_clientRepository).Get(physicalLocationId);
            if (physicalLocation is null)
                Assert.Fail();

            // Execute
            var newClient = _clientRepository.CreateEnterpriseClient(brand, physicalLocation);
            _clientRepository.PartialCommit();
            var loadedClient = _clientRepository.GetClient<EnterpriseClient>(newClient.Id);
            _clientRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedClient);
            Assert.AreEqual(loadedClient.Brand, newClient.Brand);
            Assert.AreEqual(loadedClient.Location, physicalLocation);
        }

        [DataRow(4)]
        [TestCategory("GetTests"), TestMethod]
        public void Can_Get_Clients(int count)
        {
            //Arrange
            _clientRepository.BeginTransaction();

            //Execute
            var clients = _clientRepository.GetAll();
            _clientRepository.CommitTransaction();

            // Assert
            Assert.AreEqual(count, clients.Count());
        }

        [DataRow(22, 0)]
        [DataRow(20, 1)]
        [TestCategory("UpdateTests"), TestMethod]
        public void Can_Update_PrivateClient(int age, int pos)
        {
            //Arrange
            _clientRepository.BeginTransaction();
            var clients = _clientRepository.GetAll().OfType<PrivateClient>().ToList();
            Assert.IsNotNull(clients);
            var client = clients.ElementAt(pos);
            Assert.IsNotNull(client);

            //Execute
            client.Age = age;
            _clientRepository.Update(client);
            _clientRepository.PartialCommit();

            //Assert
            var updatedClient = _clientRepository.GetClient<PrivateClient>(client.Id);
            Assert.IsNotNull(updatedClient);
            Assert.AreEqual(updatedClient.Age, age);

        }

        [DataRow("CUJAE", 0)]
        [DataRow("Facebook", 1)]
        [TestCategory("UpdateTests"), TestMethod]
        public void Can_Update_EnterpriseClient(string brand, int pos)
        {
            //Arrange
            _clientRepository.BeginTransaction();
            var clients = _clientRepository.GetAll().OfType<EnterpriseClient>().ToList();
            Assert.IsNotNull(clients);
            var client = clients.ElementAt(pos);
            Assert.IsNotNull(client);

            //Execute
            client.Brand = brand;
            _clientRepository.Update(client);
            _clientRepository.PartialCommit();

            //Assert
            var updatedClient = _clientRepository.GetClient<EnterpriseClient>(client.Id);
            _clientRepository.CommitTransaction();
            Assert.IsNotNull(updatedClient);
            Assert.AreEqual(updatedClient.Brand, brand);

        }

        [DataRow(0)]
        [TestCategory("WipeTests"), TestMethod]
        public void Can_Delete_Client(int pos)
        {
            //Arrange
            _clientRepository.BeginTransaction();
            var clients = _clientRepository.GetAll();
            Assert.IsNotNull(clients);
            var count = clients.Count();
            var client = clients.ElementAt(pos);
            Assert.IsNotNull(client);

            //Execute 
            _clientRepository.Delete(client);
            _clientRepository.PartialCommit();

            //Assert
            clients = _clientRepository.GetAll();
            Assert.AreEqual(count - 1, clients.Count());
            var deletedClient = _clientRepository.GetClient<Client>(client.Id);
            _clientRepository.CommitTransaction();
            Assert.IsNull(deletedClient);

        }
    }
}