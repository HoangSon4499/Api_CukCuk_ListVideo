using MISA.ApplicationCore.Emuns;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class CustomerService: ICustomerService
    {
        ICustomerRepository _customerRepository;
        #region Constructor
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion
        #region Method
        // lấy danh sách khách hàng
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            return customers;
        }
        // thêm mới khách hàng
        public ServiceResult AddCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
            // validate dữ liệu
            // check trường bắt buộc nhập, nếu dữ liệu chưa hợp lệ thì trả về mô tả lỗi
            var customerCode = customer.CustomerCode;
            if (string.IsNullOrEmpty(customerCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được phép để trống," },
                    useMsg = "Mã khách hàng không được để trống",
                    Code = 900
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã Khách hàng không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }

            // check trùng mã
            var res = _customerRepository.GetCustomerByCode(customerCode);
            if (res != null)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng đã tồn tại" },
                    useMsg = "Mã khách đã tồn tại",
                    Code = 900
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã Khách hàng đã tồn tại";
                serviceResult.Data = msg;
                return serviceResult;
            }
            // thêm mới khi dữ liệu đã hợp lệ
            var rowAffects = _customerRepository.AddCustomer(customer);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Thêm thành công";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }

        public IEnumerable<Customer> GetCustomerById(Guid customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            return customer;
        }

        public ServiceResult UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public ServiceResult DeleteCustomer(Guid customerId)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _customerRepository.DeleteCustomer(customerId);
            return serviceResult;
        }

        public Customer GetCustomerByCode(string customerCode)
        {
            var serviceResult = new ServiceResult();
            var customer = _customerRepository.GetCustomerByCode(customerCode);
            return customer;
        }

        #endregion
    }
}


