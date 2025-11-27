using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Project
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .OrderBy(p => p.Order)
                .ToListAsync();

            return View(projects);
        }

        // GET: /Admin/Project/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: /Admin/Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
                return View(project);

            project.CreatedAt = DateTime.UtcNow;

            _context.Add(project);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
