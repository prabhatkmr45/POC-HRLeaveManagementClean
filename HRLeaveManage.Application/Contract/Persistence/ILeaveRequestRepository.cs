using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.Contract.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
    }
}
