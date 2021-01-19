using MISA.ApplicationCore.Emuns;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion
        #region Method
        //public override int Add(Customer entity)
        //{
        //    // Validate thông tin
        //    var isValid = true;
        //    // 1. check trùng mã khách hàng
        //    var CustomerDuplicate = _customerRepository.GetCustomerByCode(entity.CustomerCode);
        //    if(CustomerDuplicate != null)
        //    {
        //        isValid = false;
        //    }
        //    // logic validate
        //    if (isValid==true)
        //    {
        //    return base.Add(entity);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByGroup(Guid deparmentId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


