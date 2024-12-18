﻿using CCM.DataAccess.Abstract.Clients;
using CCM.DataAccess.Abstract;
using CCM.DataAccess.Concrete;
using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IClientRepository
    {
        public EnterpriseClient CreateEnterpriseClient(string brand, PhysicalLocation location)
        {
            EnterpriseClient enterpriseClient = new EnterpriseClient(brand, location);
            _context.Add(enterpriseClient);
            return enterpriseClient;
        }

        public PrivateClient CreatePrivateClient(string idNumber, string name = "", int age = -1)
        {
            PrivateClient privateClient = new PrivateClient(idNumber, name, age);
            _context.Add(privateClient);
            return privateClient;
        }

        public void Delete(Client client)
        {
            _context.Remove(client);
        }

        public T? GetClient<T>(int id) where T : Client
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Set<Client>().ToList();
        }

        public void Update(Client client)
        {
            _context.Set<Client>().Update(client);
        }
    }
}
