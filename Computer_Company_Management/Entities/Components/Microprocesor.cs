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
    /// Modela el microprocesador de la PC
    /// </summary>
    public class Microprocesor : Entity, IBrand
    {
        #region Properties
        /// <summary>
        /// Modelo del microprocesador
        /// </summary>
        public string Model { get; init; }
        /// <summary>
        /// Velocidad del microprocesador en Gigahertz
        /// </summary>
        public double ProcessorSpeed { get; init; }
        /// <summary>
        /// Tipo de conexión del microprocesador
        /// </summary>
        public ConnectionType ConnectionType { get; init; }
        /// <summary>
        /// Marca del microprocesador
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
        protected Microprocesor() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Microprocesor"/>
        /// </summary>
        /// <param name="model">Modelo del microprocesador</param>
        /// <param name="processorSpeed">Velocidad del microprcoesador en gigahertz</param>
        /// <param name="brand">Marca del microprocesador</param>
        /// <param name="connectionType">Tipo de conexión del microprcoesador</param>
        public Microprocesor(string model, double processorSpeed, string brand, ConnectionType connectionType)
        {
            Model = model;
            ProcessorSpeed = processorSpeed;
            Brand = brand;
            ConnectionType = connectionType;
        }
        #endregion

    }
}
