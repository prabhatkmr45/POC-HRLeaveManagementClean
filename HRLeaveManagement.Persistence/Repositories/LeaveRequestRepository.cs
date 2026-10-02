using HRLeaveManage.Application.Contract.Persistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDataBaseContext hrDataBaseContext) : base(hrDataBaseContext)
        {
                
        }
        
    }
}
