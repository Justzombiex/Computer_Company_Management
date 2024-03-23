﻿using CCM.Domain.Entities.Common;
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
        public string ShopName { get; }
        /// <summary>
        /// Localizacion de la tienda
        /// </summary>
        public string ShopAddress { get; } 
        /// <summary>
        /// Lista de productos en la tienda
        /// </summary>
        [NotMapped]
        public List <PC> Products { get; set; }
        /// <summary>
        /// Trabajadores en la Tienda
        /// </summary>
        [NotMapped]
        public List <Worker> Workers { get; set; }
        #endregion

        #region IDs
        /// <summary>
        /// El ID del nombre de la tienda
        /// </summary>
        public int ShopNameID { get; set; } 
        /// <summary>
        /// ID de la direccion de la tienda
        /// </summary>
        public int ShopAddressID { get; set; }
        /// <summary>
        /// ID de la compannia a la que pertenece la tienda
        /// </summary>
        public int CompanyID { get; set; } 

        #endregion

        #region Constructors
        /// <summary>
        /// Para Migraciones
        /// </summary>
        protected Shop () {}
        /// <summary>
        /// Crea una tienda  <see cref="Shop"/>
        /// </summary>
        /// <param name="name">nombre de la tienda</param>
        /// <param name="address">Localizacion de la tienda</param>
        public Shop (string name, string address)
        {
            ShopName = name;   
            ShopAddress = address;
            Products = new List<PC> ();
        }
        #endregion


    }
}
