using BeyondThemes.BeyondAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Reportcatagoryweek;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReportcatagoryweekController : Controller
    {
        private QueueReportDbContentweek db = new QueueReportDbContentweek();
        sumallDbContextweek SDW = new sumallDbContextweek();


        // GET: Reportcatagorymonth
        public ActionResult Index(string start = "01/02/2559", string end = "01/02/2559", string week = "")
        {
            //string startday = start.Substring(0, 2);
            //string startmonth = start.Substring(3, 2);
            //string startyear = start.Substring(6, 4);
            //string startdate = (Convert.ToInt32(startyear) - 543).ToString() + startmonth + startday;

            //string endday = end.Substring(0, 2);
            //string endmonth = end.Substring(3, 2);
            //string endyear = end.Substring(6, 4);
            //string endtdate = (Convert.ToInt32(endyear) - 543).ToString() + endmonth + endday;

            string w = start + "-" + end;
            var sum = SDW.Sumallweeks.Where(c => c.H_Date.CompareTo(start) >= 0 && c.H_Date.CompareTo(end) <= 0);
            //var model = db.RSCWS.Where(c => c.H_Date.CompareTo(start) >= 0 && c.H_Date.CompareTo(end) <= 0);
            var model = from Tbqueuehist in db.RSCWS
                        where
                        Tbqueuehist.H_Date.ToString().Substring(3,2) ==  start.Substring(3, 2) &&
                        Tbqueuehist.H_Date.ToString().Substring(3, 2) == end.Substring(3, 2) &&
                        Tbqueuehist.H_Date.CompareTo(start) >= 0 &&
                        Tbqueuehist.H_Date.CompareTo(end) <= 0
                        group Tbqueuehist by new
                        {
                            Tbqueuehist.H_Date,
                            Tbqueuehist.ServID,
                            Tbqueuehist.ServiceFullName,
                            Tbqueuehist.H_Number

                        }
                        into TS
                        orderby TS.Key.ServID ascending
                        orderby TS.Key.H_Date ascending
                        select new RSCWView()
                        {

                            H_Date = TS.Key.H_Date,
                            ServID = TS.Key.ServID,
                            ServiceFullName = TS.Key.ServiceFullName,
                            H_Number = TS.Key.H_Number
                        };
            ViewBag.Week = week;
            ViewBag.Date = w;
            ViewBag.sum = sum;
            return View(model);
            //return Json(ViewBag.Week, JsonRequestBehavior.AllowGet);

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
