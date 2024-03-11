using Eterna.DataAccessLayer;
using Eterna.Models;
using Eterna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eterna.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly EternaDbContext _context;

        public PortfolioController(EternaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PortfolioViewModel model = new PortfolioViewModel()
            {
                Categories = _context.Categories.ToList(),
                Products = _context.Products.Include("ProductImages").ToList(),
                ProductImages = _context.ProductImages.ToList()
            };

            return View(model);
        }
        [Route("portfolio/detail/{id}")]
        public IActionResult Detail(int id)
        {
            Product? product = _context.Products.Include(x=>x.Category).Include(x=>x.ProductImages).FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NullReferenceException();

            return View(product);
        }
    }
}
