using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.StaffCatalogue
{
    internal sealed class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("employees");
            HasKey(i => i.Id);
            HasOptional(i => i.ReportsTo).WithMany(i => i.Subordinates).HasForeignKey(i => i.ReportsToId);
            HasRequired(i => i.Position).WithMany(i => i.Employees).HasForeignKey(i => i.PositionId);
            HasRequired(i => i.Department).WithMany(i => i.Employees).HasForeignKey(i => i.DepartmentId);
            Property(i => i.Id).HasColumnName("employee_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.FirstName).HasColumnName("employee_first_name").HasMaxLength(30).IsRequired();
            Property(i => i.LastName).HasColumnName("employee_last_name").HasMaxLength(30).IsRequired();
            Property(i => i.BirthDate).HasColumnName("employee_birth_date").IsRequired();
            Property(i => i.HireDate).HasColumnName("employee_hire_date").IsRequired();
            Property(i => i.EndDate).HasColumnName("employee_end_date").IsOptional();
            Property(i => i.Address).HasColumnName("employee_address").HasMaxLength(100).IsRequired();
            Property(i => i.Salary).HasColumnName("employee_salary").IsRequired();
            Property(i => i.ReportsToId).HasColumnName("reports_to_id").IsOptional();
            Property(i => i.PositionId).HasColumnName("position_id");
            Property(i => i.DepartmentId).HasColumnName("department_id");
        }
    }
}
