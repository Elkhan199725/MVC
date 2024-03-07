using FTB.Models;
using FTB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FTB.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        #region Services
        Service srv1 = new Service()
        {
            Title = "Google",
            Description = "Welcome to the most advanced research engine!",
            IconName = "bi bi-bounding-box-circles",
            Url = "https://google.com",
            UrlText = "Link to Google"
        };
        Service srv2 = new Service()
        {
            Title = "Yandex",
            Description = "Welcome to the most advanced research engine!",
            IconName = "bi bi-calendar4-week",
            Url = "https://yandex.com",
            UrlText = "Link to Yandex"
        };
        Service srv3 = new Service()
        {
            Title = "Bing",
            Description = "Welcome to the most advanced research engine!",
            IconName = "bi bi-chat-square-text",
            Url = "https://bing.com",
            UrlText = "Link to Bing"
        };
        #endregion
        List<Service> services = new List<Service>() { srv1, srv2, srv3 };
        #region Testimonials
        Testimonial ts1 = new Testimonial
        {
            FullName = "Saul Goodman",
            Description = "Proin iaculis purus consequat sem cure digni ssim donec porttitora entum suscipit rhoncus. " +
            "Accusantium quam, ultricies eget id, aliquam eget nibh et. Maecen aliquam, risus at semper.",
            Position = "Ceo & Founder",
            ImageUrl = "~/assets/img/testimonials/testimonials-1.jpg",
            ImageText = "Image of Testimonials-1"
        };

        Testimonial ts2 = new Testimonial
        {
            FullName = "Sara Wilsson",
            Description = "Export tempor illum tamen malis malis eram quae irure esse labore quem cillum quid cillum eram malis quorum velit fore eram velit sunt aliqua noster fugiat irure amet legam anim culpa.",
            Position = "Designer",
            ImageUrl = "~/assets/img/testimonials/testimonials-2.jpg",
            ImageText = "Image of Testimonials-2"
        };
        #endregion
        List<Testimonial> testimonials = new List<Testimonial>() { ts1, ts2 };

        HomeViewModel viewModel = new HomeViewModel()
        {
            Services = services,
            Testimonials = testimonials
        };

        return View(viewModel);
    }
}
