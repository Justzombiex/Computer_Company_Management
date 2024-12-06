using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Domain.Entities.Companies;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Shops;

namespace CCM.DataAccess.Abstract.Shops
{
    /// <summary>
    /// Define las operaciones que se pueden hacer con las tiendas en BD
    /// </summary>
    public interface IShopsRepository : IRepository
    {
        /// <summary>
        /// Crea una tienda en BD
        /// </summary>
        /// <param name="name">Nombre de la tienda</param>
        /// <param name="address">Direccion de la tienda</param>
        /// <returns></returns>
        Shop Create(string name, PhysicalLocation physicalLocation);
        /// <summary>
        /// Obtiene una Tienda de la BD]]]]]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Shop? Get(int id);
        /// <summary>
        /// Actualiza una tienda en BD
        /// </summary>
        /// <param name="shop"></param>
        void Update (Shop shop);
        /// <summary>
        /// Elinima una tienda de la BD
        /// </summary>
        /// <param name="shop"></param>
        void Delete(Shop shop);
    }
}
