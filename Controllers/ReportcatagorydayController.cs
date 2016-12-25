using System.Linq;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReportcatagorydayController : Controller
    {
        private QueueReportDbContent db = new QueueReportDbContent();
        private sumallDbContext _sd = new sumallDbContext();

        // GET: RSCDs
        public ActionResult Index(string date = "")
        {
            var model = db.RSCDS.Where(c => c.H_Date == date).OrderBy(d => d.ServID);
            var sum = _sd.Sumalls.Where(c => c.H_Date == date);
            ViewBag.sum = sum;
            ViewBag.Date = date;           
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                //_sd.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
