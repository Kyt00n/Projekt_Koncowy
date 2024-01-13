
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class WebAplicationDbContext : IdentityDbContext<WebApplication1User>
{
    public DbSet<Item> Items { get; set; }
    public DbSet<OrderItem> ItemOrders { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public WebAplicationDbContext(DbContextOptions<WebAplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderID);

        builder.Entity<OrderItem>()
            .HasOne(oi => oi.Item)
            .WithMany()
            .HasForeignKey(oi => oi.ItemID);


        base.OnModelCreating(builder);
    }
    private class ApplicationUserEntityConfiguration :
IEntityTypeConfiguration<WebApplication1User>
    {
        public void Configure(EntityTypeBuilder<WebApplication1User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
        }
    }

}
