using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.StaffCatalogue
{
    internal sealed class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            ToTable("positions");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("position_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("position_name").HasMaxLength(60).IsRequired();
        }
    }
}
