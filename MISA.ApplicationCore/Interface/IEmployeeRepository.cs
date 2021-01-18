﻿using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(Guid employeeId);
        Employee GetEmployeeByCode(string employeeCode);
        int AddtEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(Guid employeeId);
    }
}
