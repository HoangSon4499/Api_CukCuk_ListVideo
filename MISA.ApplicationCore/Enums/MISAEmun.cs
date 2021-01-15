using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Emuns
{
    /// <summary>
    /// MISACode xác định trạng thái của việc validate
    /// </summary>
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        NotValid = 900,

        /// <summary>
        /// Thành công
        /// </summary>
        Sucess = 200
    }
}
