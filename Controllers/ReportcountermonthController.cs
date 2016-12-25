using System;
using System.Linq;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Reportcounterday;

namespace BeyondThemes.BeyondAdmin.Controllers
{
   
    public class ReportcountermonthController : Controller
    {
        public string SDate = "";
        public string SMonth = "";
        public string SYear = "";
        public string CDate = "";
           QueueReportDbCounterContent _db = new QueueReportDbCounterContent();
        // GET: Reportcounterday
        public ActionResult Index(string month, string year)
        {
            string m = "";
            year = (Convert.ToInt32(year) - 543).ToString();
            var model = from tbcounter in _db.TbCounters
                join tbQueueHist in _db.TbQueueHists on tbcounter.CounterNo equals tbQueueHist.H_Counter
                where tbQueueHist.H_Date.Substring(4, 2) == month && tbQueueHist.H_Date.Substring(0, 4) == year && tbQueueHist.H_cometime < tbQueueHist.H_Servetime && tbQueueHist.H_Servetime < tbQueueHist.H_endtime
                group new
                {
                    tbQueueHist,
                    tbcounter.CounterName
                }
                by new
                {
                    tbcounter.CounterNo,
                    tbcounter.CounterName
                }
                into ts
                orderby ts.Key.CounterNo ascending
                select new ReportcounterdayView()
                {
                    CounterNo = ts.Key.CounterNo,
                    CounterName = ts.Key.CounterName,
                    HNumber = (ts.Count(p => p.tbQueueHist.H_Number != null)).ToString(),
                    WaitAvgTime = ts.Sum(p => p.tbQueueHist.H_Servetime - p.tbQueueHist.H_cometime),
                    WaitMinTime = ts.Min(p => p.tbQueueHist.H_Servetime - p.tbQueueHist.H_cometime),
                    WaitMaxTime = ts.Max(p => p.tbQueueHist.H_Servetime - p.tbQueueHist.H_cometime),
                    ServiceAvgTime = ts.Sum(p => p.tbQueueHist.H_endtime - p.tbQueueHist.H_Servetime),
                    ServiceMinTime = ts.Min(p => p.tbQueueHist.H_endtime - p.tbQueueHist.H_Servetime),
                    ServiceMaxTime = ts.Max(p => p.tbQueueHist.H_endtime - p.tbQueueHist.H_Servetime),
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
            ViewBag.m = m + " " + (Convert.ToInt32(year) + 543).ToString();

            return View(model);
        }

        
    }
}