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
        /// <param name="model">Modelo del microprocesador</param>
        /// <param name="processorSpeed">Velocidad del microprocesador</param>
        /// <param name="brand">Marca del microprocesador</param>
        /// <param name="connectionType">Tipo de conexión del microprocesador</param>
        /// <returns>Microprocesador creado en BD</returns>
        Microprocesor Create(string model, int processorSpeed, string brand, ConnectionType connectionType);
        /// <summary>
        /// Obtiene un microprocesador de BD
        /// </summary>
        /// <param name="id">Id del microprocesador</param>
        /// <returns>Microprocesador solicitado de existir en BD, de lo contrario <see langword="null"/></returns>
        Microprocesor? Get(int id);
        /// <summary>
        /// Elimina un microprocesador de BD
        /// </summary>
        /// <param name="microprocesor">Un microprocesador</param>
        void Delete(Microprocesor microprocesor);
    }
}
