using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectDescription { get; set; }

        [StringLength(250)]
        public string ProjectImage { get; set; }

        [Column(TypeName = "date")]
        public DateTime ProjectDate { get; set; }

        public int profileId { get; set; }

        public virtual Profile Profile { get; set; }
    }
}