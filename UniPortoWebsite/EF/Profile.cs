namespace UniPortoWebsite.EF
{
    using global::UniPortoWebsite.EF;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Profile")]
    public partial class Profile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profile()
        {
            Activities = new HashSet<Activity>();
            ChangeStatusPendings = new HashSet<ChangeStatusPending>();
            Experiances = new HashSet<Experiance>();
            FollowingCompanies = new HashSet<FollowingCompany>();
            FollowingCompanies1 = new HashSet<FollowingCompany>();
            Languages = new HashSet<Language>();
            PeopleInActivities = new HashSet<PeopleInActivity>();
            ProfileStudyInfoes = new HashSet<ProfileStudyInfo>();
            Projects = new HashSet<Project>();
            Recommendations = new HashSet<Recommendation>();
            RecommendationQueue = new HashSet<RecommendationQueue>();

        }

        public int Id { get; set; }

        [StringLength(10)]
        public string PhoneNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(128)]
        public string SecurityID { get; set; }
        [Display(Name = "Account Type")]
        public int ProfileTypeID { get; set; }

        public int ProfileStatusID { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public string Skills { get; set; }

        public string intersts { get; set; }

        public string Hobbies { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Major { get; set; }

        [StringLength(50)]
        public string stuentId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirthday { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public string ProfilePic { get; set; }
        public string ProfileCover { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activities { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeStatusPending> ChangeStatusPendings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experiance> Experiances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FollowingCompany> FollowingCompanies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FollowingCompany> FollowingCompanies1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Languages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleInActivity> PeopleInActivities { get; set; }

        public virtual ProfileStatu ProfileStatu { get; set; }
        public IEnumerable<SelectListItem> ProfileTypes { get; set; }
        public IEnumerable<SelectListItem> ProfileStatus { get; set; }


        public virtual ProfileType ProfileType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfileStudyInfo> ProfileStudyInfoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        public virtual ICollection<RecommendationQueue> RecommendationQueue { get; set; }
    }
}