namespace BeyondThemes.BeyondAdmin.Models.User
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Userconfig : DbContext
    {
        public Userconfig()
            : base("name=Userconfig")
        {
        }

        public virtual DbSet<tbUser> tbUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbUser>()
                .Property(e => e.LoginID)
                .IsFixedLength();

            modelBuilder.Entity<tbUser>()
                .Property(e => e.PassWord)
                .IsFixedLength();
        }
    }
}
