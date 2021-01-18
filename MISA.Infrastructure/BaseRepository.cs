
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {

        #region DECLARE
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        string _tableName;
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

        public int Delete(Guid employeeId)
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

        public TEntity GetEntityById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity employee)
        {
            throw new NotImplementedException();
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
    }
}
