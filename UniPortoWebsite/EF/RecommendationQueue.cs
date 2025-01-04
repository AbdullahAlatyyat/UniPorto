
namespace UniPortoWebsite.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RecommendationQueue")]
    public partial class RecommendationQueue
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public int InstructorId { get; set; }

        public int ActivityId { get; set; }

        [StringLength(150)]
        public string Message { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateOn { get; set; }

        [Required]
        [StringLength(150)]
        public string CreatedBy { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Profile Profile { get; set; }
    }
}