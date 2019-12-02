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
    [RoutePrefix("api/positions")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class PositionsController : ApiController
    {
        private readonly IPositionService _positionService;
        private readonly IEmployeeService _employeeService;

        public PositionsController(IPositionService positionService, IEmployeeService employeeService)
        {
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet]
        [Route("show")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of positions.", Type = typeof(PositionListItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetPositions()
        {
            var positions = await _positionService.GetPositionsAsync();
            return Ok(positions);
        }

        [HttpGet]
        [Route("show/{positionId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a position.", Type = typeof(Position))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetPosition(int positionId)
        {
            var position = await _positionService.GetPositionAsync(positionId);
            return Ok(position);
        }

        [HttpGet]
        [Route("show/{positionId:int:min(1)}/employees")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of employees for specified position.", Type = typeof(EmployeeListItem[]))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetEmployees(int positionId)
        {
            var employees = await _employeeService.GetPositionEmployeesAsync(positionId);
            return Ok(employees);
        }

        [HttpPost]
        [Route("create")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new position.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddPosition([FromBody] UpdatePositionRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var position = await _positionService.CreatePositionAsync(createRequest);
            var location = string.Format("/api/positions/show/{0}", position.Id);
            return Created<Position>(location, position);
        }

        [HttpPost]
        [Route("update/{positionId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed position.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdatePosition([FromUri] int positionId, [FromBody] UpdatePositionRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _positionService.UpdatePositionAsync(positionId, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPost]
        [Route("destroy/{positionId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed position.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeletePosition([FromUri] int positionId)
        {
            await _positionService.DeletePositionAsync(positionId);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}