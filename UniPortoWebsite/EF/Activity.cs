namespace UniPortoWebsite.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Activity")]
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            ActivityAttachments = new HashSet<ActivityAttachment>();
            PeopleInActivities = new HashSet<PeopleInActivity>();
            Recommendations = new HashSet<Recommendation>();
            RecommendationQueue = new HashSet<RecommendationQueue>();

        }

        public int Id { get; set; }

        public int ProfileId { get; set; }

        [Required]
        public string Contant { get; set; }

        public int? AttachmentsTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Profile Profile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityAttachment> ActivityAttachments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeopleInActivity> PeopleInActivities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        public virtual ICollection<RecommendationQueue> RecommendationQueue { get; set; }

    }
}
