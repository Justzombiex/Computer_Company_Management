﻿using CCM.Domain.Entities.Common;
using CCM.DataAccess.Abstract;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Abstract.Common
{
    /// <summary>
    /// Define las operaciones a realizar en BD con precios.
    /// </summary>
    public interface IPriceRepository : IRepository
    {
        /// <summary>
        /// Crea un precio en BD.
        /// </summary>
        /// <param name="currency">Tipo de moneda del precio.</param>
        /// <param name="value">Valor del precio.</param>
        /// <returns>Precio creado en BD.</returns>
        Price Create(MoneyType currency, double value);

        /// <summary>
        /// Obtiene un precio de BD.
        /// </summary>
        /// <param name="id">Identificador del precio.</param>
        /// <returns>Precio solicitado de existir en BD, de lo contrario <see langword="null"/>.</returns>
        Price? Get(int id);

        /// <summary>
        /// Actualiza el valor de un precio en BD.
        /// </summary>
        /// <param name="price">Precio a actualizar.</param>
        void Update(Price price);

        /// <summary>
        /// Elimina un precio de BD.
        /// </summary>
        /// <param name="price">Precio a eliminar.</param>
        void Delete(Price price);

    }
}
