using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("MyView", new string[] { "Яблоко", "Апельсин", "Груша" });

        public ViewResult List() => View();
    }
}
