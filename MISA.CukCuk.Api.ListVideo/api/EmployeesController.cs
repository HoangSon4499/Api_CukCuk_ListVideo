﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.api
{
    public class EmployeesController : BaseEntityController<Employee>
    {
        IBaseService<Employee> _baseService;
        public EmployeesController(IBaseService<Employee> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
