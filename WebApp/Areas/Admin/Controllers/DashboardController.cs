using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Authorization.Permissions;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = DashboardPermissions.View)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
