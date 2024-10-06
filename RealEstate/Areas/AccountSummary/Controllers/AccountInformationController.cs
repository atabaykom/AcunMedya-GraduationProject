using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Areas.AccountSummary.Controllers
{
    [Area("AccountSummary")]
    [Authorize]
    public class AccountInformationController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            return View();
        }
    }
}
