using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.Models
{
    public class EmailByAdminViewModel
    {
        [Display(Name = "Email To")]
        [Required]
        public string EmailTo { get; set; }
        [Display(Name = "Subject")]
        [Required]
        public string Subject { get; set; }
        [Display(Name = "Message")]
        [Required]
        public string Message { get; set; }
    }
}