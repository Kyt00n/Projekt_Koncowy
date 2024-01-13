using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class WarehouseController : Controller
{
    private readonly WebAplicationDbContext _context;

    public WarehouseController(WebAplicationDbContext context)
    {
        _context = context;
    }

    // GET: Warehouse
    public async Task<IActionResult> Index()
    {
        var warehouses = await _context.Warehouses.ToListAsync();
        return View(warehouses);
    }

    // GET: Warehouse/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var warehouse = await _context.Warehouses
            .Include(w => w.Items)
            .FirstOrDefaultAsync(m => m.WarehouseID == id);

        if (warehouse == null)
        {
            return NotFound();
        }

        return View(warehouse);
    }

    // GET: Warehouse/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Warehouse/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Warehouse warehouse)
    {
        
        _context.Add(warehouse);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
        
    }
    
}