using Clinic.Core.Interfaces.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Interfaces.UnitOfWork.Conterct
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<bool> SaveChangesAsync();

    }
}
