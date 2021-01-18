using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    public class DepartmentGroup
    {
        public Guid DepartmentGroupId { get; set; }
        public string DepartmentGroupName { get; set; }
        public string Description { get; set; }
    }
}
