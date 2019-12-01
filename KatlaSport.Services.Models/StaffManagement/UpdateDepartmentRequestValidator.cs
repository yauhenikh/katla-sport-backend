using FluentValidation;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateDepartmentRequest"/>.
    /// </summary>
    public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        public UpdateDepartmentRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Phone).Length(3, 20);
            RuleFor(r => r.LocationId).GreaterThan(0);
        }
    }
}
