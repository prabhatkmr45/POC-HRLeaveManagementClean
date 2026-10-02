using AutoMapper;
using HRLeaveManage.Application.Contract.Persistence;
using HRLeaveManage.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.Feature.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommanHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommanHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate the incoming data


            // Retrieve the leave type from the database
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            // Check if the leave type exists
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            // Delete the leave type from the database
            await _leaveTypeRepository.DeleteAsync(leaveType);
            return Unit.Value;
        }
    }
}
