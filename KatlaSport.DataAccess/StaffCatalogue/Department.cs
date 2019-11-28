using System.Collections.Generic;

namespace KatlaSport.DataAccess.StaffCatalogue
{
    /// <summary>
    /// Represents a department.
    /// </summary>
    public class Department
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
        /// Gets or sets a location where the department is located.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Gets or sets a collection of employees in the department.
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
