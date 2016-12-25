using System.Linq;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Reportcounterday;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReportcounterdayController : Controller
    {
       QueueReportDbCounterContent _db = new QueueReportDbCounterContent();
        // GET: Reportcounterday
        public ActionResult Index(string date ="04/08/2016")
        {
            string sDate = date.Substring(0, 2);
            string sMonth = date.Substring(3, 2);
            string sYear = date.Substring(6, 4);
            string cDate = sYear + sMonth + sDate;
            var model = from tbcounter in _db.TbCounters
                join tbQueueHist in _db.TbQueueHists on tbcounter.CounterNo equals tbQueueHist.H_Counter
                where tbQueueHist.H_Date == cDate
                group new
                {
                    tbQueueHist,
                    tbcounter
                }
                by new
                {
                    tbQueueHist.H_Date,
                    tbcounter.CounterNo,
                    tbcounter.CounterName
                }
                into ts
                orderby ts.Key.CounterNo ascending
                orderby ts.Key.H_Date ascending
                select new ReportcounterdayView()
                {

                    HDate = ts.Key.H_Date,
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
            ViewBag.Date = cDate;

            return View(model);
        }

        
    }
}