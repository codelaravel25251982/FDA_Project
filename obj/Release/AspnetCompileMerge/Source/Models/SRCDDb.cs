namespace BeyondThemes.BeyondAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SRCDDb : DbContext
    {
        public SRCDDb()
            : base("name=SRCDDb")
        {
        }

        public virtual DbSet<RSCD> RSCDS { get; set; }
        public virtual DbSet<tbService> tbServices { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}