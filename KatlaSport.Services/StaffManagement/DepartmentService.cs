using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.StaffCatalogue;
using DbDepartment = KatlaSport.DataAccess.StaffCatalogue.Department;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a department service.
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        private readonly IStaffCatalogueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class with specified <see cref="IStaffCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IStaffCatalogueContext"/>.</param>
        public DepartmentService(IStaffCatalogueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<DepartmentListItem>> GetDepartmentsAsync()
        {
            var dbDepartments = await _context.Departments.OrderBy(d => d.Id).ToArrayAsync();
            var departments = dbDepartments.Select(d => Mapper.Map<DepartmentListItem>(d)).ToList();

            foreach (DepartmentListItem department in departments)
            {
                department.EmployeeCount = _context.Employees.Where(e => e.DepartmentId == department.Id).Count();
            }

            return departments;
        }

        /// <inheritdoc/>
        public async Task<Department> GetDepartmentAsync(int departmentId)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == departmentId).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbDepartment, Department>(dbDepartments[0]);
        }

        /// <inheritdoc/>
        public async Task<List<DepartmentListItem>> GetDepartmentsAsync(int locationId)
        {
            var dbDepartments = await _context.Departments.Where(d => d.LocationId == locationId).OrderBy(d => d.Id).ToArrayAsync();
            var departments = dbDepartments.Select(d => Mapper.Map<DepartmentListItem>(d)).ToList();

            foreach (DepartmentListItem department in departments)
            {
                department.EmployeeCount = _context.Employees.Where(e => e.DepartmentId == department.Id).Count();
            }

            return departments;
        }

        /// <inheritdoc/>
        public async Task<Department> CreateDepartmentAsync(UpdateDepartmentRequest createRequest)
        {
            var dbDepartment = Mapper.Map<UpdateDepartmentRequest, DbDepartment>(createRequest);
            _context.Departments.Add(dbDepartment);

            await _context.SaveChangesAsync();

            return Mapper.Map<Department>(dbDepartment);
        }

        /// <inheritdoc/>
        public async Task<Department> UpdateDepartmentAsync(int departmentId, UpdateDepartmentRequest updateRequest)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == departmentId).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];

            Mapper.Map(updateRequest, dbDepartment);

            await _context.SaveChangesAsync();

            return Mapper.Map<Department>(dbDepartment);
        }

        /// <inheritdoc/>
        public async Task DeleteDepartmentAsync(int departmentId)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == departmentId).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];

            _context.Departments.Remove(dbDepartment);
            await _context.SaveChangesAsync();
        }
    }
}
