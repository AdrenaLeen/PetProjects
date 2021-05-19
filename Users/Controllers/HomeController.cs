using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        readonly UserManager<AppUser> userManager;

        public HomeController(UserManager<AppUser> userMgr) => userManager = userMgr;

        [Authorize]
        public IActionResult Index() => View(GetData(nameof(Index)));

        [Authorize(Policy = "DCUsers")]
        public IActionResult OtherAction() => View("Index", GetData(nameof(OtherAction)));

        [Authorize(Policy = "NotBob")]
        public IActionResult NotBob() => View("Index", GetData(nameof(NotBob)));

        Dictionary<string, object> GetData(string actionName) => new Dictionary<string, object>
        {
            ["Action"] = actionName,
            ["User"] = HttpContext.User.Identity.Name,
            ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
            ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
            ["In Users Role"] = HttpContext.User.IsInRole("Users"),
            ["City"] = CurrentUser.Result.City,
            ["Qualification"] = CurrentUser.Result.Qualifications
        };

        [Authorize]
        public async Task<IActionResult> UserProps() => View(await CurrentUser);

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProps([Required]Cities city, [Required]QualificationLevels qualifications)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await CurrentUser;
                user.City = city;
                user.Qualifications = qualifications;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(await CurrentUser);
        }

        Task<AppUser> CurrentUser => userManager.FindByNameAsync(HttpContext.User.Identity.Name);
    }
}
