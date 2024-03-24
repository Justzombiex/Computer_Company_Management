using CCM.Domain.Entities.Types;
using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Common;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela a un trabajador.
    /// </summary>
    public class Worker : Entity
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
        /// <summary>
        /// Son los tipos de trabajo que puede tener una persona en la tienda
        /// </summary>
        JobType Job { get; set; }

        /// <summary>
        /// salario de un trabajador
        /// </summary>
        double Salary { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Worker() { }

        /// <summary>
        /// Constructor de la clase trabajador
        /// </summary>
        /// <param name="cI"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Worker(string cI, string name = "", int age = -1)
        {
        }
        #endregion
    }
}