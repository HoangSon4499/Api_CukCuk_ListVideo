using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:BaseEntity
    {
        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode = Emuns.MISACode.Sucess };
        }
        public virtual ServiceResult Add(TEntity entity)
        {
            entity.EntityState = Emuns.EntitySate.AddNew;
            //thực hiện validate
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
                _serviceResult.MISACode = Emuns.MISACode.IsValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
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

        public ServiceResult Update(TEntity entity)
        {
            entity.EntityState = Emuns.EntitySate.Update;
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.MISACode = Emuns.MISACode.IsValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        private bool Validate(TEntity entity)
        {
            var mesArrayErro = new List<string>();
            var isValidate = true;
            // đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                // Kiểm tra xem có attribute cần phải validate không
                if (property.IsDefined(typeof(Required), false))
                {
                    // check bắt buộc nhập
                    if (propertyValue == null)
                    {
                        isValidate = false;
                        mesArrayErro.Add($"Thông tin {displayName} không được phép để trống");
                        _serviceResult.MISACode = Emuns.MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    // check trùng dữ liệu
                    var propertyName = property.Name;
                    var entityDuplicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDuplicate != null)
                    {
                        isValidate = false;
                        mesArrayErro.Add($"Thông tin {displayName} đã có trên hệ thống");
                        _serviceResult.MISACode = Emuns.MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                    }
                }
            }
            _serviceResult.Data = mesArrayErro;
            return isValidate;
        }
    }
}
