using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Common;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela una persona natural cliente de la tienda de computadoras.
    /// </summary>
    public class PrivateClient : Client
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
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected PrivateClient() { }

        /// <summary>
        /// Inicializa un cliente regular de la tienda de computadoras
        /// </summary>
        /// <param name="cI"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public PrivateClient(string cI, string name = "", int age = -1)
        {
        }
        #endregion
    }
}
