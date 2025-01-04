using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.Models
{
    public class RecommendationQueueViewModel
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public int InstructorId { get; set; }

        public int ActivityId { get; set; }

        public string Message { get; set; }

        public DateTime CreateOn { get; set; }
        public string ActivityContent { get; set; }

        public string CreatedBy { get; set; }
        public string AttachmentUrl { get; set; }
        public int AttachmentsTypeId { get; set; }
        public string ProfileCity { get; set; }
        public string ProfileImage { get; set; }
        public string ProfileFullName { get; set; }

    }
}