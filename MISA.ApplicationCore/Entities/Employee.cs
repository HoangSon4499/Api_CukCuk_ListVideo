using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// thông tin nhân viên
    /// </summary>
    public class Employee
    {
        #region Property
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// mã chức vụ
        /// </summary>
        public Guid PositionGroupId { get; set; }

        /// <summary>
        /// mã phòng ban
        /// </summary>
        public Guid DepartmentGroupId { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// địa chỉ email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày thành lâp
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người thành lập
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// ngày sử đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa đổi
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
