using System;
using System.Linq;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Reportcounterday;

namespace BeyondThemes.BeyondAdmin.Controllers
{
   
    public class ReportcounterweekController : Controller
    {
        public string SDate = "";
        public string SMonth = "";
        public string SYear = "";
        public string cStart = "";
        public string end = "";
        public string SDateend = "";
        public string SMonthend = "";
        public string SYearend = "";
        public string cEnd = "";
           QueueReportDbCounterContent _db = new QueueReportDbCounterContent();
        // GET: Reportcounterday
        public ActionResult Index(string start = "01/02/2559", string end = "01/02/2559", string week = "")
        {
            if (start == "" && end == "") {
                start = "01/01/2559";
                SDate = start.Substring(0, 2);
                SMonth = start.Substring(3, 2);
                SYear = (Convert.ToInt32(start.Substring(6, 4)) - 543).ToString();

                end = "01/01/2559";
                SDateend = end.Substring(0, 2);
                SMonthend = end.Substring(3, 2);
                SYearend = (Convert.ToInt32(end.Substring(6, 4)) - 543).ToString();
            }
            else
            {
                SDate = start.Substring(0, 2);
                SMonth = start.Substring(3, 2);
                SYear = (Convert.ToInt32(start.Substring(6, 4)) - 543).ToString();
                cStart = SYear + SMonth + SDate;

                SDateend = end.Substring(0, 2);
                SMonthend = end.Substring(3, 2);
                SYearend = (Convert.ToInt32(end.Substring(6, 4)) - 543).ToString();
                cEnd = SYearend + SMonthend + SDateend;
            }
            
            
            var model = _db.TbCounters.Join(_db.TbQueueHists, tbcounter => tbcounter.CounterNo,
                    tbQueueHist => tbQueueHist.H_Counter, (tbcounter, tbQueueHist) => new {tbcounter, tbQueueHist})
                .Where(@t => String.Compare(@t.tbQueueHist.H_Date, cStart, StringComparison.Ordinal) >= 0 &&
                             String.Compare(@t.tbQueueHist.H_Date, cEnd, StringComparison.Ordinal) <= 0 &&
                             @t.tbQueueHist.H_cometime < @t.tbQueueHist.H_Servetime &&
                             @t.tbQueueHist.H_Servetime < @t.tbQueueHist.H_endtime).GroupBy(@t => new
                {
                    @t.tbcounter.CounterNo,
                    @t.tbcounter.CounterName
                }, @t => new
                {
                    @t.tbQueueHist,
                    @t.tbcounter
                }).OrderBy(ts => ts.Key.CounterNo).Select(ts => new ReportcounterdayView()
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
                });
            ViewBag.Week = week;
            ViewBag.Date = start + " - " + end;

            return View(model);
        }

        
    }
}