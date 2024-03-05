using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Abstract;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Types;

namespace CCM.Domain.Entities.Components
{
    /// <summary>
    /// Modela una Motherboard de la PC
    /// </summary>
    public class MotherBoard : Entity, IBrand
    {
        #region Properties
        /// <summary>
        /// Modela el modelo de la motherboard
        /// </summary>
        public string Model { get; }
        /// <summary>
        /// Marca de la motherboard
        /// </summary>
        public string Brand { get; }
        /// <summary>
        /// Tipo deconexión de la motherboard
        /// </summary>
        public ConnectionType ConnectionType { get; }
        /// <summary>
        /// Identificador de la PC
        /// </summary>
        public int PCId;

        #endregion

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected MotherBoard() { } 

        /// <summary>
        /// Inicializa un objeto <see cref="MotherBoard"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="brand"></param>
        /// <param name="connectionType"></param>
        MotherBoard(string model, string brand, ConnectionType connectionType) 
        { 
            Model = model; 
            Brand = brand;
            ConnectionType = connectionType;
        }
        #endregion
    }
}
