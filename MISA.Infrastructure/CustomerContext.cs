using Dapper;
using MISA.ApplicationCore.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerContext
    {
        #region Method
        // lấy toàn bộ danh sách khách hàng
        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>List danh sách khách hàng</returns>
        /// created by: NHSON(15-01-2021)
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

        // thêm mới khách hàng
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">object khách hàng</param>
        /// <returns>số bản ghi bị ảnh hưởng</returns>
        /// created by: NHSON(15-01-2021)
        public int InsertCustomer(Customer customer)
        {
            // kết nối tới DB
            var connectionString = "Host=103.124.92.43;" +
                             "Port= 3306;" +
                             "Database=MISACukCuk_MF659_NHSON;" +
                             "User Id=nvmanh;" +
                             "Password=12345678";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // xử lý các kiểu dữ liệu(mapping dataType)
            var properties = customer.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyVulue = property.GetValue(customer);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyVulue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyVulue);
                }
            }

            // thực thi commandText
            var rowAffects = dbConnection.Execute("Proc_InsertCustomer", parameters, commandType: CommandType.StoredProcedure);
            // Trả về kết qủa(số bản ghi thêm mới được)
            return rowAffects;
        }

        // lấy thông tin khách hàng theo mã khách hàng
        /// <summary>
        /// Lấy khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">mã khách hàng</param>
        /// <returns>object khach hàng đầu tiên lấy được</returns>
        /// created by:NHSON(15-01-2021)
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
        // sửa thông tin khách hàng

        // xóa khách hàng theo khóa chính
        #endregion
    }
}

