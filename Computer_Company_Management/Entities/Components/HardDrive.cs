using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Abstract;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Types;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela el disco duro de la PC
    /// </summary>
    public class HardDrive : Entity, IBrand
    {
        #region Properties
        /// <summary>
        /// Modelo del disco duro
        /// </summary>
        public string Model { get; init; }
        /// <summary>
        /// Capacidad de almacenamiento del disco duro en Terabytes
        /// </summary>
        public double Storage { get; init; } 
        /// <summary>
        /// Tipo de conexión del disco duro
        /// </summary>
        public ConnectionHardDriveType ConnectionHardDriveType { get; init; }
        /// <summary>
        /// Marca del disco duro
        /// </summary>
        public string Brand { get; init; }
        /// <summary>
        /// Identificador de la PC
        /// </summary>
        public int PCId { get; protected set; }
        
        #endregion

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected HardDrive() { }

        /// <summary>
        /// Inicializa un objeto <see cref="HardDrive"/>.
        /// </summary>
        /// <param name="model">Modelo del disco duro</param>
        /// <param name="brand">Marca del disco duro</param>
        /// <param name="storage">Capacidad de almacenamiento del disco duro en TeraBytes</param>
        /// <param name="connectionHardDriveType">Tipo de conexión del disco duro</param>
        public HardDrive(string model, string brand, double storage, ConnectionHardDriveType connectionHardDriveType ) 
        { 
            Model = model; 
            Brand = brand; 
            Storage = storage;
            ConnectionHardDriveType = connectionHardDriveType;
        }
        #endregion
    }
}
