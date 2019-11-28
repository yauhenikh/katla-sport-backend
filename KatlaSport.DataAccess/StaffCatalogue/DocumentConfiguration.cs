using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.StaffCatalogue
{
    internal sealed class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            ToTable("documents");
            HasKey(i => i.Id);
            HasRequired(i => i.Employee).WithMany(i => i.Documents).HasForeignKey(i => i.EmployeeId);
            Property(i => i.Id).HasColumnName("document_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.FileName).HasColumnName("document_filename").IsRequired();
            Property(i => i.Title).HasColumnName("document_title").HasMaxLength(60).IsRequired();
            Property(i => i.DocumentData).HasColumnName("document_data");
            Property(i => i.EmployeeId).HasColumnName("employee_id");
        }
    }
}
