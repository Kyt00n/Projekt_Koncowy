namespace WebApplication1.Models;

public class Item
{
    public int ItemID { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public int WarehouseID { get; set; } // Foreign Key
    public Warehouse Warehouse { get; set; } // Navigation property
    public List<OrderItem> OrderItems { get; set; }
}