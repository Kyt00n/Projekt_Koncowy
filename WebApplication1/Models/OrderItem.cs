namespace WebApplication1.Models;

public class OrderItem
{
    public int OrderItemID { get; set; }
    public int OrderID { get; set; } // Foreign Key
    public int ItemID { get; set; } // Foreign Key
    public int QuantityOrdered { get; set; }
    public Order Order { get; set; } // Navigation property
    public Item Item { get; set; }
}