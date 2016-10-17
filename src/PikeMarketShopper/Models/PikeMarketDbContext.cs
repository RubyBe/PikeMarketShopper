using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PikeMarketShopper.Models
{
  public class PikeMarketDbContext :  IdentityDbContext<ApplicationUser, ApplicationRole, string>
  {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Sentiment> Sentiment { get; set; }
    public DbSet<Shop> Shops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PikeMarketShopper;integrated security=True");
    }

    public PikeMarketDbContext(DbContextOptions<PikeMarketDbContext> options)
            : base(options)
        {
    }

    public PikeMarketDbContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
