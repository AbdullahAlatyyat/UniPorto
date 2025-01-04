namespace UniPortoWebAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfileStudyInfo")]
    public partial class ProfileStudyInfo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string School { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start { get; set; }

        [Column(TypeName = "date")]
        public DateTime Finish { get; set; }

        [Required]
        [StringLength(200)]
        public string Major { get; set; }

        public string Detalis { get; set; }

        public int ProfileId { get; set; }

        [Required]
        [StringLength(200)]
        public string StudyLevel { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
