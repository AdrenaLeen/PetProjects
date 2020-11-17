using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product myProduct = new Product
            {
                ProductID = 1,
                Name = "Каяк",
                Description = "Лодка на одного человека",
                Category = "Watersports",
                Price = 275M
            };
            ViewBag.StockLevel = 2;
            return View(myProduct);
        }
    }
}
