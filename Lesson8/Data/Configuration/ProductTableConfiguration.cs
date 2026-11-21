using Lesson8.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson8.Data.Configuration;

public class ProductTableConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable("products")
            .HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(p => p.Name)
               .HasColumnName("name")
               .IsRequired();

        builder.Property(p => p.Description)
               .HasColumnName("description");

        builder.Property(p => p.Price)
               .HasColumnName("price")
               .IsRequired();
    }
}