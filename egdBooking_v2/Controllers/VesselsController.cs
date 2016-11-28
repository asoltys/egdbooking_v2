using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using egdBooking_v2.Models;

namespace egdBooking_v2.Controllers
{
    public class VesselsController : Controller
    {
        private BookingContext db = new BookingContext();

        // GET: Vessels
        public async Task<ActionResult> Index()
        {
            return View(await db.Vessels.ToListAsync());
        }

        // GET: Vessels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = await db.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            return View(vessel);
        }

        // GET: Vessels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vessels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Length,Width,BlockSetupTime,BlockTeardownTime,LloydsID,Tonnage,Anonymous,Deleted,EndHighlight")] Vessel vessel)
        {
            if (ModelState.IsValid)
            {
                db.Vessels.Add(vessel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vessel);
        }

        // GET: Vessels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = await db.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            return View(vessel);
        }

        // POST: Vessels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Length,Width,BlockSetupTime,BlockTeardownTime,LloydsID,Tonnage,Anonymous,Deleted,EndHighlight")] Vessel vessel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vessel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vessel);
        }

        // GET: Vessels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = await db.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            return View(vessel);
        }

        // POST: Vessels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vessel vessel = await db.Vessels.FindAsync(id);
            db.Vessels.Remove(vessel);
            await db.SaveChangesAsync();
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
