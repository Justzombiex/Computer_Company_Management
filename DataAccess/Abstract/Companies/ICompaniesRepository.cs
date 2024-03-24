using CCM.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Abstract.Companies
{
    /// <summary>
    /// Define las operaciones que se pueden realizar en BD con la informacion de la Compañía
    /// </summary>
    public interface ICompaniesRepository : IRepository
    {
        /// <summary>
        /// Crea una Compañía en la BD
        /// </summary>
        /// <param name="name">Nombre de la Compañía</param>
        /// <returns>Compañía creada en BD</returns>
        Company Create(string name);
        /// <summary>
        /// Obtiene una Compañía de la BD
        /// </summary>
        /// <param name="id">Id de la compañía en BD</param>
        /// <returns>Compañía solicitada de existir en BD, de lo contrario <see langword="null"/>.</returns>
        Company? Get(int id);
        /// <summary>
        /// Atualiza una Compañía de la BD
        /// </summary>
        /// <param name="company">Compañía</param>
        void Update(Company company);   
        /// <summary>
        /// Borra la información Compañía de la BD
        /// </summary>
        /// <param name="company">Compañía</param>
        void Delete(Company company);    
        
    }
}
