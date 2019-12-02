using AutoMapper;
using DataAccessDepartment = KatlaSport.DataAccess.StaffCatalogue.Department;
using DataAccessDocument = KatlaSport.DataAccess.StaffCatalogue.Document;
using DataAccessEmployee = KatlaSport.DataAccess.StaffCatalogue.Employee;
using DataAccessLocation = KatlaSport.DataAccess.StaffCatalogue.Location;
using DataAccessPosition = KatlaSport.DataAccess.StaffCatalogue.Position;

namespace KatlaSport.Services.StaffManagement
{
    public sealed class StaffManagementMappingProfile : Profile
    {
        public StaffManagementMappingProfile()
        {
            CreateMap<DataAccessLocation, LocationListItem>();
            CreateMap<DataAccessLocation, Location>();
            CreateMap<UpdateLocationRequest, DataAccessLocation>();
            CreateMap<DataAccessDepartment, DepartmentListItem>();
            CreateMap<DataAccessDepartment, Department>();
            CreateMap<UpdateDepartmentRequest, DataAccessDepartment>();
            CreateMap<DataAccessPosition, PositionListItem>();
            CreateMap<DataAccessPosition, Position>();
            CreateMap<UpdatePositionRequest, DataAccessPosition>();
            CreateMap<DataAccessEmployee, EmployeeListItem>();
            CreateMap<DataAccessEmployee, Employee>();
            CreateMap<UpdateEmployeeRequest, DataAccessEmployee>();
            CreateMap<DataAccessDocument, DocumentListItem>();
            CreateMap<DataAccessDocument, Document>();
            CreateMap<UpdateDocumentRequest, DataAccessDocument>();
        }
    }
}
