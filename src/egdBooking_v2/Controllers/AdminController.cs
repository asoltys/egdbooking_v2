using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace egdbooking_v2.Controllers
{
    using egdbooking_v2.Data;

    public class AdminController : BaseController
    {
        public AdminController(ApplicationDbContext db) : base(db)
        {
        }

        // GET: Admin
        public IActionResult Index()
        {
            ViewBag.users = db.Users.Count();
            ViewBag.companies = db.Companies.Where(c => !c.Approved).Count();

            return View();
        }
    }
}
