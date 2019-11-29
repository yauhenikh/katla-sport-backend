namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class EmployeeListItem
    {
        /// <summary>
        /// Gets or sets an employee ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets an employee first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets an employee last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets an employee address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets an ID for the employee chief.
        /// </summary>
        public int? ReportsToId { get; set; }

        /// <summary>
        /// Gets or sets an ID for the employee position.
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Gets or sets an ID for the employee department.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets a document count.
        /// </summary>
        public int DocumentCount { get; set; }
    }
}
