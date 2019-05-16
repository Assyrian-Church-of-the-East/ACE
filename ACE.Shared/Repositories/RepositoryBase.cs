using Isg.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACE.Shared.Repositories
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private TContext db;
        private DbSet<TEntity> dbSet;

        public RepositoryBase(TContext context)
        {
            db = context;
            dbSet = db.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet => dbSet;

        public IEnumerable<TEntity> GetAll()
        {
            return Enumerable.ToList(dbSet);
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return dbSet.ToListAsync();
        }

        public virtual TEntity GetById(params object[] Id)
        {
            return dbSet.Find(Id);
        }

        public virtual Task<TEntity> GetByIdAsync(params object[] Id)
        {
            return dbSet.FindAsync(Id);
        }

        public EntityEntry<TEntity> Insert(TEntity obj)
        {
            return dbSet.Add(obj);
        }

        public Task<EntityEntry<TEntity>> InsertAsync(TEntity obj)
        {
            obj.Validate();
            return dbSet.AddAsync(obj);
        }


        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Update(TEntity updatedObject, params object[] id)
        {
            var currentEntity = db.Set<TEntity>().Find(id);
            db.Entry(currentEntity).CurrentValues.SetValues(updatedObject);
            db.Entry(currentEntity).State = EntityState.Modified;
        }

        public void Delete(params object[] Id)
        {
            TEntity getObjById = dbSet.Find(Id);
            dbSet.Remove(getObjById);
        }

        public void DeleteRange(List<TEntity> removeItems)
        {
            dbSet.RemoveRange(removeItems);
        }

        public void DeleteAll()
        {
            dbSet.RemoveRange(dbSet);
        }

        public void Reload(TEntity entity)
        {
            db.Entry(entity).Reload();
        }

        public IEnumerable<TEntity> CheckLocal(Func<TEntity, bool> func)
        {
            return DbSet.Local.Where(func);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}

