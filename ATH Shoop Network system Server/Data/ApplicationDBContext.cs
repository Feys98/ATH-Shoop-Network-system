using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace pdiwta2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductInShop> ProductsInShops { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductInShop>().HasKey(t => new { t.ProductId, t.ShopId });
            builder.Entity<ProductInShop>().HasOne(x => x.Shop).WithMany(x => x.Products).HasForeignKey(x => x.ShopId);

            builder.Entity<Shop>().HasData(
                new Shop { Id = 1, Name = "shop1", Description = "desc1" },
                new Shop { Id = 2, Name = "shop2", Description = "desc2" }
            );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Description = "Desc1", Price = 1.00m },
                new Product { Id = 2, Name = "Product2", Description = "Desc2", Price = 2.00m }
            );

            builder.Entity<ProductInShop>().HasData(
                new ProductInShop { ProductId = 1, PriceInShop = 1.00m, Nazwa = "mój ulubiony w sklepie nr 1", SklepID = 1, ProduktID = 1 }
            );

            builder.Entity<Zamowienie>().HasData(
                new Zamowienie { Id = 1, DataUtworzenia = DateTime.Now, Status = StatusZamowienia.Rozpoczete, SklepId = 1 }
            );

            builder.Entity<SzczegolyZamowienia>().HasData(
                new SzczegolyZamowienia { Id = 1, Cena = 3.33m, Ilosc = 3, ProduktId = 1}
            );
        }
    }
}