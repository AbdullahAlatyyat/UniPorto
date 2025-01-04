namespace Graduation.Website
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Uni_PortoContext : DbContext
    {
        public Uni_PortoContext()
            : base("name=UniPortoContext")
        {
        }

        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileType> ProfileTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Secondname)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Thirdname)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.PhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<ProfileType>()
                .HasMany(e => e.Profiles)
                .WithRequired(e => e.ProfileType)
                .WillCascadeOnDelete(false);
        }
    }
}
