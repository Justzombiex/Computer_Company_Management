using CCM.Domain.Entities.Persons;
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
        /// <param name="memorySize">Tamaño de memoria de la RAM</param>
        /// <param name="brand">Marca de la RAM</param>
        /// <param name="memoryType">Tipo de memoria RAM</param>
        /// <returns>RAM creada en BD</returns>
        RAM Create(int memorySize, string brand, MemoryType memoryType);
        /// <summary>
        /// Obtiene una RAM de BD
        /// </summary>
        /// <param name="id">Id de la RAM</param>
        /// <returns>RAM solicitada de existir en BD, de lo contrario <see langword="null"/> </returns>
        RAM? Get(int id);
        /// <summary>
        /// Elimina una RAM de BD
        /// </summary>
        /// <param name="rAM">Una RAM</param>
        void Delete(RAM rAM);

    }
}
