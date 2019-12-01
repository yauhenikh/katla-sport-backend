using FluentValidation.Attributes;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a request for creating and updating a position.
    /// </summary>
    [Validator(typeof(UpdatePositionRequestValidator))]
    public class UpdatePositionRequest
    {
        /// <summary>
        /// Gets or sets a position name.
        /// </summary>
        public string Name { get; set; }
    }
}
