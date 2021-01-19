using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerRepository2 : ICustomerRepository
    {
        public int Add(Customer employee)
        {
            throw new NotImplementedException();
        }

        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByCode(string customerCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Customer GetEntityById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Customer GetEntityByProperty(string propertyName, object propertyValue)
        {
            throw new NotImplementedException();
        }

        public int Update(Customer employee)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

    }
}
