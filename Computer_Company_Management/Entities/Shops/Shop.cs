using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Companies;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Shops
{
    /// <summary>
    /// Modela una Tienda
    /// </summary>
    public class Shop : Entity
    {
        #region Properties
        /// <summary>
        /// Nombre de la tienda
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// Ubicación geográfica de la tienda.
        /// </summary>
        public PhysicalLocation Location { get; init; }

        /// <summary>
        /// Lista de productos en la tienda
        /// </summary>
        [NotMapped]
        public List<PC> Products { get; set; }

        /// <summary>
        /// Trabajadores en la Tienda
        /// </summary>
        [NotMapped]
        public List<Worker> Workers { get; set; }

        /// <summary>
        /// Compañía a la que pertenece la tienda
        /// </summary>
        [NotMapped]
        public Company company { get; set; }
        #endregion

        #region IDs
        
        /// <summary>
        /// Id de la localización
        /// </summary>
        public int PhysicalLocationId { get; protected set; }
        /// <summary>
        /// ID de la compañía a la que pertenece la tienda
        /// </summary>
        public int CompanyId { get; protected set; } 

        #endregion

        #region Constructors
        /// <summary>
        /// Para Migraciones
        /// </summary>
        protected Shop () {}

        /// <summary>
        /// Crea una tienda  <see cref="Shop"/>
        /// </summary>
        /// <param name="name">Nombre de la tienda</param>
        /// <param name="location">Ubicación geográfica de la tienda.</param>
        public Shop (string name, PhysicalLocation location)
        {
            ShopName = name;
            Location = location;
            PhysicalLocationId = location.Id; 
        }
        #endregion


    }
}
