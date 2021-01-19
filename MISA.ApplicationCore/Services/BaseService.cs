using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository){
            _baseRepository = baseRepository;
        }
        public virtual int Add(TEntity entity)
        {
            var addEntity = _baseRepository.Add(entity);
            return addEntity;
        }

        public int Delete(Guid entityId)
        {
            var deteleEntity = _baseRepository.Delete(entityId);
            return deteleEntity;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

        public TEntity GetEntityById(Guid entityId)
        {
            var entity = _baseRepository.GetEntityById(entityId);
            return entity;
        }

        public int Update(TEntity entity)
        {
            var updateEntity = _baseRepository.Update(entity);
            return updateEntity;
        }
    }
}
