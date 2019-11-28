namespace KatlaSport.DataAccess.StaffCatalogue
{
    /// <summary>
    /// Represents a context for staff catalogue domain.
    /// </summary>
    public interface IStaffCatalogueContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Employee"/> entities.
        /// </summary>
        IEntitySet<Employee> Employees { get; }

        /// <summary>
        /// Gets a set of <see cref="Position"/> entities.
        /// </summary>
        IEntitySet<Position> Positions { get; }

        /// <summary>
        /// Gets a set of <see cref="Document"/> entities.
        /// </summary>
        IEntitySet<Document> Documents { get; }

        /// <summary>
        /// Gets a set of <see cref="Department"/> entities.
        /// </summary>
        IEntitySet<Department> Departments { get; }

        /// <summary>
        /// Gets a set of <see cref="Location"/> entities.
        /// </summary>
        IEntitySet<Location> Locations { get; }
    }
}
