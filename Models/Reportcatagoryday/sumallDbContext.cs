namespace BeyondThemes.BeyondAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class sumallDbContext : DbContext
    {
        public sumallDbContext()
            : base("name=QueueReport")
        {
        }

        public virtual DbSet<Sumall> Sumalls { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
