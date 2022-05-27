public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public virtual ICollection<ProductInShop> Products { get; set; } = null!;

}