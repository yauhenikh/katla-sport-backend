using FluentValidation.Attributes;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a request for creating and updating a location.
    /// </summary>
    [Validator(typeof(UpdateLocationRequestValidator))]
    public class UpdateLocationRequest
    {
        /// <summary>
        /// Gets or sets a location name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a location country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets a location address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a location postal code.
        /// </summary>
        public string PostalCode { get; set; }
    }
}
