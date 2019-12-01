using System;
using FluentValidation;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateEmployeeRequest"/>.
    /// </summary>
    public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeRequestValidator()
        {
            RuleFor(r => r.FirstName).Length(1, 30);
            RuleFor(r => r.LastName).Length(1, 30);
            RuleFor(r => r.BirthDate).LessThan(DateTime.Now);
            RuleFor(r => r.HireDate).GreaterThan(r => r.BirthDate).LessThan(DateTime.Now);
            RuleFor(r => r.EndDate).GreaterThan(r => r.HireDate);
            RuleFor(r => r.Address).Length(5, 100);
            RuleFor(r => r.Salary).GreaterThan(0);
            RuleFor(r => r.ReportsToId).GreaterThan(0);
            RuleFor(r => r.PositionId).GreaterThan(0);
            RuleFor(r => r.DepartmentId).GreaterThan(0);
        }
    }
}
