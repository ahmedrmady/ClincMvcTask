using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Interfaces.Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        
       Task <IReadOnlyList<T>> GetAll();

       Task <IReadOnlyList<T>> GetAllWithFilter();

        IQueryable<T> GetTheRawQuery();

    }
}
