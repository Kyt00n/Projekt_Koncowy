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

    
    public IActionResult Create()
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
    // GET: Item/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        ViewBag.WarehouseList = new SelectList(_context.Warehouses, "WarehouseID", "WarehouseName");

        if (id == null)
        {
            return NotFound();
        }

        var item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Item item)
    {
        var i = await _context.Items.FindAsync(id);

        
            i.ItemName = item.ItemName;
            i.Description = item.Description;
            i.Price = item.Price;
            i.QuantityInStock = item.QuantityInStock;
            i.WarehouseID = item.WarehouseID;
        

        _context.Update(i);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<ActionResult> Delete(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        var item = await _context.Items.FindAsync(id);
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }
}