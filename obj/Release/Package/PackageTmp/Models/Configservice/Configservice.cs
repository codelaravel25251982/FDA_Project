namespace BeyondThemes.BeyondAdmin.Models.Configservice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Configservice : DbContext
    {
        public Configservice()
            : base("name=Configservice")
        {
        }

        public virtual DbSet<tbService> tbService { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbService>()
                .Property(e => e.ServiceFullName)
                .IsUnicode(false);
        }
    }
}
