using System.Data.Entity;
using System.Reflection;
using KatlaSport.DataAccess.CustomerCatalogue;
using KatlaSport.DataAccess.Migrations;
using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.DataAccess.ProductStoreHive;
using KatlaSport.DataAccess.StaffCatalogue;

namespace KatlaSport.DataAccess
{
    /// <summary>
    /// Represents an application database context.
    /// </summary>
    internal sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>(true));

            // DatabaseLogger = databaseLogger;

            // if (DatabaseLogger != null)
            // {
            //    Database.Log = DatabaseLogger.LogDatabaseCall;
            // }
        }

        /// <summary>
        /// Gets or sets a database logger.
        /// </summary>
        public IDatabaseLogger DatabaseLogger { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="ProductCategory"/>.
        /// </summary>
        public DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="CatalogueProduct"/>.
        /// </summary>
        public DbSet<CatalogueProduct> CatalogueProducts { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHive"/>.
        /// </summary>
        public DbSet<StoreHive> StoreHives { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHiveSection"/>.
        /// </summary>
        public DbSet<StoreHiveSection> HiveSections { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreItem"/>.
        /// </summary>
        public DbSet<StoreItem> StoreItems { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHiveSectionCategory"/>.
        /// </summary>
        public DbSet<StoreHiveSectionCategory> SectionCategories { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="Customer"/>.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="Position"/>.
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="Location"/>.
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="Department"/>.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="Employee"/>.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="Document"/>.
        /// </summary>
        public DbSet<Document> Documents { get; set; }

        /// <summary>
        /// Overrides base method.
        /// </summary>
        /// <param name="modelBuilder"><see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
