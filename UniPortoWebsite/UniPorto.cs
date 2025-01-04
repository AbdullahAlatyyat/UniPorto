namespace UniPortoWebsite
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EF;

    public partial class UniPorto : DbContext
    {
        public UniPorto()
            : base("name=UniPorto")
        {
        }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ChangeStatusPending> ChangeStatusPendings { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileStatu> ProfileStatus { get; set; }
        public virtual DbSet<ProfileType> ProfileTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Profiles)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.SecurityID)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<ProfileStatu>()
                .HasMany(e => e.Profiles)
                .WithRequired(e => e.ProfileStatu)
                .HasForeignKey(e => e.ProfileStatusID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfileType>()
                .HasMany(e => e.ChangeStatusPendings)
                .WithOptional(e => e.ProfileType)
                .HasForeignKey(e => e.NewStatus);

            modelBuilder.Entity<ProfileType>()
                .HasMany(e => e.Profiles)
                .WithRequired(e => e.ProfileType)
                .WillCascadeOnDelete(false);
        }
    }
}
