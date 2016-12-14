using egdbooking_v2.Data;
using egdbooking_v2.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace egdbooking_v2.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext db) : base(db)
        {
        }

        public IActionResult Index(LoginViewModel model)
        {            
            return View(model);
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

        public IActionResult Tariff()
        {
            return View();
        }

        public IActionResult Notices()
        {
            DirectoryInfo Dir = new DirectoryInfo(Path.GetFullPath("Views/Partials/Notices"));
            List<FileInfo> Files = Dir.GetFiles("*" + ((ViewBag.lang == "fr") ? "Fra" : "Eng") + ".cshtml").OfType<FileInfo>().ToList();
            Files = Files.OrderByDescending(f => f.CreationTime).ToList();
            List<string> notices = new List<string>();
            foreach (FileInfo file in Files)
            {
                notices.Add(file.Name);
            }
            return View(notices);
        }

        [Route("home/test")]
        public IActionResult Gantt()
        {
            return View();
        }
    }
}
