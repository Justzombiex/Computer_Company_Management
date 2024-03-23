using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Components;

namespace CCM.Domain.Entities.Computers
{
    /// <summary>
    /// Modela una computadora
    /// </summary>
    public class PC : Entity
    {
        #region Properties
        /// <summary>
        /// Modela el disco duro de la PC
        /// </summary>
        [NotMapped]
        public HardDrive HardDrive { get; set; }
        /// <summary>
        /// Modela la motherboard de la PC
        /// </summary>
        [NotMapped]
        public MotherBoard MotherBoard { get; set; }
        /// <summary>
        /// Modela el microprocesador de la PC
        /// </summary>
        [NotMapped]
        public Microprocesor Microprocesors { get; set; }
        /// <summary>
        /// Modela la memoria RAM de la PC
        /// </summary>
        [NotMapped]
        public RAM RAM { get; set; }

        /// <summary>
        /// Id del disco duro
        /// </summary>
        public int HardDriveId { get; set; }
        /// <summary>
        /// Id del disco duro
        /// </summary>
        public int MicroprocesorId { get; set; }
        /// <summary>
        /// Id de la Motherboard
        /// </summary>
        public int MotherBoardId { get; set; }
        /// <summary>
        /// Id de la RAM
        /// </summary>
        public int RAMId { get; set; }
        /// <summary>
        /// ID de la tienda a la que le pertenece
        /// </summary>
        public int ShopID { get; set; }

        #endregion 

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected PC() { }

        /// <summary>
        /// Inicializa un objeto <see cref="PC"/>
        /// </summary>
        /// <param name="rAMId">Id de la RAM de la PC</param>
        /// <param name="motherBoardId">Id de la motherboard de la PC </param>
        /// <param name="hardDriveId">Id del dsico duro de la PC</param>
        /// <param name="microprocesorId">Id del microprocesador de la PC</param>
        public PC(int hardDriveId, int microprocesorId, int rAMId, int motherBoardId)
        {
            HardDriveId = hardDriveId;
            MicroprocesorId = microprocesorId;
            MotherBoardId = motherBoardId;
            RAMId = rAMId;
        }
        
        #endregion
    }
}
