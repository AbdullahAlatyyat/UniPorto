

namespace UniPortoWebsite.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Experiance")]
    public partial class Experiance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        [Required]
        [StringLength(300)]
        public string CompanyName { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int profileId { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual Profile Profile { get; set; }
    }
}