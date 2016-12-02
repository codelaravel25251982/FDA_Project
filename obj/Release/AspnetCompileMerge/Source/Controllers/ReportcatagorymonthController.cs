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
    public class ReportcatagorymonthController : Controller
    {
        private SRCDDb db = new SRCDDb();

        // GET: Reportcatagorymonth
        public ActionResult Index()
        {
            return View(db.RSCDS.ToList());
        }

        // GET: Reportcatagorymonth/Details/5
        public ActionResult Details(byte? id)
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

        // GET: Reportcatagorymonth/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reportcatagorymonth/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServID,H_Date,ServiceFullName,H_Number")] RSCD rSCD)
        {
            if (ModelState.IsValid)
            {
                db.RSCDS.Add(rSCD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rSCD);
        }

        // GET: Reportcatagorymonth/Edit/5
        public ActionResult Edit(byte? id)
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

        // POST: Reportcatagorymonth/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServID,H_Date,ServiceFullName,H_Number")] RSCD rSCD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSCD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rSCD);
        }

        // GET: Reportcatagorymonth/Delete/5
        public ActionResult Delete(byte? id)
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

        // POST: Reportcatagorymonth/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
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
