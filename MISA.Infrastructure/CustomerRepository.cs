using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        #region DECLARE
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion
        #region Constructor
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectString");
            _dbConnection = new MySqlConnection(_connectionString);
        }

        #endregion
        #region Method
        public int AddCustomer(Customer customer)
        {
            // xử lý các kiểu dữ liệu (mapping dataType)
            var paramters = MappingDataType(customer);
            // thực thi commandText
            var rowaAffects = _dbConnection.Execute("Proc_InsertCustomer", paramters, commandType: CommandType.StoredProcedure);
            // Trả về kết quả ( số bản ghi thêm mới được)
            return rowaAffects;
        }

        public int DeleteCustomer(Guid customerId)
        {
            var res = _dbConnection.Execute("Proc_DeleteCustomerById", new { CustomerID = customerId.ToString()}, commandType: CommandType.StoredProcedure);
            return res;
        }

        public Customer GetCustomerByCode(string customerCode)
        {
            var res = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        public IEnumerable<Customer> GetCustomerById(Guid customerId)
        {
            var customer = _dbConnection.Query<Customer>("Proc_GetCustomerById", new { CustomerID = customerId.ToString() }, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            // kết nối tới CSDL
            // khởi tạo các commandText
            var customers = _dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            // trả về dữ liệu
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {
            // xử lý các kiểu dữ liệu (mapping dataType)
            var paramters = MappingDataType(customer);
            // thực thi commandText
            var rowaAffects = _dbConnection.Execute("Proc_UpdateCustomer", paramters, commandType: CommandType.StoredProcedure);
            // Trả về kết quả ( số bản ghi thêm mới được)
            return rowaAffects;
        }

        /// <summary>
        /// Xử lý dữ liệu kiểu Guid
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters MappingDataType<TEntity>(TEntity entity)
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
        #endregion
    }

}
