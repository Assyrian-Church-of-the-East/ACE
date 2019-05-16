using ACE.Repositories.Interfaces;
using ACE.Shared;
using ACE.Shared.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace ACE.Service.Managers
{
    //TODO deletes later
    public abstract class ManagerBase<TEntity>
        where TEntity : class
    {
        private IRepository<TEntity> _repository;
        private IFamilyRepository familyRepository;

        public ManagerBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Get(int id)
        {
            return _repository.GetById(id);
        }

        public EntityEntry<TEntity> Save(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
