using CCM.DataAccess.Abstract.Companies;
using CCM.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : ICompaniesRepository
    {
        public Company Create(string name)
        {
            Company company = new Company(name);
            _context.Add(company);
            return company;
        }

        public void Delete(Company company)
        {
            _context.Remove(company);
        }

        public void Update(Company company)
        {
            _context.Update(company); 
        }

        Company? ICompaniesRepository.Get(int id)
        {
            return _context.Set<Company>().Find(id);
        }
    }
}
