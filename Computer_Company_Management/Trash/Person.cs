using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    public abstract class Person
    {
        #region Properties
        /// <summary>
        /// Nombre de la persona
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Carnet de Identidad
        /// </summary>
        public string CI { get; }
        /// <summary>
        /// Direccion de la persona
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Edad de la persona
        /// </summary>
        public int Age { get; set; }
        #endregion

        /// <summary>
        /// Inicializa un objeto <see cref="Person"/>
        /// </summary>
        /// <param name="cI">Carnet de Identidad</param>
        /// <param name="name">Nombre de la persona</param>
        public Person(string cI, string name)
        {
            CI = cI;
            Name = name;
            Age = 0;
            Address = string.Empty;
        }
    }
}
