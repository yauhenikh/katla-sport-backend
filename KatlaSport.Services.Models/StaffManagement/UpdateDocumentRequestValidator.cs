using FluentValidation;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateDocumentRequest"/>.
    /// </summary>
    public class UpdateDocumentRequestValidator : AbstractValidator<UpdateDocumentRequest>
    {
        public UpdateDocumentRequestValidator()
        {
            RuleFor(r => r.FileName).MinimumLength(1);
            RuleFor(r => r.Title).Length(4, 60);
            RuleFor(r => r.EmployeeId).GreaterThan(0);
        }
    }
}
