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
        /// <param name="name">Nombre de la Compannia</param>
        /// <returns></returns>
        Company Create(string name);
        /// <summary>
        /// Obtiene una Compañía de la BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Company? Get(int id);
        /// <summary>
        /// Atualiza una Compañía de la BD
        /// </summary>
        /// <param name="company"></param>
        void Update(Company company);   
        /// <summary>
        /// Borra la informacion Compañía de la BD
        /// </summary>
        /// <param name="company"></param>
        void Delete(Company company);    
        
    }
}
