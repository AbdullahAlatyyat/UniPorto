using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.Models
{
    public class EditProfileViewModel
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string PhoneNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string City { get; set; }

        public string Skills { get; set; }

        public string intersts { get; set; }
        public string Major { get; set; }
        public string Hobbies { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        public DateTime? DateOfBirthday { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }
    }
}