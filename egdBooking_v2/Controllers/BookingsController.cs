using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using egdBooking_v2.Models;
using egdBooking_v2.ViewModels;

namespace egdBooking_v2.Controllers
{
    public class BookingsController : BaseController
    {
        private BookingContext db = new BookingContext();

        // GET: Bookings
        public ActionResult Index(FormCollection collection)
        {
            DateTime startdate = Convert.ToDateTime(collection.Get("startdate"));
            DateTime enddate = Convert.ToDateTime(collection.Get("enddate"));

            BookingsViewModel ViewModel = new BookingsViewModel(Resources.Resources.Drydock, Resources.Resources.NorthJetty, Resources.Resources.SouthJetty);

            List<Booking> BookingsDB = db.Bookings.Where(i => i.ID > 3000)
                                                  .Where(b => ((b.StartDate >= startdate && b.StartDate <= enddate) || (b.EndDate >= startdate && b.EndDate <= enddate)))
                                                  .ToList();

            ViewModel.Drydock.Bookings = BookingsDB.Where(b => (b.Section1 != null && (bool)b.Section1)
                                                    || (b.Section2 != null && (bool)b.Section2)
                                                    || (b.Section3 != null && (bool)b.Section3)).OrderBy(b => b.StartDate).ToList();
            ViewModel.NorthJetty.Bookings = BookingsDB.Where(b => (b.NorthJetty != null && (bool)b.NorthJetty)).OrderBy(b => b.StartDate).ToList();
            ViewModel.SouthJetty.Bookings = BookingsDB.Where(b => (b.SouthJetty != null && (bool)b.SouthJetty)).OrderBy(b => b.StartDate).ToList();

            return View(ViewModel);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VNID,StartDate,EndDate,BookingTime,UID,Deleted,EndHighlight,BookingTimeChange,BookingTimeChangeStatus")] Booking booking)
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VNID,StartDate,EndDate,BookingTime,UID,Deleted,EndHighlight,BookingTimeChange,BookingTimeChangeStatus")] Booking booking)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
    }
}
