using AutoMapper;
using HRLeaveManage.Application.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.Feature.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommanHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _imapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommanHandler(IMapper imapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._imapper = imapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate the incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
            // Convert to domain entity object
            var leaveTypeCreate = _imapper.Map<HRLeaveManagement.Domain.LeaveType>(request);
            // Add to database
            var leaveType = await _leaveTypeRepository.CreateAsync(leaveTypeCreate);
            return leaveType.Id;
        }
    }
}
