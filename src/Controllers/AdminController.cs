﻿using egdBooking_v2.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace egdBooking_v2.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(BookingContext db) : base(db)
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
