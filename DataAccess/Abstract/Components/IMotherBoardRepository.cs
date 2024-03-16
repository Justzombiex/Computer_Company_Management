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
    /// Crea un precio en BD
    /// </summary>
    public interface IMotherBoardRepository : IRepository
    {
        /// <summary>
        /// Crea una motherboard en BD
        /// </summary>
        /// <param name="model"></param>
        /// <param name="brand"></param>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        MotherBoard Create(string model, string brand, ConnectionType connectionType);
        /// <summary>
        /// Obtiene una motherboard de BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MotherBoard? Get(int id);
        /// <summary>
        /// Actualiza el valor de la motherboard en BD
        /// </summary>
        /// <param name="motherBoard"></param>
        void Update(MotherBoard motherBoard);
        /// <summary>
        /// Elimina una motherboard de BD
        /// </summary>
        /// <param name="motherBoard"></param>
        void Delete(MotherBoard motherBoard);
    }
}
