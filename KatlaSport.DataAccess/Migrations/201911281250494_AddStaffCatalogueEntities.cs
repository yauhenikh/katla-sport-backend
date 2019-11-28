namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Add staff catalogue entities (position, location, department, employee, document).
    /// </summary>
    public partial class AddStaffCatalogueEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.departments",
                c => new
                    {
                        department_id = c.Int(nullable: false, identity: true),
                        department_name = c.String(nullable: false, maxLength: 60),
                        department_phone = c.String(nullable: false, maxLength: 20),
                        location_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.department_id)
                .ForeignKey("dbo.locations", t => t.location_id, cascadeDelete: true)
                .Index(t => t.location_id);

            CreateTable(
                "dbo.employees",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        employee_first_name = c.String(nullable: false, maxLength: 30),
                        employee_last_name = c.String(nullable: false, maxLength: 30),
                        employee_birth_date = c.DateTime(nullable: false),
                        employee_hire_date = c.DateTime(nullable: false),
                        employee_end_date = c.DateTime(),
                        employee_address = c.String(nullable: false, maxLength: 100),
                        employee_salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        reports_to_id = c.Int(),
                        position_id = c.Int(nullable: false),
                        department_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.employee_id)
                .ForeignKey("dbo.departments", t => t.department_id, cascadeDelete: true)
                .ForeignKey("dbo.positions", t => t.position_id, cascadeDelete: true)
                .ForeignKey("dbo.employees", t => t.reports_to_id)
                .Index(t => t.reports_to_id)
                .Index(t => t.position_id)
                .Index(t => t.department_id);

            CreateTable(
                "dbo.documents",
                c => new
                    {
                        document_id = c.Int(nullable: false, identity: true),
                        document_filename = c.String(nullable: false),
                        document_title = c.String(nullable: false, maxLength: 60),
                        document_data = c.Binary(),
                        employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.document_id)
                .ForeignKey("dbo.employees", t => t.employee_id, cascadeDelete: true)
                .Index(t => t.employee_id);

            CreateTable(
                "dbo.positions",
                c => new
                    {
                        position_id = c.Int(nullable: false, identity: true),
                        position_name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.position_id);

            CreateTable(
                "dbo.locations",
                c => new
                    {
                        location_id = c.Int(nullable: false, identity: true),
                        location_name = c.String(nullable: false, maxLength: 60),
                        location_country = c.String(nullable: false, maxLength: 30),
                        location_address = c.String(nullable: false, maxLength: 100),
                        location_postal_code = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.location_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.departments", "location_id", "dbo.locations");
            DropForeignKey("dbo.employees", "reports_to_id", "dbo.employees");
            DropForeignKey("dbo.employees", "position_id", "dbo.positions");
            DropForeignKey("dbo.documents", "employee_id", "dbo.employees");
            DropForeignKey("dbo.employees", "department_id", "dbo.departments");
            DropIndex("dbo.documents", new[] { "employee_id" });
            DropIndex("dbo.employees", new[] { "department_id" });
            DropIndex("dbo.employees", new[] { "position_id" });
            DropIndex("dbo.employees", new[] { "reports_to_id" });
            DropIndex("dbo.departments", new[] { "location_id" });
            DropTable("dbo.locations");
            DropTable("dbo.positions");
            DropTable("dbo.documents");
            DropTable("dbo.employees");
            DropTable("dbo.departments");
        }
    }
}
