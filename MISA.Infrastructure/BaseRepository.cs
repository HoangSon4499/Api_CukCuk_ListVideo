
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Emuns;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        #region DECLARE
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        protected IDbConnection _dbConnection = null;
        protected string _tableName;
        #endregion
        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }

        #endregion
        public int Add(TEntity entity)
        {
            // xử lý các kiểu dữ liệu (mapping dataType)
            var paramters = MappingDataType(entity);
            // thực thi commandText
            var rowaAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", paramters, commandType: CommandType.StoredProcedure);
            // Trả về kết quả ( số bản ghi thêm mới được)
            return rowaAffects;
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetEntities()
        {
            // khởi tạo các commandText
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            // trả về dữ liệu
            return entities;
        }

        public TEntity GetEntityById(Guid entityId)
        {
            var param = new DynamicParameters();
            param.Add($"{_tableName}Id", dbType: DbType.String, value: entityId.ToString(), direction: ParameterDirection.Input);
            // khởi tạo các commandText
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ById" ,param,commandType: CommandType.StoredProcedure).FirstOrDefault();
            // trả về dữ liệu
            return entities;
        }

        public int Update(TEntity entity)
        {
            // xử lý các kiểu dữ liệu (mapping dataType)
            var paramters = MappingDataType(entity);
            // thực thi commandText
            var rowaAffects = _dbConnection.Execute($"Proc_Update{_tableName}", paramters, commandType: CommandType.StoredProcedure);
            // Trả về kết quả ( số bản ghi thêm mới được)
            return rowaAffects;
        }
        private DynamicParameters MappingDataType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var paramters = new DynamicParameters();

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    paramters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    paramters.Add($"@{propertyName}", propertyValue);
                }
            }
            return paramters;
        }

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntitySate.AddNew)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName}='{propertyValue}'";
            }
            else if (entity.EntityState == EntitySate.Update)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName}='{propertyValue}' AND {_tableName}Id<>'{keyValue}'";
            }
            else
            {
                return null;
            }
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }
    }
}
