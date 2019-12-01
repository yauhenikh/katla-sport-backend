using FluentValidation;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdatePositionRequest"/>.
    /// </summary>
    public class UpdatePositionRequestValidator : AbstractValidator<UpdatePositionRequest>
    {
        public UpdatePositionRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
        }
    }
}
