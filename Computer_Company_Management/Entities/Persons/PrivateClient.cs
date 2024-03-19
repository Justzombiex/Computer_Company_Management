using CCM.Domain.Abstract;
using ComputerCompany.Domain.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela un cliente privado.
    /// </summary>
    public class PrivateClient : Person
    {
        private static readonly PhysicalLocation location;

        /// <summary>
        /// Inicializa un cliente privado
        /// </summary>
        /// <param name="cI"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        public PrivateClient(string cI, string name) : base(cI, name, location)
        {
        }
    }
}
