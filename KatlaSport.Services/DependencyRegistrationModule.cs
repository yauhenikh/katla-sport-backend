﻿using Autofac;

namespace KatlaSport.Services
{
    /// <summary>
    /// Represents an assembly dependency registration <see cref="Module"/>.
    /// </summary>
    public class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogueManagement.CatalogueManagementService>().As<CatalogueManagement.ICatalogueManagementService>();
            builder.RegisterType<HiveManagement.HiveService>().As<HiveManagement.IHiveService>();
            builder.RegisterType<HiveAnalytics.HiveAnalysisService>().As<HiveAnalytics.IHiveAnalysisService>();
            builder.RegisterType<CustomerManagement.CustomerManagementService>().As<CustomerManagement.ICustomerManagementService>();
            builder.RegisterType<ProductManagement.ProductCategoryService>().As<ProductManagement.IProductCategoryService>();
            builder.RegisterType<ProductManagement.ProductCatalogueService>().As<ProductManagement.IProductCatalogueService>();
            builder.RegisterType<HiveManagement.HiveService>().As<HiveManagement.IHiveService>();
            builder.RegisterType<HiveManagement.HiveSectionService>().As<HiveManagement.IHiveSectionService>();
            builder.RegisterType<StaffManagement.LocationService>().As<StaffManagement.ILocationService>();
            builder.RegisterType<StaffManagement.DepartmentService>().As<StaffManagement.IDepartmentService>();
            builder.RegisterType<StaffManagement.PositionService>().As<StaffManagement.IPositionService>();
            builder.RegisterType<StaffManagement.EmployeeService>().As<StaffManagement.IEmployeeService>();
            builder.RegisterType<StaffManagement.DocumentService>().As<StaffManagement.IDocumentService>();
            builder.RegisterType<StaffManagement.LocationRepository>().As<StaffManagement.ILocationRepository>();
            builder.RegisterType<UserContext>().As<IUserContext>();
        }
    }
}
