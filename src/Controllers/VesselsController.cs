using egdbooking_v2.Models;
using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace egdbooking_v2.Controllers
{
    public class VesselsController : BaseController
    {
        public VesselsController(ApplicationDbContext db) : base(db)
        {
        }

        // GET: Vessels
        public async Task<IActionResult> Index()
        {
            return View(await db.Vessels.ToListAsync());
        }

        // GET: Vessels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Vessel vessel = await db.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }
            return View(vessel);
        }

        // GET: Vessels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vessels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Length,Width,BlockSetupTime,BlockTeardownTime,LloydsID,Tonnage,Anonymous,Deleted,EndHighlight")] Vessel vessel)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Vessel vessel = await db.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }
            return View(vessel);
        }

        // POST: Vessels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,Name,Length,Width,BlockSetupTime,BlockTeardownTime,LloydsID,Tonnage,Anonymous,Deleted,EndHighlight")] Vessel vessel)
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Vessel vessel = await db.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }
            return View(vessel);
        }

        // POST: Vessels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
