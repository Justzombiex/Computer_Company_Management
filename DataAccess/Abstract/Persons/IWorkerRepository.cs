using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Abstract.Persons
{
    /// <summary>
    /// Define las operaciones a realizar en BD con los trabajadores
    /// </summary>
    public interface IWorkerRepository : IRepository
    {
        /// <summary>
        /// crea un trabajador en BD
        /// </summary>
        /// <param name="workerid">ID del trabajador</param>
        /// <param name="job">Ocupacion del trabajador</param>
        /// <param name="salary">Salario</param>
        /// <returns>Trabajador creado en BD</returns>
        Worker Create(string workerid, JobType job, double salary);
        /// <summary>
        /// Obtiene un trabajador de la BD
        /// </summary>
        /// <param name="id">ID del trabajador</param>
        /// <returns>Trabajador solicitado de existir en BD, de lo contrario <see langword="null"/> </returns>
        Worker? Get(int id);
        /// <summary>
        /// Actualiza los datos del trabajador en BD
        /// </summary>
        /// <param name="worker">Trabajador a actualizar</param>
        void Update(Worker worker);
        /// <summary>
        /// Elimina un Trabajador
        /// </summary>
        /// <param name="worker">Trabajador a eliminar de la BD</param>
        void Delete(Worker worker);
    }
}
