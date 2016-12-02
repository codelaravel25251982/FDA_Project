namespace BeyondThemes.BeyondAdmin.Models.Reportcatagoryyear
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SRCY : DbContext
    {
        public SRCY()
            : base("name=SRCY")
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
