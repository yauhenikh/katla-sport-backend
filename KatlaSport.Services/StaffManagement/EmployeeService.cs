using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.StaffCatalogue;
using DbEmployee = KatlaSport.DataAccess.StaffCatalogue.Employee;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents an employee service.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IStaffCatalogueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class with specified <see cref="IStaffCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IStaffCatalogueContext"/>.</param>
        public EmployeeService(IStaffCatalogueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<EmployeeListItem>> GetEmployeesAsync()
        {
            var dbEmployees = await _context.Employees.OrderBy(e => e.Id).ToArrayAsync();
            var employees = dbEmployees.Select(e => Mapper.Map<EmployeeListItem>(e)).ToList();

            foreach (EmployeeListItem employee in employees)
            {
                employee.DocumentCount = _context.Documents.Where(d => d.EmployeeId == employee.Id).Count();
            }

            return employees;
        }

        /// <inheritdoc/>
        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            var dbEmployees = await _context.Employees.Where(e => e.Id == employeeId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbEmployee, Employee>(dbEmployees[0]);
        }

        /// <inheritdoc/>
        public async Task<List<EmployeeListItem>> GetPositionEmployeesAsync(int positionId)
        {
            var dbEmployees = await _context.Employees.Where(e => e.PositionId == positionId).OrderBy(e => e.Id).ToArrayAsync();
            var employees = dbEmployees.Select(e => Mapper.Map<EmployeeListItem>(e)).ToList();

            foreach (EmployeeListItem employee in employees)
            {
                employee.DocumentCount = _context.Documents.Where(d => d.EmployeeId == employee.Id).Count();
            }

            return employees;
        }

        /// <inheritdoc/>
        public async Task<List<EmployeeListItem>> GetDepartmentEmployeesAsync(int departmentId)
        {
            var dbEmployees = await _context.Employees.Where(e => e.DepartmentId == departmentId).OrderBy(e => e.Id).ToArrayAsync();
            var employees = dbEmployees.Select(e => Mapper.Map<EmployeeListItem>(e)).ToList();

            foreach (EmployeeListItem employee in employees)
            {
                employee.DocumentCount = _context.Documents.Where(d => d.EmployeeId == employee.Id).Count();
            }

            return employees;
        }

        /// <inheritdoc/>
        public async Task<Employee> CreateEmployeeAsync(UpdateEmployeeRequest createRequest)
        {
            var dbEmployee = Mapper.Map<UpdateEmployeeRequest, DbEmployee>(createRequest);
            _context.Employees.Add(dbEmployee);

            await _context.SaveChangesAsync();

            return Mapper.Map<Employee>(dbEmployee);
        }

        /// <inheritdoc/>
        public async Task<Employee> UpdateEmployeeAsync(int departmentId, UpdateEmployeeRequest updateRequest)
        {
            var dbEmployees = await _context.Employees.Where(e => e.Id == departmentId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];

            Mapper.Map(updateRequest, dbEmployee);

            await _context.SaveChangesAsync();

            return Mapper.Map<Employee>(dbEmployee);
        }

        /// <inheritdoc/>
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var dbEmployees = await _context.Employees.Where(e => e.Id == employeeId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];

            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
