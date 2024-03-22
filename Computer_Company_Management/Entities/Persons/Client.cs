using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    public class Client : Person, Entity
    {
        #region Properties
        public List<PC> Shoppingcart { get; }
        //shopping cart should be able to have a list or different components
        #endregion

        public Client(string cI, string name) : base(cI, name)
        {
            Shoppingcart = new List<PC>();
        }
    }
}
