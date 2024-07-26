using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Interfaces.Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        
       Task <T> GetWithFilter(Expression<Func<T, bool>> Criteria);
       Task <IReadOnlyList<T>> GetAll();

       Task <IReadOnlyList<T>> GetAllWithFilter(Expression<Func<T, bool>> Criteria);

        IQueryable<T> GetTheRawQuery();

    }
}
