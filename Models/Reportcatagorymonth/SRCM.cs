namespace BeyondThemes.BeyondAdmin.Models.Reportcatagorymonth
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SRCM : DbContext
    {
        public SRCM()
            : base("name=QueueReport")
        {
        }

        public virtual DbSet<tbQueueHist> tbQueueHist { get; set; }
        public virtual DbSet<tbService> tbService { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbService>()
                .Property(e => e.ServiceFullName)
                .IsUnicode(false);
        }

        
    }
}
