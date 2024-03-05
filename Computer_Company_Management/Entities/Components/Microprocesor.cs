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
    /// Modela el microprocesador de la PC
    /// </summary>
    public class Microprocesor : Entity, IBrand
    {
        #region Properties
        /// <summary>
        /// Modelo del microprocesador
        /// </summary>
        public string Model { get; }
        /// <summary>
        /// Velocidad del microprocesador
        /// </summary>
        public int ProcessorSpeed { get; }
        /// <summary>
        /// Tipo de conexión del microprocesador
        /// </summary>
        public ConnectionType ConnectionType { get; }
        /// <summary>
        /// Marca del microprocesador
        /// </summary>
        public string Brand { get; }
        /// <summary>
        /// Identificador de la PC
        /// </summary>
        public int PCId;

        #endregion

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Microprocesor() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Microprocesor"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="processorSpeed"></param>
        /// <param name="brand"></param>
        /// <param name="connectionType"></param>
        public Microprocesor(string model, int processorSpeed, string brand, ConnectionType connectionType)
        {
            Model = model;
            ProcessorSpeed = processorSpeed;
            Brand = brand;
            ConnectionType = connectionType;
        }
        #endregion

    }
}
