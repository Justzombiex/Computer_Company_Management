using CCM.DataAccess.Abstract.Companies;
using CCM.DataAccess.Repositories;
using CCM.DataAccess.Tests.Utilities;
using CCM.Domain.Entities.Companies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Tests
{
    [TestClass]
    public class CompanyTests
    {
        private ICompaniesRepository _companiesRepository;

        public CompanyTests()
        {
            _companiesRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow("Microsoft")]
        [DataRow("Apple")]
        [TestMethod]
        public void Can_Create_Company(string name)
        {
            _companiesRepository.BeginTransaction();

            Company newCompany = _companiesRepository.Create(name);
            _companiesRepository.PartialCommit();
            Company? loadedCompany = _companiesRepository.Get(newCompany.Id);
            _companiesRepository.CommitTransaction();

            Assert.IsNotNull(loadedCompany);
            Assert.AreEqual(loadedCompany.CompanyName, name);
        }

        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Company(int id)
        {
            _companiesRepository.BeginTransaction();

            var loadedCompany = _companiesRepository.Get(id);
            _companiesRepository.CommitTransaction();

            Assert.IsNotNull(loadedCompany);
        }
        
        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Company(int id)
        {
            _companiesRepository.BeginTransaction();

            var loadedCompany = _companiesRepository.Get(id);
            Assert.IsNotNull(loadedCompany);
            _companiesRepository.Delete(loadedCompany);
            _companiesRepository.PartialCommit();
            loadedCompany = _companiesRepository.Get(id);
            _companiesRepository.CommitTransaction();

            Assert.IsNull(loadedCompany);
        }
    }
}
