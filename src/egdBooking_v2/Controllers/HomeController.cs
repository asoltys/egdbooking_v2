using egdbooking_v2.Data;
using Microsoft.AspNetCore.Mvc;

namespace egdbooking_v2.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext db) : base(db)
        {
        }

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}
