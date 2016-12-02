using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReportcatagorydayController : Controller
    {
        private QueueReportDbContent db = new QueueReportDbContent();
        sumallDbContext sd = new sumallDbContext();

        // GET: RSCDs
        public ActionResult Index(string Date = "")
        {
            var model = db.RSCDS.Where(c => c.H_Date == Date).OrderBy(d => d.ServID);
            var sum = sd.Sumalls.Where(c => c.H_Date == Date);
            ViewBag.sum = sum;
            ViewBag.Date = Date;           
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
