namespace ATH_Shoop_Network_system.Models.Product
{
    public class ProductDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public List<ProductViewModel> Products { get; set; } = null!;

    }
}
