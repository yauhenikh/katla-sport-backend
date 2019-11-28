namespace KatlaSport.DataAccess.StaffCatalogue
{
    internal sealed class StaffCatalogueContext : DomainContextBase<ApplicationDbContext>, IStaffCatalogueContext
    {
        public StaffCatalogueContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Employee> Employees => GetDbSet<Employee>();

        public IEntitySet<Position> Positions => GetDbSet<Position>();

        public IEntitySet<Document> Documents => GetDbSet<Document>();

        public IEntitySet<Department> Departments => GetDbSet<Department>();

        public IEntitySet<Location> Locations => GetDbSet<Location>();
    }
}
