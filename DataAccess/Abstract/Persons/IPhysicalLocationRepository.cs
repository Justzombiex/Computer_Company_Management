﻿using CCM.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Abstract.Persons
{

    /// <summary>
    /// Define las operaciones a realizar en BD para las ubicaciones físicas.
    /// </summary>
    public interface IPhysicalLocationRepository : IRepository
    {

        /// <summary>
        /// Crea una ubicación física en BD.
        /// </summary>
        /// <param name="country">País.</param>
        /// <param name="city">Ciudad.</param>
        /// <param name="address">Dirección.</param>
        /// <returns>Ubicación creada en BD.</returns>
        PhysicalLocation Create(string country, string city, string address);

        /// <summary>
        /// Obtiene una ubicación física de BD.
        /// </summary>
        /// <param name="id">Identificación de la ubicación.</param>
        /// <returns>Ubicación física de existir en BD, de lo contrario <see langword="null"/></returns>
        PhysicalLocation? Get(int id);

        /// <summary>
        /// Elimina una ubicación de BD.
        /// </summary>
        /// <param name="physicalLocation">Ubicación a eliminar.</param>
        void Delete(PhysicalLocation physicalLocation);

    }
}
