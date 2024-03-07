
using Eterna.DataAccessLayer;
using Eterna.Models;
using Eterna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eterna.Controllers;

public class HomeController : Controller
{
    private readonly EternaDbContext _context;

    public HomeController(EternaDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Slider> sliders = _context.Sliders.ToList();
        List<Feature> features = _context.Features.ToList();

        HomeViewModel viewModel = new HomeViewModel()
        {
            Sliders = sliders,
            Features = features
        };

        return View(viewModel);
    }

    //public IActionResult Index()
    //=> View(_context.Sliders.ToList());//another method for index
}
