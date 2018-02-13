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
using static System.Net.Mime.MediaTypeNames;
using System.Data.Entity.Infrastructure;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ConfigservicesController : Controller
    {
        public Configservice db = new Configservice();
        public Configdepartment dp = new Configdepartment();


        // GET: tbServices
        public ActionResult Index()
        {
            IEnumerable<SelectListItem> dpart = dp.tbDepartMent.Select(c => new SelectListItem
            {
                Value = c.DeptID.ToString(),
                Text = c.DeptName

            });
            ViewBag.Depart = dpart;
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
            Models.Configdepartment.tbDepartMent dpt = dp.tbDepartMent.Find(id);
            ViewBag.servicename = tbService.ServiceFullName.ToString();
            ViewBag.Depart = dpt.DeptName.ToString();
            return View(tbService);
        }

        // GET: tbServices/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items2 = dp.tbDepartMent
            .Select(d => new SelectListItem
            {
                Value = d.DeptID.ToString(),
                Text = d.DeptID.ToString() + "." + d.DeptName

            });
            ViewBag.DM = items2;
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
            IEnumerable<SelectListItem> dpart = dp.tbDepartMent.Select(c => new SelectListItem
            {
                Value = c.DeptID.ToString(),
                Text = c.DeptName

            });
            ViewBag.servicename = tbService.ServiceFullName.ToString();
            ViewBag.Depart = dpart;
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
