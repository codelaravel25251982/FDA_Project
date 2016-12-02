using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Reportcatagoryyear;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReportcatagoryyearController : Controller
    {
        SRCY db = new SRCY();
        // GET: Reportcatagoryyear
        public ActionResult Index(string year ="1009")
        {
            year = (Convert.ToInt32(year) - 543).ToString();
            var model = from Tbqueuehist in db.tbQueueHist
                        join Tbservice in db.tbService on Tbqueuehist.H_ServID equals Tbservice.ServID
                        where Tbqueuehist.H_Date.Substring(0, 4) == year
                        group new
                        {
                            Tbqueuehist,
                            Tbservice
                        }
                        by new
                        {
                            Tbqueuehist.H_Date,
                            Tbservice.ServID,
                            Tbservice.ServiceFullName,
                            Tbservice.DeptID
                        }
                        into TS
                        orderby TS.Key.ServID ascending
                        orderby TS.Key.H_Date ascending
                        select new ReportcatagoryyearView
                        {

                            H_Date = TS.Key.H_Date,
                            ServID = TS.Key.ServID,
                            ServiceFullName = TS.Key.ServiceFullName,
                            H_Number = (TS.Count(p => p.Tbqueuehist.H_Number != null)).ToString(),
                            DeptID = TS.Key.DeptID
                        };

                ViewBag.y = year;
                return View(model);

           
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