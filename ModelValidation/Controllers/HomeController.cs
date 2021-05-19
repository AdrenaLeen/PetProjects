using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidation.Models;
using System;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("MakeBooking", new Appointment { Date = DateTime.Now });

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            if (ModelState.GetValidationState(nameof(appt.Date)) == ModelValidationState.Valid && ModelState.GetValidationState(nameof(appt.ClientName)) == ModelValidationState.Valid && appt.ClientName.Equals("Джо", StringComparison.OrdinalIgnoreCase) && appt.Date.DayOfWeek == DayOfWeek.Monday) ModelState.AddModelError("", "Джо не может назначать встречи на понедельник");
            if (ModelState.IsValid) return View("Completed", appt);
            else return View();
        }

        public JsonResult ValidateDate(string Date)
        {
            if (!DateTime.TryParse(Date, out DateTime parsedDate)) return Json("Введите корректную дату (dd.mm.yyyy)");
            else if (DateTime.Now > parsedDate) return Json("Введите дату в будущем");
            else return Json(true);
        }
    }
}
