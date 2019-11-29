namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a location of a department.
    /// </summary>
    public class LocationListItem
    {
        /// <summary>
        /// Gets or sets a location ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a location name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a location country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets a location postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets a department count.
        /// </summary>
        public int DepartmentCount { get; set; }
    }
}
