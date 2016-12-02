using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models;
using BeyondThemes.BeyondAdmin.Models.Datereport;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class DatereportController : Controller
    {
        private Datereport db = new Datereport();
        public int TimetoSecond(string time)
        {
            string hh = time.Substring(0, 2);
            string mm = time.Substring(3, 2);
            string ss = time.Substring(6, 2);
            hh = (Convert.ToInt32(hh) * 60 * 60).ToString();
            mm = (Convert.ToInt32(mm) * 60).ToString();
            int second = Convert.ToInt32(hh) + Convert.ToInt32(mm) + Convert.ToInt32(ss);
            return second;
        }

        // GET: Datereport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string date = "02/08/2559", string timestart = "06:00:00", string timeend = "24:00:00")
        {
            string dd = "";
            string mm = "";
            string yy = "";
            if (date != "")
            {
                dd = date.Substring(0, 2);
                mm = date.Substring(3, 2);
                yy = date.Substring(6, 4);
                date = (Convert.ToInt32(yy) - 543).ToString() + mm + dd;
            }
            int FT = TimetoSecond(timestart);
            int ET = TimetoSecond(timeend);
            //ViewBag.Message = FT + "|" + ET + "|" + date;
            ViewBag.Date = date;
            ViewBag.Time = timestart + " - " + timeend;
            var model = (from c in db.tbQueueHist
                         join d in db.tbService on c.H_ServID equals d.ServID
                         where
                            c.H_Date == date
                         group new { c, d } by new
                         {
                             c.H_Date,
                             d.ServiceFullName
                         }
                           into
                           e
                         orderby e.Key.H_Date descending
                         select new DatereportView
                         {
                             H_Date = e.Key.H_Date.Substring(6, 2) + "/" + e.Key.H_Date.Substring(4, 2) + "/" + e.Key.H_Date.Substring(0, 4),
                             ServiceFullName = e.Key.ServiceFullName,
                             People = e.Count(p => p.c.H_Number != null)
                         });
            return Json(model.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Datereport/Details/5
        //public ActionResult Details(byte? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DatereportView datereportView = db.DatereportViews.Find(id);
        //    if (datereportView == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(datereportView);
        //}

        //// GET: Datereport/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Datereport/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "H_ServID,H_Date,ServiceFullName,H_Number")] DatereportView datereportView)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.DatereportViews.Add(datereportView);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(datereportView);
        //}

        //// GET: Datereport/Edit/5
        //public ActionResult Edit(byte? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DatereportView datereportView = db.DatereportViews.Find(id);
        //    if (datereportView == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(datereportView);
        //}

        //// POST: Datereport/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "H_ServID,H_Date,ServiceFullName,H_Number")] DatereportView datereportView)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(datereportView).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(datereportView);
        //}

        //// GET: Datereport/Delete/5
        //public ActionResult Delete(byte? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DatereportView datereportView = db.DatereportViews.Find(id);
        //    if (datereportView == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(datereportView);
        //}

        //// POST: Datereport/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(byte id)
        //{
        //    DatereportView datereportView = db.DatereportViews.Find(id);
        //    db.DatereportViews.Remove(datereportView);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
