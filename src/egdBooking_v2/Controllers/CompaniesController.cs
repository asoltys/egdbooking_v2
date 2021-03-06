﻿using egdbooking_v2.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using egdbooking_v2.Data;
using System.Linq;

namespace egdbooking_v2.Controllers
{
    public class CompaniesController : BaseController
    {
        public CompaniesController(ApplicationDbContext db) : base(db)
        {
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await db.Companies.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)(int)HttpStatusCode.BadRequest);
            }
            Company company = await db.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Approved,Deleted,Name_f,Address1,Address2,City,Province,Country,Zip,Phone,Abbreviation,Fax")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/EditIndex
        public IActionResult EditIndex()
        {
            return View(db.Companies.ToList());
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Company company = await db.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Approved,Deleted,Name_f,Address1,Address2,City,Province,Country,Zip,Phone,Abbreviation,Fax")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        public IActionResult DeleteIndex()
        {
            return View(db.Companies.ToList());
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Company company = await db.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Company company = await db.Companies.FindAsync(id);
            //db.Companies.Remove(company);
            company.Deleted = true;
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

        // GET: Companies/Approve
        public async Task<IActionResult> Approve()
        {
            return View(await db.Companies.Where(c => !c.Approved).ToListAsync());
        }

        // POST: Companies/Approve
        [HttpPost, ActionName("Approve")]
        public async Task<IActionResult> ApproveConfirmed(int id, string abbrev)
        {
            Company company = await db.Companies.FindAsync(id);
            company.Approved = true;
            company.Deleted = false;
            company.Abbreviation = abbrev.ToUpper();
            await db.SaveChangesAsync();
            return RedirectToAction("Approve");
        }
    }
}
