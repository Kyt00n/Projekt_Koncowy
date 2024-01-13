using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class OrderController : Controller
{
    private readonly WebAplicationDbContext _context;

    public OrderController(WebAplicationDbContext context)
    {
        _context = context;
    }

    // GET: Order
    public async Task<IActionResult> Index()
    {
        var orders = await _context.Orders.ToListAsync();
        return View(orders);
    }

    // GET: Order/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .FirstOrDefaultAsync(m => m.OrderID == id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    // GET: Order/Create
    public IActionResult Create()
    {
        ViewBag.ItemList = new SelectList(_context.Items, "ItemID", "ItemName");
        return View();
    }

    // POST: Order/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Order order)
    {

        _context.Add(order);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }

    public async Task<IActionResult> Edit(int id)
    {
        ViewBag.ItemList = new SelectList(_context.Items, "ItemID", "ItemName");
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
        return View(order);
    }

}