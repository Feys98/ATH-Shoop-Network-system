namespace ATH_Shoop_Network_system_Server.Data;
public class Seeder
{
    public static async Task Seed(DbContext context)
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        if (context.Shops.Any())
        {
            return;
        }

        List<Product> products = new()
        {
            new()
            {
                Name = "Product 1",
                Description = "Description of product 1",
                Price = 3.30m,
            },
            new()
            {
                Name = "Product 2",
                Description = "Description of product 2",
                Price = 4.50m,
            },
            new()
            {
                Name = "Product 3",
                Description = "Description of product 3",
                Price = 5.60m,
            },
        };
        List<Shop> shops = new List<Shop>()
        {
            new ()
            {
                Name = "Shop1",
                Description = "Description of shop 1",
                Products = new List<ProductInShop>
                {
                    new()
                    {
                        ProductId = 1,
                        PriceInShop = 5.00m
                    }
                }
            },
            new ()
            {
                Name = "Shop2",
                Description = "Description of shop 2",
                Products = new List<ProductInShop>
                {
                    new()
                    {
                        ProductId = 2,
                        PriceInShop = 6.00m
                    }
                }
            },
            new ()
            {
                Name = "Shop3",
                Description = "Description of shop 3",
                Products = new List<ProductInShop>
                {
                    new()
                    {
                        ProductId = 3,
                        PriceInShop = 7.00m
                    }
                }
            },
        };

        await context.AddRangeAsync(products);
        await context.AddRangeAsync(shops);
        await context.SaveChangesAsync();
    }
}
