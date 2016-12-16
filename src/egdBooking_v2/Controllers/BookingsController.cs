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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace egdbooking_v2.Controllers
{
    public class BookingsController : BaseController
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public BookingsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Bookings
        public IActionResult Index(IFormCollection collection)
        {
            List<Booking> BookingsDB = db.Bookings.Include(c=> c.Vessel).Where(i => ((i.Id > 3000 && i.Status =="C"))).ToList();
            DateTime startdate;
            DateTime enddate;

            if (_signInManager.IsSignedIn(User)) ViewBag.isLoggedIn = true;
            else ViewBag.isLoggedIn = false;

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

            if (User.IsInRole("User"))
            {
                ViewBag.ID = _userManager.GetUserId(User);
                var userID = _userManager.GetUserId(User);
                BookingsDB = BookingsDB.Where(i => (i.UserId == userID)).ToList();
            }

            

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

        public IActionResult Form()
        {
            return View();
        }

        public FileStreamResult Pdf(FormViewModel model)
        {
            // Set up the document and the MS to write it to and create the PDF writer instance
            MemoryStream ms = new MemoryStream();
            Document document = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            // Open the PDF document
            document.Open();

            // Set up fonts used in the document
            Font normal = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL);
            Font bold = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD);
            string singlespace = "\n";
            string doublespace = "\n\n";

            PdfPTable page = new PdfPTable(1);
            page.WidthPercentage = 100;

            PdfPCell header_cell = new PdfPCell(new Paragraph(new Chunk("SCHEDULE 1".ToUpper() + doublespace, normal)));
            header_cell.HorizontalAlignment = Element.ALIGN_CENTER;
            header_cell.BorderWidth = 0;
            page.AddCell(header_cell);

            PdfPCell title_cell = new PdfPCell(new Paragraph(new Chunk("APPLICATION FOR THE USE OF ESQUIMALT GRAVING DOCK, PUBLIC WORKS AND GOVERNMENT SERVICES CANADA, VICTORIA, BRITISH COLUMBIA".ToUpper() + doublespace, bold)));
            title_cell.HorizontalAlignment = Element.ALIGN_CENTER;
            title_cell.BorderWidth = 0;
            page.AddCell(title_cell);

            PdfPCell undersigned_cell = new PdfPCell(new Paragraph(new Chunk("I (We), the undersigned, hereby make application for use of the facilities within the Esquimalt Graving Dock as indicated below:" + singlespace, normal)));
            undersigned_cell.BorderWidth = 0;
            page.AddCell(undersigned_cell);

            PdfPTable info_table = new PdfPTable(2);

            List<Phrase> left_phrases = new List<Phrase>();
            left_phrases.Add(new Phrase(new Chunk(singlespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Dates of Dry-dock" + ": " + model.DrydockDates + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Purpose of Dry-dock" + ": " + model.DrydockPurpose + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Dates of Berthage (NLW)" + ": " + model.BerthageDates + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Purpose of Berthage" + ": " + model.BerthagePurpose + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Master's Name" + ": " + model.MasterName + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Agent's Name" + ": " + model.AgentName + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Dockmaster's Name" + ": " + model.DockmasterName + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Length, Overall" + ": " + model.OverallLength + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Breadth, Extreme" + ": " + model.ExtremeBreadth + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Draft, Aft" + ": " + model.AftDraft + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Engines (Steam/Gasoline/Oil)" + ": " + model.Engines + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("Keel (Bar/Flat, if bar, state depth)" + ": " + model.Keel + doublespace, normal)));
            left_phrases.Add(new Phrase(new Chunk("If there any explosive matter on board describe" + ": " + model.ExplosiveMatter + doublespace, normal)));
            Paragraph left_paragraph = new Paragraph();
            foreach (Phrase phrase in left_phrases)
                left_paragraph.Add(phrase);
            info_table.AddCell(new PdfPCell(left_paragraph));

            List<Phrase> right_phrases = new List<Phrase>();
            right_phrases.Add(new Phrase(new Chunk(singlespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Name of Vessel" + ": " + model.VesselName + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Owner's Name" + ": " + model.OwnerName + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Port of Registry" + ": " + model.RegistryPort + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Owner's Address" + ": " + model.OwnerAddress + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Master's Address" + ": " + model.MasterAddress + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Agent's Address" + ": " + model.AgentAddress + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Gross Tonnage" + ": " + model.GrossTonnage + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Length between Perpendiculars" + ": " + model.PerpendicularsLength + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Draft, Forward" + ": " + model.ForwardDraft + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Type of Vessel (screw, sailing, not self-propelled, etc.)" + ": " + model.VesselType + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Fuel Type" + ": " + model.FuelType + doublespace, normal)));
            right_phrases.Add(new Phrase(new Chunk("Rise of Floor Amidships" + ": " + model.FloorRiseAmidships + doublespace, normal)));
            Paragraph right_paragraph = new Paragraph();
            foreach (Phrase phrase in right_phrases)
                right_paragraph.Add(phrase);
            info_table.AddCell(new PdfPCell(right_paragraph));

            PdfPCell info_cell = new PdfPCell(info_table);
            page.AddCell(info_cell);
            
            // Add to document
            document.Add(page);

            // Close the PDF document
            document.Close();

            // Start output from beginning of stream
            byte[] file = ms.ToArray();
            MemoryStream output = new MemoryStream();
            output.Write(file, 0, file.Length);
            output.Position = 0;

            // Return the output stream
            return new FileStreamResult(output, "application/pdf");
        }
    }
}
