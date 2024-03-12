using Eterna.DataAccessLayer;
using Eterna.Models;
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
    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }
    [HttpPost]
    public IActionResult Create(Slider slider)
    {
        if(!ModelState.IsValid) return View();

        if(slider.Title1.Length < 5)
        {
            ModelState.AddModelError(nameof(slider.Title1), "Min length is 6!");
            return View();
        }

        _context.Sliders.Add(slider);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Update(int id)
    {
        Slider? slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

        if (slider == null) { throw new NullReferenceException(); }

        return View(slider);
    }
    [HttpPost]
    public IActionResult Update(Slider slider)
    {
        Slider? existSlider = _context.Sliders.FirstOrDefault(x => x.Id == x.Id);
        if (slider == null) { throw new NullReferenceException(); }

        existSlider.Title1 = slider.Title1;
        existSlider.Title2 = slider.Title2;
        existSlider.RedirectUrl = slider.RedirectUrl;
        existSlider.Description = slider.Description;
        existSlider.ImageUrl = slider.ImageUrl;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var data = _context.Sliders.FirstOrDefault(x => x.Id == id);
        if (data == null) return NotFound(); //404

        _context.Sliders.Remove(data);
        _context.SaveChanges();
        return Ok(); //200
    }
}
