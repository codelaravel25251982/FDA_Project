namespace BeyondThemes.BeyondAdmin.Models.Configcounter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Configcounter : DbContext
    {
        public Configcounter()
            : base("name=QueueReport")
        {
        }

        public virtual DbSet<tbCounter> tbCounter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
