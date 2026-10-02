using FluentValidation;
using HRLeaveManage.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.Feature.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository) 
        {
            this._leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.");
            RuleFor(p => p.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
            RuleFor(q=>q)
                .MustAsync(LeaveTypeNameMustBeUnique)
                .WithMessage("Leave type name must be unique.");
        }

        private async Task<bool> LeaveTypeNameMustBeUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            var leaveTypes = await _leaveTypeRepository.ISLeaveTypeUnique(command.Name);
            return leaveTypes;
        }
    }
}
