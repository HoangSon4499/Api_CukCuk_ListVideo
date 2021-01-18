
using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    /// <summary>
    /// interface khách hàng
    /// </summary>
    ///  created by: NGHSON (18/01/2021)
    public interface ICustomerRepository
    {
        /// <summary>
        /// lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// created by: NGHSON (18/01/2021)
        IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// lấy thông tin khách hàng theo id khách hàng
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        ///  created by: NGHSON (18/01/2021)
        IEnumerable<Customer> GetCustomerById(Guid customerId);

        /// <summary>
        /// thêm khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        ///  created by: NGHSON (18/01/2021)
        int AddCustomer(Customer customer);

        /// <summary>
        /// sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        ///  created by: NGHSON (18/01/2021)
        int UpdateCustomer(Customer customer);

        /// <summary>
        /// xóa khách hàng
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        ///  created by: NGHSON (18/01/2021)
        int DeleteCustomer(Guid customerId);

        /// <summary>
        /// lấy thông tim khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        ///  created by: NGHSON (18/01/2021)
        Customer GetCustomerByCode(string customerCode);
    }
}
