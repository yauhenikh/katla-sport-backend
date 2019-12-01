using FluentValidation.Attributes;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a request for creating and updating a department.
    /// </summary>
    [Validator(typeof(UpdateDepartmentRequestValidator))]
    public class UpdateDepartmentRequest
    {
        /// <summary>
        /// Gets or sets a department name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a department phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets an ID for the location where the department is located.
        /// </summary>
        public int LocationId { get; set; }
    }
}
