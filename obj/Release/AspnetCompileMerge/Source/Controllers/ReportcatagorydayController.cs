using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReportcatagorydayController : Controller
    {
        private SRCDDb db = new SRCDDb();
        private sumallDbContext sa = new sumallDbContext();

        // GET: RSCDs
        public ActionResult Index(string Date = "")
        {
            var model = db.RSCDS.Where(c => c.H_Date == Date);
            var sum = sa.Sumalls.Where(c => c.H_Date == Date);
            ViewBag.sum = sum;
            ViewBag.Date = Date;           
            return View(model);
        }

        // GET: RSCDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSCD rSCD = db.RSCDS.Find(id);
            if (rSCD == null)
            {
                return HttpNotFound();
            }
            return View(rSCD);
        }

        // GET: RSCDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RSCDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "H_Date,H_Remark,H_Number,Prefix,H_cometime")] RSCD rSCD)
        {
            if (ModelState.IsValid)
            {
                db.RSCDS.Add(rSCD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rSCD);
        }

        // GET: RSCDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSCD rSCD = db.RSCDS.Find(id);
            if (rSCD == null)
            {
                return HttpNotFound();
            }
            return View(rSCD);
        }

        // POST: RSCDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "H_Date,H_Remark,H_Number,Prefix,H_cometime")] RSCD rSCD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSCD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rSCD);
        }

        // GET: RSCDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSCD rSCD = db.RSCDS.Find(id);
            if (rSCD == null)
            {
                return HttpNotFound();
            }
            return View(rSCD);
        }

        // POST: RSCDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RSCD rSCD = db.RSCDS.Find(id);
            db.RSCDS.Remove(rSCD);
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
