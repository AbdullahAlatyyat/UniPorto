namespace UniPortoWebAPI.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UniPorto : DbContext
    {
        public UniPorto()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityAttachment> ActivityAttachments { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AttachmentsType> AttachmentsTypes { get; set; }
        public virtual DbSet<AvalibleLanguage> AvalibleLanguages { get; set; }
        public virtual DbSet<ChangeStatusPending> ChangeStatusPendings { get; set; }
        public virtual DbSet<CompanyAd> CompanyAds { get; set; }
        public virtual DbSet<Experiance> Experiances { get; set; }
        public virtual DbSet<FollowingCompany> FollowingCompanies { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<PeopleInActivity> PeopleInActivities { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileStatu> ProfileStatus { get; set; }
        public virtual DbSet<ProfileStudyInfo> ProfileStudyInfoes { get; set; }
        public virtual DbSet<ProfileType> ProfileTypes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UniversityStudent> UniversityStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ActivityAttachments)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.PeopleInActivities)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<AttachmentsType>()
                .HasMany(e => e.ActivityAttachments)
                .WithRequired(e => e.AttachmentsType1)
                .HasForeignKey(e => e.AttachmentsType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AvalibleLanguage>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.PhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Activities)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Experiances)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.FollowingCompanies)
                .WithRequired(e => e.Profile)
                .HasForeignKey(e => e.ProfileId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.FollowingCompanies1)
                .WithRequired(e => e.Profile1)
                .HasForeignKey(e => e.CompanyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Languages)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.PeopleInActivities)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.ProfileStudyInfoes)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Recommendations)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<UniversityStudent>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<UniversityStudent>()
                .Property(e => e.Major)
                .IsUnicode(false);

            modelBuilder.Entity<UniversityStudent>()
                .Property(e => e.idnumber)
                .IsUnicode(false);

            modelBuilder.Entity<UniversityStudent>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
