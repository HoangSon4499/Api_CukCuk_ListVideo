using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.ListVideo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.ListVideo.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {

        /// <summary>
        /// lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// created by: nhson(14/01/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var connectionString = "Host=103.124.92.43;" +
                                "Port= 3306;" +
                                "Database=MISACukCuk_MF659_NHSON;" +
                                "User Id=nvmanh;" +
                                "Password=12345678";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var customer = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            return Ok(customer);
        }

        /// <summary>
        /// lấy dữ liệu khách hàng theo Id
        /// </summary>
        /// <param name="id">id của khách hàng</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var connectionString = "Host=103.124.92.43;" +
                                "Port= 3306;" +
                                "Database=MISACukCuk_MF659_NHSON;" +
                                "User Id=nvmanh;" +
                                "Password=12345678";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var customer = dbConnection.Query<Customer>("Proc_GetCustomerById", new { CustomerID = id }, commandType: CommandType.StoredProcedure);
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            // validate dữ liệu
            // check trường bắt buộc nhập
            var customerCode = customer.CustomerCode;
            if (string.IsNullOrEmpty(customerCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được phép để trống," },
                    useMsg = "Mã khách hàng không được để trống",
                    Code = 999
                };
                return BadRequest(msg);
            }

            // check trùng mã
            var connectionString = "Host=103.124.92.43;" +
                              "Port= 3306;" +
                              "Database=MISACukCuk_MF659_NHSON;" +
                              "User Id=nvmanh;" +
                              "Password=12345678";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var res = dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure);
            if (res.Count() > 0)
            {
                return BadRequest("Mã Khách hàng đã tồn tại");
            }
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

            // thực thi thêm dữ liệu
            var rowAffects = dbConnection.Execute("Proc_InsertCustomer", parameters, commandType: CommandType.StoredProcedure);
            if (rowAffects > 0)
            {
                return Created("thành công", customer);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
