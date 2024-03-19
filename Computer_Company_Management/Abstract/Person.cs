using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Persons;
using ComputerCompany.Domain.Entities.People;

namespace CCM.Domain.Abstract
{ 
    public abstract class Person
    {
        #region Properties
        public string Name { get; set; }
        /// <summary>
        /// Carnet de Identidad
        /// </summary>
        public string CI { get; }
        /// <summary>
        /// Edad de la persona
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Ubicación geográfica de la sede de la empresa cliente.
        /// </summary>
        public PhysicalLocation Location { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa un objeto <see cref="Person"/>
        /// </summary>
        /// <param name="cI">Carnet de Idad</param>
        /// <param name="name">Nombre de la persona</param>
        public Person(string cI, string name, PhysicalLocation location)
        {
            CI = cI;
            Name = name;
            Location = location;
        }

        protected Person(string cI, string name)
        {
            CI = cI;
            Name = name;
        }
        #endregion
    }
}
