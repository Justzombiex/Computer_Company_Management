using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Shops;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CCM.Domain.Entities.Companies
{
    /// <summary>
    /// Modela una Compañia
    /// </summary>
    public class Company : Entity
    {
        #region Properties
        public string CompanyName { get; set; }
        /// <summary>
        /// Arreglo de Tiendas que tiene la compañia
        /// </summary>
        [NotMapped]
        public List <Shop> Shops{ get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkRequerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Company () {}
       /// <summary>
       /// Crea una compañía
       /// </summary>
       /// <param name="name">Nombre de la compañía</param>
        public Company(string name)
        {
            CompanyName = name;
            Shops = new List<Shop>();
        }
       #endregion
    }
}
