using System.Collections.Generic;
using System.Linq;
using System.Net;
using egdbooking_v2.Data;
using egdbooking_v2.ViewModels;
using egdbooking_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Identity;

namespace egdbooking_v2.Controllers
{
    public class BookingsController : BaseController
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public BookingsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db)
        {
            _userManager = userManager;
        }

        // GET: Bookings
        public IActionResult Index(IFormCollection collection)
        {

            List<Booking> BookingsDB = db.Bookings.Include(c=> c.Vessel).Where(i => (i.Id > 3000)).ToList();
            DateTime startdate;
            DateTime enddate;


            if (collection.Count != 0)
            {

                if (collection["startdate"] != "" && collection["enddate"] != "")
                {

                    startdate = Convert.ToDateTime(collection["startdate"]);
                    enddate = Convert.ToDateTime(collection["enddate"]);

                    ViewBag.EndDate = enddate;
                    ViewBag.StartDate = startdate;

                    BookingsDB = BookingsDB.Where(b => ((b.StartDate >= startdate && b.StartDate <= enddate) || (b.EndDate >= startdate && b.EndDate <= enddate)))
                                            .ToList();

                }
                else if (collection["startdate"] != "")
                {
                    startdate = Convert.ToDateTime(collection["startdate"]);
                    ViewBag.StartDate = startdate;
                    BookingsDB = BookingsDB.Where(b => (b.EndDate >= startdate))
                                            .ToList();
                }
                else if (collection["enddate"] != "")
                {
                    enddate = Convert.ToDateTime(collection["enddate"]);
                    ViewBag.EndDate = enddate;
                    BookingsDB = BookingsDB.Where(b => (b.StartDate <= enddate))
                                            .ToList();

                }
            }

            BookingsViewModel ViewModel = new BookingsViewModel(Resources.Resources.Drydock, Resources.Resources.NorthJetty, Resources.Resources.SouthJetty);

            ViewModel.Drydock.Bookings = BookingsDB.Where(b => (b.Section1 != null && (bool)b.Section1)
                                                    || (b.Section2 != null && (bool)b.Section2)
                                                    || (b.Section3 != null && (bool)b.Section3)).OrderBy(b => b.StartDate).ToList();
            ViewModel.NorthJetty.Bookings = BookingsDB.Where(b => (b.NorthJetty != null && (bool)b.NorthJetty)).OrderBy(b => b.StartDate).ToList();
            ViewModel.SouthJetty.Bookings = BookingsDB.Where(b => (b.SouthJetty != null && (bool)b.SouthJetty)).OrderBy(b => b.StartDate).ToList();

            return View(ViewModel);
        }

        // GET: Bookings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,VesselId,StartDate,EndDate,BookingTime,UserId,Deleted,EndHighlight,BookingTimeChange,BookingTimeChangeStatus")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,VesselId,StartDate,EndDate,BookingTime,UserId,Deleted,EndHighlight,BookingTimeChange,BookingTimeChangeStatus")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Bookings/Manage
        public IActionResult Manage(IFormCollection collection)
        {

            List<Booking> BookingsDB = db.Bookings.Include(c => c.Vessel).Where(i => (i.Id > 3000)).ToList();
            DateTime startdate;
            DateTime enddate;

            ViewBag.ID = _userManager.GetUserId(User);

            if (collection.Count != 0)
            {

                if (collection["startdate"] != "" && collection["enddate"] != "")
                {

                    startdate = Convert.ToDateTime(collection["startdate"]);
                    enddate = Convert.ToDateTime(collection["enddate"]);

                    ViewBag.EndDate = enddate;
                    ViewBag.StartDate = startdate;

                    BookingsDB = BookingsDB.Where(b => ((b.StartDate >= startdate && b.StartDate <= enddate) || (b.EndDate >= startdate && b.EndDate <= enddate)))
                                            .ToList();

                }
                else if (collection["startdate"] != "")
                {
                    startdate = Convert.ToDateTime(collection["startdate"]);
                    ViewBag.StartDate = startdate;
                    BookingsDB = BookingsDB.Where(b => (b.EndDate >= startdate))
                                            .ToList();
                }
                else if (collection["enddate"] != "")
                {
                    enddate = Convert.ToDateTime(collection["enddate"]);
                    ViewBag.EndDate = enddate;
                    BookingsDB = BookingsDB.Where(b => (b.StartDate <= enddate))
                                            .ToList();

                }
            }

            BookingsViewModel ViewModel = new BookingsViewModel(Resources.Resources.Drydock, Resources.Resources.NorthJetty, Resources.Resources.SouthJetty);

            ViewModel.Drydock.Bookings = BookingsDB.Where(b => (b.Section1 != null && (bool)b.Section1)
                                                    || (b.Section2 != null && (bool)b.Section2)
                                                    || (b.Section3 != null && (bool)b.Section3)).OrderBy(b => b.StartDate).ToList();
            ViewModel.NorthJetty.Bookings = BookingsDB.Where(b => (b.NorthJetty != null && (bool)b.NorthJetty)).OrderBy(b => b.StartDate).ToList();
            ViewModel.SouthJetty.Bookings = BookingsDB.Where(b => (b.SouthJetty != null && (bool)b.SouthJetty)).OrderBy(b => b.StartDate).ToList();

            return View(ViewModel);
        }
    }
}
