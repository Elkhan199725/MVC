using Eterna.DataAccessLayer;
using Eterna.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eterna.Areas.Admin.Controllers;

[Area("admin")]
public class ProductController : Controller
{
    private readonly EternaDbContext _context;

    public ProductController(EternaDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Products.Include(x => x.Category).Include(x => x.ProductImages).ToListAsync());
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await _context.Categories.ToListAsync();

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        ViewBag.Categories = await _context.Categories.ToListAsync();
        if (!ModelState.IsValid) { return View(); }

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null) return NotFound(); //404

        _context.Products.Remove(data);
        await _context.SaveChangesAsync();
        return Ok(); //200
    }
}
