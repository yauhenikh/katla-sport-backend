namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a department.
    /// </summary>
    public class DepartmentListItem
    {
        /// <summary>
        /// Gets or sets a department ID.
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Gets or sets an employee count.
        /// </summary>
        public int EmployeeCount { get; set; }
    }
}
