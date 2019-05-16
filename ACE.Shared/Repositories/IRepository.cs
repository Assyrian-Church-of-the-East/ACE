using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ACE.Shared.Repositories
{
    public interface IRepository
    {

    }
    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity GetById(params object[] Id);
        Task<TEntity> GetByIdAsync(params object[] Id);
        EntityEntry<TEntity> Insert(TEntity obj);
        Task<EntityEntry<TEntity>> InsertAsync(TEntity obj);
        void Update(TEntity obj);
        void Update(TEntity updatedObject, params object[] id);
        void Delete(params object[] Id);

        void DeleteRange(List<TEntity> removeItems);
        void DeleteAll();
        void Reload(TEntity entity);

        IEnumerable<TEntity> CheckLocal(Func<TEntity, bool> func);
    }
}
