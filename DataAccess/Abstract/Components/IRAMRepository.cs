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
    /// Define las operaciones a realizar en BD con RAM
    /// </summary>
    public interface IRAMRepository : IRepository
    {
        /// <summary>
        /// Crea una RAM en BD
        /// </summary>
        /// <param name="memorySize"></param>
        /// <param name="brand"></param>
        /// <param name="memoryType"></param>
        /// <returns></returns>
        RAM Create(int memorySize, string brand, MemoryType memoryType);
        /// <summary>
        /// Obtiene una RAM de BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RAM? Get(int id);
        /// <summary>
        /// Actualiza el valor de una RAM en BD
        /// </summary>
        /// <param name="rAM"></param>
        void Update(RAM rAM);
        /// <summary>
        /// Elimina una RAM de BD
        /// </summary>
        /// <param name="rAM"></param>
        void Delete(RAM rAM);

    }
}
