using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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
            var model = from Tbqueuehist in db.tbQueueHist
                        join Tbservice in db.tbService on Tbqueuehist.H_ServID equals Tbservice.ServID
                        where Tbqueuehist.H_Date.Substring(4,2) == month && Tbqueuehist.H_Date.Substring(0,4) == year
                        group new
                        {
                            Tbqueuehist,
                            Tbservice
                        } 
                        by new
                        {
                            Tbqueuehist.H_Date,
                            Tbservice.ServID,
                            Tbservice.ServiceFullName
                        }
                        into TS
                        orderby TS.Key.ServID ascending
                        orderby TS.Key.H_Date ascending
                        select new ReportcatagorymonthView
                        {

                            H_Date = TS.Key.H_Date,
                            ServID = TS.Key.ServID,
                            ServiceFullName = TS.Key.ServiceFullName,
                            H_Number = (TS.Count(p => p.Tbqueuehist.H_Number !=null)).ToString()
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
