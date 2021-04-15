﻿using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            IRepository repository = HttpContext.RequestServices.GetService<IRepository>();
            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = totalizer.Repository.ToString();
            return View(repository.Products);
        }
    }
}
