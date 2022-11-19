using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owner.API.Model;

namespace Owner.DataAccess.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<OwnerModel>
    {
        public void Configure(EntityTypeBuilder<OwnerModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.ToTable("Owners");
        }
    }
}
