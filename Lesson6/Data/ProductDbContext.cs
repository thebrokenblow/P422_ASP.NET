using Lesson6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson6.Data;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }
}
