namespace BeyondThemes.BeyondAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class sumallDbContextweek : DbContext
    {
        public sumallDbContextweek()
            : base("name=QueueReport")
        {
        }

        public virtual DbSet<Sumallweek> Sumallweeks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
