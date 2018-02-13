using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Configcounter;
using BeyondThemes.BeyondAdmin.Models.Configservice;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ConfigcounterController : Controller
    {
        public  Configcounter db = new Configcounter();
        public Configservice CS = new Configservice();

        // GET: Configcounter
        public ActionResult Index()
        {

            //IEnumerable<SelectListItem> tc = CS.tbService
            // .Select(d => new SelectListItem
            // {
            //     Value = d.ServID.ToString(),
            //     Text = d.ServID.ToString() + "." + d.ServiveName

            // });
            //ViewBag.ServID = tc;
            return View(db.tbCounter.ToList());
        }

        // GET: Configcounter/Details/5
        public ActionResult Details(string id)
        {
            tbCounter tbCouter = db.tbCounter.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCounter tbCounter = db.tbCounter.Find(id);
            if (tbCounter == null)
            {
                return HttpNotFound();
            }
            ViewBag.CounterName = tbCounter.CounterName.ToString();
            return View(tbCounter);
           
        }

        // GET: Configcounter/Create
        public ActionResult Create()
        {
            var maxCounterNo = db.tbCounter.Select(c => c.ID).Max() ;
            ViewBag.maxCounterNo = (Convert.ToInt32(maxCounterNo) +1).ToString();

            List<SelectListItem> tc = CS.tbService
           .Select(a => new SelectListItem
           {
               Value = a.ServID.ToString(),
               Text = a.ServID.ToString() + "." + a.ServiveName
           }).ToList();
            tc.Insert(0, new SelectListItem() { Value = "0", Text = "-- ไม่เลือกประเภทบริการ --" });
            ViewBag.ServID = tc;
           

            List<SelectListItem> tc1 = CS.tbService
            .Select(b => new SelectListItem
            {
                Value = b.ServID.ToString(),
                Text = b.ServID.ToString() + "." + b.ServiveName
               
            }).ToList();
            tc1.Insert(0, new SelectListItem() { Value = "0", Text = "-- ไม่เลือกประเภทบริการ --" });
            ViewBag.ServID1 = tc1;

            List<SelectListItem> tc2 = CS.tbService
            .Select(c => new SelectListItem
            {
                Value = c.ServID.ToString(),
                Text = c.ServID.ToString() + "." + c.ServiveName
                
            }).ToList();
            tc2.Insert(0, new SelectListItem() { Value = "0", Text = "-- ไม่เลือกประเภทบริการ --" });
            ViewBag.ServID2 = tc2;

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
        public ActionResult Edit(string id,string ServID,string ServID1,string ServID2)
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
            List<SelectListItem> tc = CS.tbService
            .Select(a => new SelectListItem
            {
                Value = a.ServID.ToString(),
                Text = a.ServID.ToString() + "." + a.ServiveName,
                Selected = (a.ServID.ToString() == ServID ? true : false)
            }).ToList();
            tc.Insert(0, new SelectListItem() { Value = "0", Text = "-- ไม่เลือกประเภทบริการ --" });
            ViewBag.ServID = tc;
            ViewBag.CounterName = db.tbCounter.Find(id).CounterName.ToString();

            List<SelectListItem> tc1 = CS.tbService
            .Select(b => new SelectListItem
            {
                Value = b.ServID.ToString(),
                Text = b.ServID.ToString() + "." + b.ServiveName,
                Selected = (b.ServID.ToString() == ServID1 ? true : false)
            }).ToList();
            tc1.Insert(0, new SelectListItem() { Value = "0", Text = "-- ไม่เลือกประเภทบริการ --" });
            ViewBag.ServID1 = tc1;

            List<SelectListItem> tc2 = CS.tbService
            .Select(c => new SelectListItem
            {
                Value = c.ServID.ToString(),
                Text = c.ServID.ToString() + "." + c.ServiveName,
                Selected = (c.ServID.ToString() == ServID2 ? true : false)
            }).ToList();
            tc2.Insert(0, new SelectListItem() { Value = "0", Text = "-- ไม่เลือกประเภทบริการ --" });
            ViewBag.ServID2 = tc2;


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
