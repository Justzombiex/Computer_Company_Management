using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Common;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela a una persona
    /// </summary>
    public abstract class Person 
    {
        #region Properties
        /// <summary>
        /// Nombre y apellidos de la persona
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Carnet de Identidad
        /// </summary>
        public string CI { get; }
        /// <summary>
        /// Edad de la persona
        /// </summary>
        public int Age { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una persona <see cref="Person"/>
        /// </summary>
        /// <param name="cI">Carnet de Idad</param>
        /// <param name="name">Nombre de la persona</param>
        /// <param name="age">Nombre de la persona</param>
        public Person(string cI, string name = "", int age = -1)
        {
            CI = cI;
            Name = name;
            Age = age;
        }
        #endregion
    }
}

