using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        UptimeService uptime;
        ILogger<HomeController> logger;

        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            uptime = up;
            logger = log;
        }

        public ViewResult Index(bool throwException = false)
        {
            if (throwException) throw new NullReferenceException();
            logger.LogDebug($"Перехвачено {Request.Path} в момент {uptime.Uptime}");
            return View(new Dictionary<string, string>
            {
                ["Message"] = "Это действие Index",
                ["Uptime"] = $"{uptime.Uptime} мс"
            });
        }

        public ViewResult Error() => View("Index", new Dictionary<string, string>
        {
            ["Message"] = "Это действие Error"
        });
    }
}
