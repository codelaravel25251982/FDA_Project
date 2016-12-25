using System;
using System.Linq;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Reportcatagorymonth;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReportcatagorymonthController : Controller
    {
        private SRCM db = new SRCM();

        // GET: Reportcatagorymonth
        public ActionResult Index(string month,string year)
        {
            string m = "";
            year = (Convert.ToInt32(year) - 543).ToString();
            var model = from tbqueuehist in db.tbQueueHist
                        join tbservice in db.tbService on tbqueuehist.H_ServID equals tbservice.ServID
                        where tbqueuehist.H_Date.Substring(4,2) == month && tbqueuehist.H_Date.Substring(0,4) == year
                        group new
                        {
                            tbqueuehist, tbservice
                        } 
                        by new
                        {
                            tbqueuehist.H_Date,
                            tbservice.ServID,
                            tbservice.ServiceFullName
                        }
                        into ts
                        orderby ts.Key.ServID ascending
                        orderby ts.Key.H_Date ascending
                        select new ReportcatagorymonthView
                        {

                            H_Date = ts.Key.H_Date,
                            ServID = ts.Key.ServID,
                            ServiceFullName = ts.Key.ServiceFullName,
                            H_Number = (ts.Count(p => p.tbqueuehist.H_Number !=null)).ToString()
                        };
            switch (month)
            {
                case "01": m = "มกราคม"; break;
                case "02": m = "กุมภาพันธ์"; break;
                case "03": m = "มีนาคม"; break;
                case "04": m = "เมษายน"; break;
                case "05": m = "พฤษภาคม"; break;
                case "06": m = "มิถุนายน"; break;
                case "07": m = "กรกฎาคม"; break;
                case "08": m = "สิงหาคม"; break;
                case "09": m = "กันยายน"; break;
                case "10": m = "ตุลาคม"; break;
                case "11": m = "พฤศจิกายน"; break;
                case "12": m = "พฤศจิกายน"; break;
            }
            ViewBag.m = m;
            return View(model.ToList());
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
