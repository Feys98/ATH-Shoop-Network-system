﻿public class OrderDetails
{
    public int Id { get; set; }
    public virtual Product Product { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}