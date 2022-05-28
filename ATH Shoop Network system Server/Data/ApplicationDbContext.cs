using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATH_Shoop_Network_system_Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
       
    }


    public DbSet<Shop>Shop { get; set; } = null!;
    public DbSet<Product>Product { get; set; } = null!;
    public DbSet<ProductInShop>ProductInShop { get; set; } = null!;
    public DbSet<Order>Order { get; set; } = null!;
    public DbSet<OrderDetails>OrdersDetail { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductInShop>()
            .HasKey(ps => new { ps.ProductId, ps.ShopId });

        modelBuilder.Entity<Shop>()
            .HasMany(p => p.Products);

        modelBuilder.Entity<Shop>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Product>()
            .HasKey(pr => pr.Id);
    }



}
