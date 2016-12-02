using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models;
using BeyondThemes.BeyondAdmin.Models.Reportcounterday;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReportcounterdayViewsController : Controller
    {
        private QueueReportDbContent db = new QueueReportDbContent();

        // GET: ReportcounterdayViews

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
        public ActionResult Index(string date = "00/00/0000", string timestart = "06:00:00", string timeend = "24:00:00")
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
                         join d in db.tbCounter on c.H_Counter equals d.CounterNo
                         where
                            c.H_Date == date &&
                            c.H_cometime >= FT &&
                            c.H_cometime <= ET &&
                            c.H_cometime != null &&
                            c.H_servetime1 != null &&
                            c.H_servetime1 - c.H_endtime > 0 &&
                            c.H_endtime1 - c.H_servetime1 > 0 &&
                            c.H_endtime1 != null
                         group new { c, d } by new
                         {
                             c.H_Date,
                             d.CounterName
                         }
                            into
                            e
                         orderby e.Key.H_Date descending
                         select new RCTDView
                         {
                             H_Date = e.Key.H_Date.Substring(6, 2) + "/" + e.Key.H_Date.Substring(4, 2) + "/" + e.Key.H_Date.Substring(0, 4),
                             CounterName = e.Key.CounterName,
                             People = e.Count(p => p.c.H_Number != null),
                             WaitTime = e.Average(p => p.c.H_servetime1 - p.c.H_endtime).ToString(),
                             WaitMinTime = e.Min(p => p.c.H_servetime1 - p.c.H_endtime).ToString(),
                             WaitMaxTime = e.Max(p => p.c.H_servetime1 - p.c.H_endtime).ToString(),
                             ServiceTime = e.Average(p => p.c.H_endtime1 - p.c.H_servetime1).ToString(),
                             ServiceMinTime = e.Min(p => p.c.H_endtime1 - p.c.H_servetime1).ToString(),
                             ServiceMaxTime = e.Max(p => p.c.H_endtime1 - p.c.H_servetime1).ToString()
                         }).ToList();
            return View(model);
        }

        // GET: ReportcounterdayViews/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportcounterdayView reportcounterdayView = db.ReportcounterdayViews.Find(id);
            if (reportcounterdayView == null)
            {
                return HttpNotFound();
            }
            return View(reportcounterdayView);
        }

        // GET: ReportcounterdayViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportcounterdayViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CounterNo,H_Date,CounterName,H_Number,WaitAVGTime,WaitMinTime,WaitMaxTime,ServiceAVGTime,ServiceMinTime,ServiceMaxTime")] ReportcounterdayView reportcounterdayView)
        {
            if (ModelState.IsValid)
            {
                db.ReportcounterdayViews.Add(reportcounterdayView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportcounterdayView);
        }

        // GET: ReportcounterdayViews/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportcounterdayView reportcounterdayView = db.ReportcounterdayViews.Find(id);
            if (reportcounterdayView == null)
            {
                return HttpNotFound();
            }
            return View(reportcounterdayView);
        }

        // POST: ReportcounterdayViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CounterNo,H_Date,CounterName,H_Number,WaitAVGTime,WaitMinTime,WaitMaxTime,ServiceAVGTime,ServiceMinTime,ServiceMaxTime")] ReportcounterdayView reportcounterdayView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportcounterdayView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportcounterdayView);
        }

        // GET: ReportcounterdayViews/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportcounterdayView reportcounterdayView = db.ReportcounterdayViews.Find(id);
            if (reportcounterdayView == null)
            {
                return HttpNotFound();
            }
            return View(reportcounterdayView);
        }

        // POST: ReportcounterdayViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ReportcounterdayView reportcounterdayView = db.ReportcounterdayViews.Find(id);
            db.ReportcounterdayViews.Remove(reportcounterdayView);
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
