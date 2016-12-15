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

        public FileStreamResult Pdf()
        {
            // TODO: This is currently just some example code to generate a PDF, will need to build up the Schedule 1 form and integrate it.

            // Set up the document and the MS to write it to and create the PDF writer instance
            MemoryStream ms = new MemoryStream();
            Document document = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            // Open the PDF document
            document.Open();

            // Set up fonts used in the document
            Font font_heading = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 16, Font.BOLD);
            Font font_body = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9);

            // Create the heading paragraph
            Paragraph heading_paragraph;
            heading_paragraph = new Paragraph();

            // Create the chunk with the heading font
            Phrase heading_phrase = new Phrase(Resources.Resources.EGD, font_heading);
            heading_paragraph.Add(heading_phrase);

            // Add a horizontal line below the headig text and add it to the paragraph
            iTextSharp.text.pdf.draw.VerticalPositionMark seperator = new iTextSharp.text.pdf.draw.LineSeparator();
            seperator.Offset = -6f;
            heading_paragraph.Add(seperator);

            // Add paragraph to document
            document.Add(heading_paragraph);

            // Create the body paragraph
            Paragraph body_paragraph;
            body_paragraph = new Paragraph();
            body_paragraph.SpacingBefore = 20f;

            // Create the chunk with the heading font
            Phrase body_phrase = new Phrase(Resources.Resources.Tariff, font_body);
            body_paragraph.Add(body_phrase);

            // Add paragraph to document
            document.Add(body_paragraph);

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
