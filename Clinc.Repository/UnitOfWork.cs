using Clinc.Repository.Data;
using Clinc.Repository.Repository;
using Clinic.Core.Interfaces.Repository.Contract;
using Clinic.Core.Interfaces.UnitOfWork.Conterct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinc.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Hashtable Repositories;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            Repositories = new Hashtable();
        }
        public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();
        

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;

            if (!Repositories.ContainsKey(key))
            {
                var Repository = new GenericRepository<TEntity>(_context);

                Repositories.Add(key, Repository);
            }

            return Repositories[key] as IGenericRepository<TEntity>;
        }

        public async Task<bool> SaveChangesAsync()
        =>  await _context.SaveChangesAsync()>0;
        
    }
}
