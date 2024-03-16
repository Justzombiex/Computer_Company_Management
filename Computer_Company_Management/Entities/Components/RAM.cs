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
    /// Modela la memoria RAM de la PC
    /// </summary>
    public class RAM : Entity, IBrand
    {
        #region Properties
        /// <summary>
        /// Tamaño de memoria de la RAM
        /// </summary>
        public int MemorySize { get; set; }
        /// <summary>
        /// Marca de la memoria RAM
        /// </summary>
        public string Brand { get; }
        /// <summary>
        /// Tipo de memoria RAM 
        /// </summary>
        public MemoryType MemoryType { get; }
        /// <summary>
        /// Identificador de la PC
        /// </summary>
        public int PCId;

        #endregion

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected RAM() { }

        /// <summary>
        /// Inicializa un objeto <see cref="RAM"/>
        /// </summary>
        /// <param name="memorySize"></param>
        /// <param name="brand"></param>
        /// <param name="memoryType"></param>
        public RAM(int memorySize, string brand, MemoryType memoryType)           
        {
            MemorySize = memorySize;
            Brand = brand;
            MemoryType = memoryType;
        }
        #endregion
    }
}
