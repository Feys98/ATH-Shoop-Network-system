public class Order
{
    public int Id { get; set; }
    public Shop Shop { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public OrderStatus Status { get; set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = null!;
}

public enum OrderStatus
{
    Started,
    InRealization,
    InProgress,
    Finished
}