using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.StaffCatalogue
{
    internal sealed class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("departments");
            HasKey(i => i.Id);
            HasRequired(i => i.Location).WithMany(i => i.Departments).HasForeignKey(i => i.LocationId);
            Property(i => i.Id).HasColumnName("department_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("department_name").HasMaxLength(60).IsRequired();
            Property(i => i.Phone).HasColumnName("department_phone").HasMaxLength(20).IsRequired();
            Property(i => i.LocationId).HasColumnName("location_id");
        }
    }
}
