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
    [RoutePrefix("api/locations")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class LocationsController : ApiController
    {
        private readonly ILocationService _locationService;
        private readonly IDepartmentService _departmentService;

        public LocationsController(ILocationService locationService, IDepartmentService departmentService)
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of locations.", Type = typeof(LocationListItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetLocations()
        {
            var locations = await _locationService.GetLocationsAsync();
            return Ok(locations);
        }

        [HttpGet]
        [Route("{locationId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a location.", Type = typeof(Location))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetLocation(int locationId)
        {
            var location = await _locationService.GetLocationAsync(locationId);
            return Ok(location);
        }

        [HttpGet]
        [Route("{locationId:int:min(1)}/departments")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of departments for specified location.", Type = typeof(DepartmentListItem[]))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDepartments(int locationId)
        {
            var departments = await _departmentService.GetDepartmentsAsync(locationId);
            return Ok(departments);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new location.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddLocation([FromBody] UpdateLocationRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = await _locationService.CreateLocationAsync(createRequest);
            var address = string.Format("/api/locations/{0}", location.Id);
            return Created<Location>(address, location);
        }

        [HttpPut]
        [Route("{locationId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed location.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateLocation([FromUri] int locationId, [FromBody] UpdateLocationRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _locationService.UpdateLocationAsync(locationId, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{locationId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed location.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteLocation([FromUri] int locationId)
        {
            await _locationService.DeleteLocationAsync(locationId);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}