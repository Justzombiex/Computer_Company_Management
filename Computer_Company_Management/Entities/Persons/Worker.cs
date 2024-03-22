using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    public class Worker
    {
        #region Properties
        /// <summary>
        /// ID del trabajador
        /// </summary>
        string _WorkerID { get; }
        /// <summary>
        /// Ocupacion que esta cubriendo el trabajador
        /// </summary>
        JobType Job { get; set; }
        /// <summary>
        /// Salario que se le entrega al trabajador
        /// </summary>
        double Salary { get; set; }
        #endregion

        #region Constructors
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
