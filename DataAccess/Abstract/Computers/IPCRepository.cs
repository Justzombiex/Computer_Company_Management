using CCM.Domain.Entities.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Abstract.Computers
{
    /// <summary>
    /// Define las operaciones a realizar en BD con PC
    /// </summary>
    public interface IPCRepository
    {
        /// <summary>
        /// Crea una PC en BD
        /// </summary>
        /// <param name="hardDriveId">Id del Disco duro de la PC</param>
        /// <param name="microprocesorId">Id del Microprocesador de la PC</param>
        /// <param name="rAMId">Id de la RAM de la PC</param>
        /// <param name="motherBoardId">Id de la motherboard de la PC</param>
        /// <returns></returns>
        PC Create(int hardDriveId, int microprocesorId, int rAMId, int motherBoardId);
        /// <summary>
        /// Obtiene un precio de BD
        /// </summary>
        /// <param name="id">Id de la PC</param>
        /// <returns></returns>
        PC? Get(int id);
        /// <summary>
        /// Actualiza el valor de PC en BD
        /// </summary>
        /// <param name="pC">Una PC</param>
        void Update(PC pC);
        /// <summary>
        /// Elimina una PC de BD
        /// </summary>
        /// <param name="pC">Una PC</param>
        void Delete(PC pC);
    }
}
