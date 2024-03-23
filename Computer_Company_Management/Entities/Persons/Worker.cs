﻿using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    /// <summary>
    /// Modela un Trabajador 
    /// </summary>
    public class Worker : Entity
    {
        #region Properties
        /// <summary>
        /// ID del trabajador
        /// </summary>
        string _WorkerID { get; }
        /// <summary>
        /// Ocupacion que esta cubriendo el trabajador
        /// </summary>
        [NotMapped]
        JobType Job { get; set; }
        /// <summary>
        /// Salario que se le entrega al trabajador
        /// </summary>
        double Salary { get; set; }
        #endregion

        #region IDs
        /// <summary>
        /// ID del Trabajador
        /// </summary>
        public int WorkerID { get; set; }   
        /// <summary>
        /// ID del tipo de trabajo
        /// </summary>
        public int JobID { get; set; } 
        /// <summary>
        /// ID del salario
        /// </summary>
        public int SalaryID { get; set; }  
        /// <summary>
        /// ID de la tienda a la que pertenece el trabajador
        /// </summary>
        public int ShopID { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Para Migraciones
        /// </summary>
        protected Worker () {}
        /// <summary>
        /// Crea un objeto del tipo trabajador <see cref="Worker"/>
        /// </summary>
        /// <param name="workerid">ID del Trabajador</param>
        /// <param name="job">Ocupacion de la persona</param>
        /// <param name="salary">Salario que se le paga</param>
        public Worker(string workerid, JobType job, double salary)
        {
            _WorkerID = workerid;
            Job = job;
            Salary = salary;
        }
        #endregion
    }
}
