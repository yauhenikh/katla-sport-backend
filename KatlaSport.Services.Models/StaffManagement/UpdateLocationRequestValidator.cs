using FluentValidation;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateLocationRequest"/>.
    /// </summary>
    public class UpdateLocationRequestValidator : AbstractValidator<UpdateLocationRequest>
    {
        public UpdateLocationRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Country).Length(2, 30);
            RuleFor(r => r.Address).Length(5, 100);
            RuleFor(r => r.PostalCode).Length(2, 10);
        }
    }
}
