using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.User;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class UserconfigController : Controller
    {
        private Userconfig db = new Userconfig();

        // GET: Userconfig
        public ActionResult Index()
        {
            return View(db.tbUser.ToList());
        }

        // GET: Userconfig/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUser tbUser = db.tbUser.Find(id);
            if (tbUser == null)
            {
                return HttpNotFound();
            }
            return View(tbUser);
        }

        // GET: Userconfig/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Userconfig/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,LoginID,PassWord,Name,Surname,authtype")] tbUser tbUser)
        {
            if (ModelState.IsValid)
            {
                db.tbUser.Add(tbUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbUser);
        }

        // GET: Userconfig/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUser tbUser = db.tbUser.Find(id);
            if (tbUser == null)
            {
                return HttpNotFound();
            }
            return View(tbUser);
        }

        // POST: Userconfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,LoginID,PassWord,Name,Surname,authtype")] tbUser tbUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbUser);
        }

        // GET: Userconfig/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUser tbUser = db.tbUser.Find(id);
            if (tbUser == null)
            {
                return HttpNotFound();
            }
            return View(tbUser);
        }

        // POST: Userconfig/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbUser tbUser = db.tbUser.Find(id);
            db.tbUser.Remove(tbUser);
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
