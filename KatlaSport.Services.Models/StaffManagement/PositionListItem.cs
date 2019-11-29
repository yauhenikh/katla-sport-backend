namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a position of an employee.
    /// </summary>
    public class PositionListItem
    {
        /// <summary>
        /// Gets or sets a position ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a position name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a department count.
        /// </summary>
        public int EmployeeCount { get; set; }
    }
}
