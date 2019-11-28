using System.Collections.Generic;

namespace KatlaSport.DataAccess.StaffCatalogue
{
    /// <summary>
    /// Represents a position of an employee.
    /// </summary>
    public class Position
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
        /// Gets or sets a collection of employees for the position.
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
