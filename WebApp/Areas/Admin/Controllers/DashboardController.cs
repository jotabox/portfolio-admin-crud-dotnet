using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Authorization.Permissions;

namespace WebApp.Areas.Admin.Controllers
{
    [AdminArea]
    [Authorize(Policy = DashboardPermissions.View)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
