namespace GraduationProject.WebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<City>()
            //    .HasMany(e => e.Profiles)
            //    .WithRequired(e => e.City)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Country>()
            //    .HasMany(e => e.Profiles)
            //    .WithRequired(e => e.Country)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);
        }
    }
}
