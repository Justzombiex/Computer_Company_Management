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
        /// <param name="model">Modelo de la motherboard</param>
        /// <param name="brand">Marca de la motherboard</param>
        /// <param name="connectionType">Tipo de conexión de la motherboard</param>
        /// <returns></returns>
        MotherBoard Create(string model, string brand, ConnectionType connectionType);
        /// <summary>
        /// Obtiene una motherboard de BD
        /// </summary>
        /// <param name="id">Id de la motherboard</param>
        /// <returns></returns>
        MotherBoard? Get(int id);
        /// <summary>
        /// Actualiza el valor de la motherboard en BD
        /// </summary>
        /// <param name="motherBoard">Una motherboard</param>
        void Update(MotherBoard motherBoard);
        /// <summary>
        /// Elimina una motherboard de BD
        /// </summary>
        /// <param name="motherBoard">Una motherboard</param>
        void Delete(MotherBoard motherBoard);
    }
}
