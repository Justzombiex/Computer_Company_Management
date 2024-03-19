using CCM.Domain.Abstract;
using CCM.Domain.Entities.Types;
using ComputerCompany.Domain.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela a un trabajador.
    /// </summary>
    public class Worker : Person
    {

        #region Properties
        /// <summary>
        /// Son los tipos de trabajo que puede tener una persona en la tienda
        /// </summary>
        JobType Job { get; set; }
        /// <summary>
        /// salario de un trabajador
        /// </summary>
        double Salary { get; set; }
        #endregion

        /// <summary>
        /// Constructor de la clase trabajador
        /// </summary>
        /// <param name="cI"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        public Worker(string cI, string name, PhysicalLocation location) : base(cI, name, location)
        {
        }
    }
}