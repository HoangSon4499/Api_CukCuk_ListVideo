using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region DECLARE
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion
        #region Constructor
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectString");
            _dbConnection = new MySqlConnection(_connectionString);
        }

        #endregion
        public int AddtEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee>GetEmployees()
        {
            // khởi tạo các commandText
            var employees = _dbConnection.Query<Employee>("SELECT * FROM Employee", commandType: CommandType.Text);
            // trả về dữ liệu
            return employees;
        }

        public Employee GetEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
