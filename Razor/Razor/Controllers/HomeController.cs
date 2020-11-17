using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product[] array = {
                new Product {Name = "Каяк", Price = 275M},
                new Product {Name = "Спасательный жилет", Price = 48.95M},
                new Product {Name = "Футбольный мяч", Price = 19.50M},
                new Product {Name = "Угловой флаг", Price = 34.95M}
            };
            return View(array);
        }
    }
}
