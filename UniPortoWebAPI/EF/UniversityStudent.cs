namespace UniPortoWebAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UniversityStudent
    {
        [Key]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Major { get; set; }

        [StringLength(50)]
        public string idnumber { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string department { get; set; }
    }
}
