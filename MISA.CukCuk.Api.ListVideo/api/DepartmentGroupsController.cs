using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.api
{
    public class DepartmentGroupsController : BaseEntityController<DepartmentGroup>
    {
        IBaseService<DepartmentGroup> _baseService;
        public DepartmentGroupsController(IBaseService<DepartmentGroup> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
