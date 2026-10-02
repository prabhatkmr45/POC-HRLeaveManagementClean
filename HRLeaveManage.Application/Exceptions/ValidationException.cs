using FluentValidation.Results;

namespace HRLeaveManage.Application.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        private ValidationResult validationResult;

        public ValidationException()
        {
        }

        public ValidationException(ValidationResult validationResult)
        {
            this.validationResult = validationResult;
        }

        public ValidationException(string? message) : base(message)
        {
        }

        public ValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}