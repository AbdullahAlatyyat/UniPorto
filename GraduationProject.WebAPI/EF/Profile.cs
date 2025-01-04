namespace GraduationProject.WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profile
    {
        public int ID { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(150)]
        public string JobTitle { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        public int CityID { get; set; }

        public int CountryID { get; set; }

        //public virtual City City { get; set; }

        //public virtual Country Country { get; set; }
    }
}
