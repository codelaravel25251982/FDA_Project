namespace BeyondThemes.BeyondAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QueueReportDbContent : DbContext
    {
        public QueueReportDbContent()
            : base("name=QueueReport")
        {
        }

        public virtual DbSet<RSCD> RSCDS { get; set; }
        public virtual DbSet<tbService> tbServices { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.Reportcounterday.ReportcounterdayView> ReportcounterdayViews { get; set; }
    }
}