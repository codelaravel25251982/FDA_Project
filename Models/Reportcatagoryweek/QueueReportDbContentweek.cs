namespace BeyondThemes.BeyondAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QueueReportDbContentweek : DbContext
    {
        public QueueReportDbContentweek()
            : base("name=QueueReport")
        {
        }

        public virtual DbSet<RSCW> RSCWS { get; set; }
        public virtual DbSet<tbService> tbServices { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}