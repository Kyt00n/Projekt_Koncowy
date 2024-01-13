namespace WebApplication1.Models;

public class Warehouse
{
    public int WarehouseID { get; set; }
    public string WarehouseName { get; set; }
    public string Location { get; set; }
    public List<Item> Items { get; set; }
}