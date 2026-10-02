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
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDataBaseContext hrDataBaseContext) : base(hrDataBaseContext)
        {
                
        }
        public async Task<bool> ISLeaveTypeUnique(string name)
        {
           return await _hrDataBaseContext.LeaveTypes.AnyAsync(q=>q.Name == name);
        }
    }
}
