using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Parts.Domain.Entities;
using Parts.Persistence.Constants;

namespace Parts.Persistence.Configurations;
internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable(TableNames.Supplier);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(250).IsRequired(true);
        builder.HasOne(x => x.Country)
            .WithMany(x => x.Suppliers)
            .HasForeignKey(x => x.CountryId);
        builder.HasMany(x => x.Products)
            .WithOne(x => x.Supplier)
            .HasForeignKey(x => x.SupplierId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
