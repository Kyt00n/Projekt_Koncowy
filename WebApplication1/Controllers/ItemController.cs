using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class ItemController : Controller
{
    private readonly WebAplicationDbContext _context;

    public ItemController(WebAplicationDbContext context)
    {
        _context = context;
    }

    // //GET: Item
    // public async Task<IActionResult> Index()
    // {
    //     var items = await _context.Items.ToListAsync();
    //     return View(items);
    // }
    public async Task<IActionResult> Index(int? warehouseId)
    {
        ViewBag.WarehouseList = new SelectList(_context.Warehouses, "WarehouseID", "WarehouseName");

        var itemsQuery = _context.Items.Include(i => i.Warehouse).AsQueryable();

        if (warehouseId.HasValue)
        {
            itemsQuery = itemsQuery.Where(i => i.WarehouseID == warehouseId);
        }

        var items = itemsQuery.ToList();

        return View(items);
    }

    // GET: Item/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _context.Items
            .FirstOrDefaultAsync(m => m.ItemID == id);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }
    public IActionResult Create(int? warehouseId)
    {
        ViewBag.WarehouseList = new SelectList(_context.Warehouses, "WarehouseID", "WarehouseName");

        return View();
    }
    // POST: Item/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ItemID,ItemName,Description,Price,QuantityInStock,WarehouseID")] Item item)
    {
        
            _context.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
    }
}