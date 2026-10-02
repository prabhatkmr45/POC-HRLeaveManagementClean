using AutoMapper;
using HRLeaveManage.Application.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.Feature.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommanHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _imapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveTypeCommanHandler(IMapper imapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._imapper = imapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate the incoming data

            // Convert to domain entity object
            var leaveTypeUpdate = _imapper.Map<HRLeaveManagement.Domain.LeaveType>(request);
            // Update in database
            await _leaveTypeRepository.UpdateAsync(leaveTypeUpdate);
            return Unit.Value;
        }
    }
}
