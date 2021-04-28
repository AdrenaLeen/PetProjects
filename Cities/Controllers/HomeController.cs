using Cities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        readonly IRepository repository;

        public HomeController(IRepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Cities);

        public ViewResult Edit() => View("Create", repository.Cities.First());

        public ViewResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            repository.AddCity(city);
            return RedirectToAction("Index");
        }
    }
}
