using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using OrderSystemHW5.Models;

;

namespace OrderSystemHW5.DAL
{
    /// <summary>
    /// Application database context inherits from IdentityDbContext to include tables
    /// for ASP.NET Core Identity as well as custom entities such as products,
    /// suppliers, orders and order details.
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many between Product and Supplier (no payload)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Suppliers)
                .WithMany(s => s.Products);

            // Configure many-to-many via OrderDetail (with payload)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID);
        }
    }
}
