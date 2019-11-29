using System;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class Employee
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
        /// Gets or sets an employee birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets an employee hire date.
        /// </summary>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Gets or sets an employee end date.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets an employee address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets an employee salary.
        /// </summary>
        public decimal Salary { get; set; }

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
    }
}
