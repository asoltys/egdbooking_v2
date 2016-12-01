using egdBooking_v2.Models;
using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace egdBooking_v2.Controllers
{
    public class TariffsController : BaseController
    {
        public TariffsController(ApplicationDBContext db) : base(db)
        {
        }

        // GET: Tariffs
        public IActionResult Index()
        {
            return View(db.Tariffs.ToList().Where(i => i.ID < 100));
        }

        // GET: Tariffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Tariff tariff = await db.Tariffs.FindAsync(id);
            if (tariff == null)
            {
                return NotFound();
            }
            return View(tariff);
        }

        // GET: Tariffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tariffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BookingID,BookFee,FullDrain,VesselDockage,CargoDockage,WorkVesselBerthNorth,NonworkVesselBerthNorth,VesselBerthSouth,CargoStore,TopWharfage,CraneLightHook,CraneMedHook,CraneBigHook,CraneHyster,CraneGrove,Forklift,CompressPrimary,CompressSecondary,CompressPortable,Tug,FreshH2O,Electric,TieUp,Commissionaire,OvertimeLabour,LightsStandard,LightsCaisson,OtherText,Other")] Tariff tariff)
        {
            if (ModelState.IsValid)
            {
                db.Tariffs.Add(tariff);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tariff);
        }

        // GET: Tariffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Tariff tariff = await db.Tariffs.FindAsync(id);
            if (tariff == null)
            {
                return NotFound();
            }
            return View(tariff);
        }

        // POST: Tariffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,BookingID,BookFee,FullDrain,VesselDockage,CargoDockage,WorkVesselBerthNorth,NonworkVesselBerthNorth,VesselBerthSouth,CargoStore,TopWharfage,CraneLightHook,CraneMedHook,CraneBigHook,CraneHyster,CraneGrove,Forklift,CompressPrimary,CompressSecondary,CompressPortable,Tug,FreshH2O,Electric,TieUp,Commissionaire,OvertimeLabour,LightsStandard,LightsCaisson,OtherText,Other")] Tariff tariff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tariff).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tariff);
        }

        // GET: Tariffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Tariff tariff = await db.Tariffs.FindAsync(id);
            if (tariff == null)
            {
                return NotFound();
            }
            return View(tariff);
        }

        // POST: Tariffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Tariff tariff = await db.Tariffs.FindAsync(id);
            db.Tariffs.Remove(tariff);
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
