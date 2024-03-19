using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Persons
{
    internal class Worker : Person, Entity
    {
        #region Properties
        string _WorkerID { get; }
        JobType Job { get; set; }
        double Salary { get; set; }
        #endregion

        #region Constructors
        protected Worker() { }
        #endregion
        public Worker(string cI, string name) : base(cI, name)
        {
            _WorkerID = string.Empty;
            Job = JobType.STORECLERK;
            Salary = 0;

        }
    }
}
