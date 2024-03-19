using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Company
{
    public class Company
    {
        #region Properties
        public string CompanyName { get; }   
        public List<Shop> Shops { get; set; }

        #endregion
    }
}
