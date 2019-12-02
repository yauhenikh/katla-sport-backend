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
    [RoutePrefix("api/employees")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDocumentService _documentService;

        public EmployeesController(IEmployeeService employeeService, IDocumentService documentService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _documentService = documentService ?? throw new ArgumentNullException(nameof(documentService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of employees.", Type = typeof(EmployeeListItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{employeeId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a employee.", Type = typeof(Employee))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetEmployee(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeAsync(employeeId);
            return Ok(employee);
        }

        [HttpGet]
        [Route("{employeeId:int:min(1)}/documents")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of documents for specified employee.", Type = typeof(DocumentListItem[]))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDocuments(int employeeId)
        {
            var documents = await _documentService.GetDocumentsAsync(employeeId);
            return Ok(documents);
        }

        [HttpGet]
        [Route("{employeeId:int:min(1)}/subordinates")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of subordinates for specified employee.", Type = typeof(EmployeeListItem[]))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSubordinates(int employeeId)
        {
            var subordinates = await _employeeService.GetSubordinateEmployeesAsync(employeeId);
            return Ok(subordinates);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new employee.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddEmployee([FromBody] UpdateEmployeeRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _employeeService.CreateEmployeeAsync(createRequest);
            var location = string.Format("/api/employees/{0}", employee.Id);
            return Created<Employee>(location, employee);
        }

        [HttpPut]
        [Route("{employeeId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed employee.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateEmployee([FromUri] int employeeId, [FromBody] UpdateEmployeeRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeeService.UpdateEmployeeAsync(employeeId, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{employeeId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed employee.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteEmployee([FromUri] int employeeId)
        {
            await _employeeService.DeleteEmployeeAsync(employeeId);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}