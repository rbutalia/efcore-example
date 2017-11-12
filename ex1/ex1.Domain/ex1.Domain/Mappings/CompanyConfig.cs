
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ex1.Domain.Mappings
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // Primary Key
            builder.HasKey(t => t.CompanyID);

            // Properties
            //builder.Property(t => t.CompanyID)
            //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(t => t.CompanyName)
                .HasMaxLength(30);

            builder.Property(t => t.TextIdentifier)
                .HasMaxLength(8);

            builder.Property(t => t.ContactPersonName)
                .HasMaxLength(30);

            builder.Property(t => t.SalesTax);

            //builder.ToTable("Companies");
            //builder.Property(t => t.CompanyID).HasField("CompanyID");
            //builder.Property(t => t.CompanyName).HasField("CompanyName");
            //builder.Property(t => t.TextIdentifier).HasField("TextIdentifier");
            //builder.Property(t => t.ContactPersonName).HasField("ContactPersonName");
            //builder.Property(t => t.SalesTax).HasField("SalesTax");
            //builder.Property(t => t.CreatedBy).HasField("CreatedBy");
            //builder.Property(t => t.CreatedDate).HasField("CreatedDate");
            //builder.Property(t => t.ModifiedBy).HasField("ModifiedBy");
            //builder.Property(t => t.ModifiedDate).HasField("ModifiedDate");
        }
    }
}
