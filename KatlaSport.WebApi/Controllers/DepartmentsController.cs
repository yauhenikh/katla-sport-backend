using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.StaffManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/departments")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public DepartmentsController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of departments.", Type = typeof(DepartmentListItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet]
        [Route("{departmentId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a department.", Type = typeof(Department))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDepartment(int departmentId)
        {
            var department = await _departmentService.GetDepartmentAsync(departmentId);
            return Ok(department);
        }

        [HttpGet]
        [Route("{departmentId:int:min(1)}/employees")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of employees for specified department.", Type = typeof(EmployeeListItem[]))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDepartments(int departmentId)
        {
            var employees = await _employeeService.GetDepartmentEmployeesAsync(departmentId);
            return Ok(employees);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddDepartment([FromBody] UpdateDepartmentRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = await _departmentService.CreateDepartmentAsync(createRequest);
            var location = string.Format("/api/departments/{0}", department.Id);
            return Created<Department>(location, department);
        }

        [HttpPut]
        [Route("{departmentId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateDepartment([FromUri] int departmentId, [FromBody] UpdateDepartmentRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _departmentService.UpdateDepartmentAsync(departmentId, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{departmentId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteDepartment([FromUri] int departmentId)
        {
            await _departmentService.DeleteDepartmentAsync(departmentId);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}