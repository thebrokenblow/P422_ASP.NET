using Lesson8.Data.Configuration;
using Lesson8.Model;
using Microsoft.EntityFrameworkCore;

namespace Lesson8.Data;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductTableConfiguration());
    }
}
