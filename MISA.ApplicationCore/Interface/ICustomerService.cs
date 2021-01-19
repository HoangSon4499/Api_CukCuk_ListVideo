using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerService : IBaseService<Customer>
    {
        /// <summary>
        /// lấy dữ liệu phân trang
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// created By: NHSON(19-01-2021)
        IEnumerable<Customer> GetCustomerPaging(int limit, int offset);

        /// <summary>
        /// lấy dữ liệu khách hàng theo nhóm
        /// </summary>
        /// <param name="groupId">id nhóm khách hàng</param>
        /// <returns></returns>
        /// created By: NHSON(19-01-2021)
        IEnumerable<Customer> GetCustomersByGroup(Guid groupId);
    }
}
