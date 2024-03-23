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
        /// Precio de la PC.
        /// </summary>
        [NotMapped]
        public Price Price { get; set; }

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
        /// Id del precio
        /// </summary>
        public int PriceId { get; set; }

        #endregion 

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected PC() { }

        /// <summary>
        /// Inicializa un objeto <see cref="PC"/>
        /// </summary>
        /// <param name="rAM">Id de la RAM de la PC</param>
        /// <param name="motherBoard">Id de la motherboard de la PC </param>
        /// <param name="hardDrive">Id del dsico duro de la PC</param>
        /// <param name="microprocesor">Id del microprocesador de la PC</param>
        public PC(HardDrive hardDrive, Microprocesor microprocesor, RAM rAM, MotherBoard motherBoard, Price price)
        {
            HardDrive = hardDrive;
            Microprocesors = microprocesor;
            RAM = rAM;
            MotherBoard = motherBoard;
            Price = price;
            HardDriveId = hardDrive.Id;
            MicroprocesorId = microprocesor.Id;
            MotherBoardId = motherBoard.Id;
            RAMId = rAM.Id;
            PriceId = price.Id;
        }
        
        #endregion
    }
}
