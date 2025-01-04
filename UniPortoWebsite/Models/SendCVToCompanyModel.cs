using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniPortoWebsite.Models
{
    public class SendCVToCompanyModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string FullName { get; set; }
        [Required]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Message { get; set; }
        [RegularExpression("^((\\+)|(00)|(\\*)|())[0-9]{3,14}((\\#)|())$", ErrorMessage = "Please enter valid Number")]
        [Required]
        public string PhoneNo { get; set; }
        public string CVAttachmentURL { get; set; }
        public int offerId { set; get; }


    }
}