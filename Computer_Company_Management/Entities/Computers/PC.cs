using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Shops;

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
        /// Tienda a la que pertenece la PC
        /// </summary>
        [NotMapped]
        public Shop shop { get; set; }

        #endregion

        #region ID
        /// <summary>
        /// Id del disco duro
        /// </summary>
        public int HardDriveId { get; protected set; }
        /// <summary>
        /// Id del disco duro
        /// </summary>
        public int MicroprocesorId { get; protected set; }
        /// <summary>
        /// Id de la Motherboard
        /// </summary>
        public int MotherBoardId { get; protected set; }
        /// <summary>
        /// Id de la RAM
        /// </summary>
        public int RAMId { get; protected set; }
        /// <summary>
        /// Id del precio
        /// </summary>
        public int PriceId { get; protected set; }
        /// ID de la tienda a la que le pertenece
        /// </summary>
        public int ShopID { get; protected set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected PC() { }

        /// <summary>
        /// Inicializa un objeto <see cref="PC"/>
        /// </summary>
        /// <param name="rAM">RAM de la PC</param>
        /// <param name="motherBoard">Microprocesador de la PC</param>
        /// <param name="hardDrive">Disco duro de la PC</param>
        /// <param name="microprocesor">Microprocesador de la PC</param>
        /// <param name="price">Precio de la PC</param>
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
