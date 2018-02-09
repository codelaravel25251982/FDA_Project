using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Configcounter;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ConfigcounterController : Controller
    {
        private Configcounter db = new Configcounter();

        // GET: Configcounter
        public ActionResult Index()
        {
            return View(db.tbCounter.ToList());
        }

        // GET: Configcounter/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCounter tbCounter = db.tbCounter.Find(id);
            if (tbCounter == null)
            {
                return HttpNotFound();
            }
            return View(tbCounter);
        }

        // GET: Configcounter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Configcounter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CounterNo,CounterName,ServID,ID,ServID1,ServID2,Summary,CallNum,CGroup,CallCounter,Announce,Status,Process,CPos")] tbCounter tbCounter)
        {
            if (ModelState.IsValid)
            {
                db.tbCounter.Add(tbCounter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbCounter);
        }

        // GET: Configcounter/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCounter tbCounter = db.tbCounter.Find(id);
            if (tbCounter == null)
            {
                return HttpNotFound();
            }
            return View(tbCounter);
        }

        // POST: Configcounter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CounterNo,CounterName,ServID,ID,ServID1,ServID2,Summary,CallNum,CGroup,CallCounter,Announce,Status,Process,CPos")] tbCounter tbCounter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCounter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbCounter);
        }

        // GET: Configcounter/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCounter tbCounter = db.tbCounter.Find(id);
            if (tbCounter == null)
            {
                return HttpNotFound();
            }
            return View(tbCounter);
        }

        // POST: Configcounter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbCounter tbCounter = db.tbCounter.Find(id);
            db.tbCounter.Remove(tbCounter);
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
