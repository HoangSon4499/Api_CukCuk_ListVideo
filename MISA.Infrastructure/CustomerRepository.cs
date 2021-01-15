using Dapper;
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
        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByCode(string customerCode)
        {
            var connectionString = "Host=103.124.92.43;" +
                                "Port= 3306;" +
                                "Database=MISACukCuk_MF659_NHSON;" +
                                "User Id=nvmanh;" +
                                "Password=12345678";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var res = dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            var connectionString = "Host=103.124.92.43;" +
                                "Port= 3306;" +
                                "Database=MISACukCuk_MF659_NHSON;" +
                                "User Id=nvmanh;" +
                                "Password=12345678";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var customer = dbConnection.Query<Customer>("Proc_GetCustomerById", new { CustomerID = customerId }, commandType: CommandType.StoredProcedure).FirstOrDefault() ;
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            // kết nối tới CSDL
            var connectionString = "Host=103.124.92.43;" +
                                "Port= 3306;" +
                                "Database=MISACukCuk_MF659_NHSON;" +
                                "User Id=nvmanh;" +
                                "Password=12345678";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // khởi tạo các commandText
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            // trả về dữ liệu
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
