namespace BeyondThemes.BeyondAdmin.Models.Configdepartment
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Configdepartment : DbContext
    {
        public Configdepartment()
            : base("name=QueueReport")
        {
        }

        public virtual DbSet<tbDepartMent> tbDepartMent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
