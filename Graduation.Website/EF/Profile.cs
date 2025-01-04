namespace Graduation.Website
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profile")]
    public partial class Profile
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Secondname { get; set; }

        [StringLength(50)]
        public string Thirdname { get; set; }

        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        public string SecurityID { get; set; }

        public int ProfileTypeID { get; set; }

        public virtual ProfileType ProfileType { get; set; }
    }
}
