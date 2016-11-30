using egdBooking_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace egdBooking_v2.Controllers
{
    public class AdminController : Controller
    {
        private BookingContext db = new BookingContext();

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.users = db.UserCompanies.Where(u => !u.Approved).Count();
            ViewBag.companies = db.Companies.Where(c => !c.Approved).Count();

            return View();
        }
    }
}