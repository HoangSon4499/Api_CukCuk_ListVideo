using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Emuns;
using System;

namespace MISA.CukCuk.Api.ListVideo.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// created by: nhson(14/01/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        /// <summary>
        /// lấy dữ liệu khách hàng theo Id
        /// </summary>
        /// <param name="id">id của khách hàng</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var customer = _customerService.GetCustomerById(Guid.Parse(id));
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {

            var serviceResult = _customerService.AddCustomer(customer);
            if(serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0 )
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
