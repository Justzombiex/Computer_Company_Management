using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Components;
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
    public interface IPCRepository : IRepository
    {
        /// <summary>
        /// Crea una PC en BD
        /// </summary>
        /// <param name="hardDrive">Disco duro de la PC</param>
        /// <param name="microprocesor">Microprocesador de la PC</param>
        /// <param name="rAM">RAM de la PC</param>
        /// <param name="motherBoard">Motherboard de la PC</param>
        /// <returns></returns>
        PC Create(HardDrive hardDrive, Microprocesor microprocesor, RAM rAM, MotherBoard motherBoard, Price price);
        /// <summary>
        /// Obtiene una PC de BD
        /// </summary>
        /// <param name="id">Id de la PC</param>
        /// <returns></returns>
        PC? Get(int id);
        /// <summary>
        /// Obtiene todas las PC de BD.
        /// </summary>
        /// <returns>PC en BD.</returns>
        IEnumerable<PC> GetAllPC();
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
