using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace egdbooking_v2.Controllers
{
    using core.Controllers;
    using egdbooking_v2.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Models;
    using System.Threading.Tasks;

    public class AdminController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db)
        {
            _userManager = userManager;
        }

        // GET: Admin
        public IActionResult Menu()
        {
            //ViewBag.users = db.Users.Count();
            ViewBag.companies = db.Companies.Where(c => !c.Approved).Count();

            return View();
        }

        public async Task<IActionResult> AddIndex()
        {
            return View(_userManager.Users.Except(await _userManager.GetUsersInRoleAsync("Admin")).ToList());
        }

        public async Task<IActionResult> AddConfirm(string id)
        {
            return View(await _userManager.FindByIdAsync(id));
        }

        public async Task<IActionResult> Add(string id)
        {
            await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(id), "Admin");
            return RedirectToAction("Menu", "Admin");
        }

        public async Task<IActionResult> RemoveIndex()
        {
            return View(await _userManager.GetUsersInRoleAsync("Admin"));
        }

        public async Task<IActionResult> RemoveConfirm(string id)
        {
            return View(await _userManager.FindByIdAsync(id));
        }

        public async Task<IActionResult> Remove(string id)
        {
            await _userManager.RemoveFromRoleAsync(await _userManager.FindByIdAsync(id), "Admin");
            return RedirectToAction("Menu", "Admin");
        }
    }
}
