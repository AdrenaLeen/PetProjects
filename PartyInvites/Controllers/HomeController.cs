using Microsoft.AspNetCore.Mvc;
using System;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Доброе утро" : "Добрый день";
            return View("MyView");
        }

        public ViewResult RsvpForm()
        {
            return View();
        }
    }
}
