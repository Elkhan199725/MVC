using Eterna.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Eterna.Areas.Admin.Controllers;
[Area("Admin")]
public class SliderController : Controller
{
    private readonly EternaDbContext _context;

    public SliderController(EternaDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.Sliders.ToList());
    }
}
