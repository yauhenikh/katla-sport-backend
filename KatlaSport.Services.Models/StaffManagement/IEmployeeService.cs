using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents an employee service.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets a list of employees.
        /// </summary>
        /// <returns>A <see cref="Task{List{EmployeeListItem}}"/>.</returns>
        Task<List<EmployeeListItem>> GetEmployeesAsync();

        /// <summary>
        /// Gets a employee with specified identifier.
        /// </summary>
        /// <param name="employeeId">An employee identifier.</param>
        /// <returns>A <see cref="Task{Employee}"/>.</returns>
        Task<Employee> GetEmployeeAsync(int employeeId);

        /// <summary>
        /// Gets a list of employees for specified position.
        /// </summary>
        /// <param name="positionId">A position identifier.</param>
        /// <returns>A <see cref="Task{List{EmployeeListItem}}"/>.</returns>
        Task<List<EmployeeListItem>> GetPositionEmployeesAsync(int positionId);

        /// <summary>
        /// Gets a list of employees for specified department.
        /// </summary>
        /// <param name="departmentId">A department identifier.</param>
        /// <returns>A <see cref="Task{List{EmployeeListItem}}"/>.</returns>
        Task<List<EmployeeListItem>> GetDepartmentEmployeesAsync(int departmentId);

        /// <summary>
        /// Gets a list of subordinate employees for specified employee.
        /// </summary>
        /// <param name="employeeId">An employee identifier.</param>
        /// <returns>A <see cref="Task{List{EmployeeListItem}}"/>.</returns>
        Task<List<EmployeeListItem>> GetSubordinateEmployeesAsync(int employeeId);

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateEmployeeRequest"/>.</param>
        /// <returns>A <see cref="Task{Employee}"/>.</returns>
        Task<Employee> CreateEmployeeAsync(UpdateEmployeeRequest createRequest);

        /// <summary>
        /// Updates an existed employee.
        /// </summary>
        /// <param name="employeeId">An employee identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateEmployeeRequest" />.</param>
        /// <returns>A <see cref="Task{Employee}"/></returns>
        Task<Employee> UpdateEmployeeAsync(int employeeId, UpdateEmployeeRequest updateRequest);

        /// <summary>
        /// Deletes an existed employee.
        /// </summary>
        /// <param name="employeeId">An employee identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteEmployeeAsync(int employeeId);
    }
}
