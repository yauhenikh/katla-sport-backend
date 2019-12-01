using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a department service.
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// Gets a list of departments.
        /// </summary>
        /// <returns>A <see cref="Task{List{DepartmentListItem}}"/>.</returns>
        Task<List<DepartmentListItem>> GetDepartmentsAsync();

        /// <summary>
        /// Gets a department with specified identifier.
        /// </summary>
        /// <param name="departmentId">A department identifier.</param>
        /// <returns>A <see cref="Task{Department}"/>.</returns>
        Task<Department> GetDepartmentAsync(int departmentId);

        /// <summary>
        /// Gets a list of departments for specified location.
        /// </summary>
        /// <param name="locationId">A location identifier.</param>
        /// <returns>A <see cref="Task{List{DepartmentListItem}}"/>.</returns>
        Task<List<DepartmentListItem>> GetDepartmentsAsync(int locationId);

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateDepartmentRequest"/>.</param>
        /// <returns>A <see cref="Task{Department}"/>.</returns>
        Task<Department> CreateDepartmentAsync(UpdateDepartmentRequest createRequest);

        /// <summary>
        /// Updates an existed department.
        /// </summary>
        /// <param name="departmentId">A department identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateDepartmentRequest" />.</param>
        /// <returns>A <see cref="Task{Department}"/></returns>
        Task<Department> UpdateDepartmentAsync(int departmentId, UpdateDepartmentRequest updateRequest);

        /// <summary>
        /// Deletes an existed department.
        /// </summary>
        /// <param name="departmentId">A department identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteDepartmentAsync(int departmentId);
    }
}
