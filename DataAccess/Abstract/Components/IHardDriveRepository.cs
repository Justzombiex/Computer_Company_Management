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
        /// <param name="model">Modelo del disco duro</param>
        /// <param name="brand">Marca del disco duro</param>
        /// <param name="storage">Capacidad de almacenamiento del disco duro</param>
        /// <param name="connectionHardDriveType">Tipo de conexión del disco duro</param>
        /// <returns>Disco duro creado en BD</returns>
        HardDrive Create(string model, string brand, float storage, ConnectionHardDriveType connectionHardDriveType);
        /// <summary>
        /// Obtiene un disco duro de BD.
        /// </summary>
        /// <param name="id">Id del disco duro</param>
        /// <returns>Disco Duro solicitado de existir en BD, de lo contrario <see langword="null"/>.</returns>
        HardDrive? Get(int id);
        /// <summary>
        /// Actualiza el valor de un disco duro en BD.
        /// </summary>
        /// <param name="hardDrive">Disco duro</param>
        void Update(HardDrive hardDrive);
        /// <summary>
        /// Elimina un disco duro de BD
        /// </summary>
        /// <param name="hardDrive">Disco duro</param>
        void Delete(HardDrive hardDrive);
    }
}
