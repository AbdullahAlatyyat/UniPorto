using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniPortoWebAPI.Models
{
    public class ActivityAPIModel
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Status { get; set; }
        public int? AttachmentsTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AttachmentUrl { get; set; }
        public HttpPostedFileBase file { get; set; }
        public string  DateOfActivity { get; set; }
        public List<ActivityAPIModel> allActivities { get; set; }
    }
}