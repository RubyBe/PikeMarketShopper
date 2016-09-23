using Microsoft.EntityFrameworkCore;

namespace PikeMarketShopper.Models
{
  public class PikeMarketDbContext : DbContext
  {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Shop> Shops { get; set; }

    public PikeMarketDbContext(DbContextOptions<PikeMarketDbContext> options)
            : base(options)
        {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
