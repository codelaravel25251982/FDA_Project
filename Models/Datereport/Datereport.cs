namespace BeyondThemes.BeyondAdmin.Models.Datereport
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Datereport : DbContext
    {
        public Datereport()
            : base("name=QueueReport")
        {
        }

        public virtual DbSet<tbService> tbService { get; set; }
        public virtual DbSet<tbQueueHist> tbQueueHist { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbService>()
                .Property(e => e.ServiceFullName)
                .IsUnicode(false);
        }
    }
}
