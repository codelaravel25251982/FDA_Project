using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Configservice;
using BeyondThemes.BeyondAdmin.Models.Configdepartment;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ConfigservicesController : Controller
    {
        public Configservice db = new Configservice();
        private Configdepartment dp = new Configdepartment();
 

        // GET: tbServices
        public ActionResult Index()
        {
            return View(db.tbService.ToList());
        }

        // GET: tbServices/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbService tbService = db.tbService.Find(id);
            if (tbService == null)
            {
                return HttpNotFound();
            }

            ViewBag.servicename = tbService.ServiceFullName.ToString();
            return View(tbService);
        }

        // GET: tbServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServID,ServiveName,Prefix,CCopy,ExpWait,Announce,StartQ,EndQ,LastQ,QDate,Remark,Remark1,Speaker,OverTime,ProCS1,ProCS2,ProCS3,ProCS4,QLimit,QLimitTime,ProCS5,DeptID,ServiceFullName")] tbService tbService)
        {
            if (ModelState.IsValid)
            {
                db.tbService.Add(tbService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbService);
        }

        // GET: tbServices/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbService tbService = db.tbService.Find(id);
        
            if (tbService == null)
            {
                return HttpNotFound();
            }
            ViewBag.servicename = tbService.ServiceFullName.ToString();
            ViewBag.Depart = new SelectList(dp.tbDepartMent, "DeptID", "DeptName");
            return View(tbService);
        }

        // POST: tbServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServID,ServiveName,Prefix,CCopy,ExpWait,Announce,StartQ,EndQ,LastQ,QDate,Remark,Remark1,Speaker,OverTime,ProCS1,ProCS2,ProCS3,ProCS4,QLimit,QLimitTime,ProCS5,DeptID,ServiceFullName")] tbService tbService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbService);
        }

        // GET: tbServices/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbService tbService = db.tbService.Find(id);
            if (tbService == null)
            {
                return HttpNotFound();
            }
            return View(tbService);
        }

        // POST: tbServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            tbService tbService = db.tbService.Find(id);
            db.tbService.Remove(tbService);
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
