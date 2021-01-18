using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Customer> GetCustomerById(Guid customerId);
        ServiceResult AddCustomer(Customer customer);
        ServiceResult UpdateCustomer(Customer customer);
        ServiceResult DeleteCustomer(Guid customerId);
    }
}
