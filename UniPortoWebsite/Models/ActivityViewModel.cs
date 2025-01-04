using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;

namespace UniPortoWebsite.Models
{
    public class ActivityViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        public int? AttachmentsTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AttachmentUrl { get; set; }
        public string DateOfActivity { get; set; } = "Choose Date of Your Event";
        public List<ActivityViewModel> allActivities { get; set; }
        public int ActivityId { get; set; }
    }
}