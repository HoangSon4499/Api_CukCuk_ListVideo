using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Emuns;
using System;
using MISA.CukCuk.Web.api;

namespace MISA.CukCuk.Api.ListVideo.api
{
   
    public class CustomersController : BaseEntityController<Customer>
    {
        IBaseService<Customer> _baseService;
        public CustomersController(IBaseService<Customer> baseService):base(baseService)
        {
            _baseService = baseService;
        }
    }
}
