using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.Feature.LeaveType.Queries.GetAllLeaveTypes
{
    public record GetLeaveTypesDetailsQuery(int Id) : IRequest<List<LeaveTypeDetailsDto>>;
}
