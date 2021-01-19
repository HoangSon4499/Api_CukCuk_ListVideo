
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
        /// lấy thông tim khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        ///  created by: NGHSON (18/01/2021)
        Customer GetCustomerByCode(string customerCode);
    }
}
