using Clinc.Repository.Data;
using Clinic.Core.Interfaces.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clinc.Repository.Repository
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity:class 
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Add(TEntity entity)
        =>_context.Add(entity);

        public async Task<TEntity> GetWithFilter(Expression<Func<TEntity, bool>> Criteria)
        =>await _context.Set<TEntity>().Where(Criteria).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<TEntity>> GetAll()
        =>await _context.Set<TEntity>().ToListAsync() ;

        public async Task<IReadOnlyList<TEntity>> GetAllWithFilter(Expression<Func<TEntity,bool>> Criteria, Expression<Func<TEntity, object>>? include =null)
        =>await _context.Set<TEntity>().Where(Criteria).Include(include).ToListAsync() ;

        public IQueryable<TEntity> GetTheRawQuery()
        => _context.Set<TEntity>();
    }
}
