using CCM.Domain.Entities.Components;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Abstract.Components
{
    /// <summary>
    /// Define las operaciones a realizar en BD con microprocesadores
    /// </summary>
    public interface IMicroprocesorRepository : IRepository
    {
        /// <summary>
        /// Crea un microprocesador en BD
        /// </summary>
        /// <param name="model"></param>
        /// <param name="processorSpeed"></param>
        /// <param name="brand"></param>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        Microprocesor Create(string model, int processorSpeed, string brand, ConnectionType connectionType);
        /// <summary>
        /// Obtiene un microprocesador de BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Microprocesor? Get(int id);
        /// <summary>
        /// Actualiza el valor de un microprocesador en BD
        /// </summary>
        /// <param name="microprocesor"></param>
        void Update(Microprocesor microprocesor);
        /// <summary>
        /// Elimina un microprocesador de BD
        /// </summary>
        /// <param name="microprocesor"></param>
        void Delete(Microprocesor microprocesor);
    }
}
