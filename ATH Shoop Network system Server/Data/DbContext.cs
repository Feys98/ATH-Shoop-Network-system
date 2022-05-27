using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ATH_Shoop_Network_system_Server.Data
{
    public class DbContext : IdentityDbContext
    {
        //public DbContext() { }
        public DbContext(DbContextOptions options) : base(options) { }
        public DbSet<Shop> Shops { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductInShop> ProductInShops { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetails> OrdersDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInShop>()
                .HasKey(ps => new { ps.ProductId, ps.ShopId });

            modelBuilder.Entity<Shop>()
                .HasMany(p => p.Products);

            modelBuilder.Entity<Shop>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .HasKey(pr => pr.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}