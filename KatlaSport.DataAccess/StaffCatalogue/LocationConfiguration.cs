using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.StaffCatalogue
{
    internal sealed class LocationConfiguration : EntityTypeConfiguration<Location>
    {
        public LocationConfiguration()
        {
            ToTable("locations");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("location_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("location_name").HasMaxLength(60).IsRequired();
            Property(i => i.Country).HasColumnName("location_country").HasMaxLength(30).IsRequired();
            Property(i => i.Address).HasColumnName("location_address").HasMaxLength(100).IsRequired();
            Property(i => i.PostalCode).HasColumnName("location_postal_code").HasMaxLength(10).IsRequired();
        }
    }
}
