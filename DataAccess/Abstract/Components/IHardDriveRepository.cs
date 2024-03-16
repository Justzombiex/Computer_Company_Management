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
    /// Define las operaciones a realizar en base de datos con discos duros 
    /// </summary>
    public interface IHardDriveRepository : IRepository
    {
        /// <summary>
        /// Crea un disco duro en BD.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="brand"></param>
        /// <param name="storage"></param>
        /// <param name="connectionHardDriveType"></param>
        /// <returns></returns>
        HardDrive Create(string model, string brand, float storage, ConnectionHardDriveType connectionHardDriveType);
        /// <summary>
        /// Obtiene un disco duro de BD.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HardDrive? Get(int id);
        /// <summary>
        /// Actualiza el valor de un disco duro en BD.
        /// </summary>
        /// <param name="hardDrive"></param>
        void Update(HardDrive hardDrive);
        /// <summary>
        /// Elimina un disco duro de BD
        /// </summary>
        /// <param name="hardDrive"></param>
        void Delete(HardDrive hardDrive);
    }
}
