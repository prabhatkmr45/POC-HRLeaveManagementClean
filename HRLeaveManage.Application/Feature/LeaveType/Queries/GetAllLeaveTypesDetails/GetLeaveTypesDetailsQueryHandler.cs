using AutoMapper;
using HRLeaveManage.Application.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.Feature.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesDetailsQueryHandler : IRequestHandler<GetLeaveTypesDetailsQuery, List<LeaveTypeDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypesDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper= mapper; 
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDetailsDto>> Handle(GetLeaveTypesDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database to get all leave types
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            // Map the leave types to LeaveTypeDto
            var data = _mapper.Map<List<LeaveTypeDetailsDto>>(leaveType);
            return data;
        }
    }
}
