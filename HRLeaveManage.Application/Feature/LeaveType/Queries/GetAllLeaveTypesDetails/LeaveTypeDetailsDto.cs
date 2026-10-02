using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.Feature.LeaveType.Queries.GetAllLeaveTypes
{
    public class LeaveTypeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; } = 0;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
