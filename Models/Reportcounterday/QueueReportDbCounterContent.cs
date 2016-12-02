namespace BeyondThemes.BeyondAdmin.Models.Reportcounterday
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QueueReportDbCounterContent : DbContext
    {
        public QueueReportDbCounterContent()
            : base("name=QueueReport")
        {
        }

        //public virtual DbSet<ReportcounterdayView> ReportcounterdayViews { get; set; }
        public virtual DbSet<TbCounter> TbCounters { get; set; }

        public virtual DbSet<TbQueueHist> TbQueueHists { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }


}