using Domain.Authorization.Permissions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Admin.Models;


namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = DashboardPermissions.View)]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                UsersCount = await _db.Users.CountAsync(),
                //ProjectsCount = await _db.Set<Project>().CountAsync(), // ajuste se a entity Projects existir
                ProjectsCount = 0, // ajuste se a entity Projects existir
                VisitsCount = await GetVisitsCountAsync() // método = placeholder ou real
            };

            return View(model);
        }

        private Task<int> GetVisitsCountAsync()
        {
            // placeholder — substitua pelo seu contador real se existir
            return Task.FromResult(1200);
        }
    }
}
