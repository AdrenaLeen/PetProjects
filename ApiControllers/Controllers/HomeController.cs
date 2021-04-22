using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    public class HomeController : Controller
    {
        private IRepository Repository { get; set; }

        public HomeController(IRepository repo) => Repository = repo;

        public ViewResult Index() => View(Repository.Reservations);

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            Repository.AddReservation(reservation);
            return RedirectToAction("Index");
        }
    }
}
