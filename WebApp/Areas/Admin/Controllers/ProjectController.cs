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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project, IFormFile? ImageFile)
        {
            if (!ModelState.IsValid)
                return View(project);

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine("wwwroot/uploads/projects", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    await ImageFile.CopyToAsync(stream);

                project.ImageUrl = "/uploads/projects/" + fileName;
            }

            project.CreatedAt = DateTime.UtcNow;
            project.UpdatedAt = DateTime.UtcNow;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
