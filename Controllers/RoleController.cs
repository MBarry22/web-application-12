using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using WebApplication12.Data;
using WebApplication12.Repositories;
using WebApplication12.ViewModels;

namespace WebApplication12.Controllers
{
    [Authorize(Roles = "Admin,Manager" )]
    
    public class RoleController : Controller
    {
        ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Role
        public ActionResult Index()
        {
            RoleRepo roleRepo = new RoleRepo(_context);
            return View(roleRepo.GetAllRoles());
        }

        public IActionResult Create()
        {
            var user = _context.Roles.Select(c => c.Id).ToList();

            ViewData["Rol"] = new SelectList(user);
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleVM roleVM, string roleName)
        {

            RoleRepo roleRepo = new RoleRepo(_context);
            RoleVM roleVm = new RoleVM();

            var role = roleRepo.CreateRole(roleName);

            if (ModelState.IsValid)
            {
                roleVm.Id = roleVM.Id;
                roleVm.RoleName = roleVM.RoleName;

            }


            return RedirectToAction("Index", "Role");

        }
    }

}

