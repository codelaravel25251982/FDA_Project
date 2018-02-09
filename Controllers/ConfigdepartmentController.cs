using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Configdepartment;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ConfigdepartmentController : Controller
    {
        private Configdepartment db = new Configdepartment();

        // GET: Configdepartment
        public ActionResult Index()
        {
            return View(db.tbDepartMent.ToList());
        }

        // GET: Configdepartment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartMent tbDepartMent = db.tbDepartMent.Find(id);
            if (tbDepartMent == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartMent);
        }

        // GET: Configdepartment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Configdepartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeptID,DeptName")] tbDepartMent tbDepartMent)
        {
            if (ModelState.IsValid)
            {
                db.tbDepartMent.Add(tbDepartMent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbDepartMent);
        }

        // GET: Configdepartment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartMent tbDepartMent = db.tbDepartMent.Find(id);
            if (tbDepartMent == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartMent);
        }

        // POST: Configdepartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptID,DeptName")] tbDepartMent tbDepartMent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbDepartMent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbDepartMent);
        }

        // GET: Configdepartment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartMent tbDepartMent = db.tbDepartMent.Find(id);
            if (tbDepartMent == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartMent);
        }

        // POST: Configdepartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbDepartMent tbDepartMent = db.tbDepartMent.Find(id);
            db.tbDepartMent.Remove(tbDepartMent);
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
