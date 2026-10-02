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
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDataBaseContext hrDataBaseContext) : base(hrDataBaseContext)
        {
                
        }
    }
}
