using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniPortoWindowsPhone.EF
{
    public partial class Profile
    {
     

        public int Id { get; set; }

        [StringLength(10)]
        public string PhoneNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(128)]
        public string SecurityID { get; set; }

        public int ProfileTypeID { get; set; }

        public int ProfileStatusID { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public string Skills { get; set; }

        public string interests { get; set; }

        public string Hobbies { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Major { get; set; }

        [StringLength(50)]
        public string stuentId { get; set; }

        public DateTime? DateOfBirthday { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public string ProfilePic { get; set; }

        public string ProfileCover { get; set; }

    
}
}
