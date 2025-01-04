using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.Models
{
    public class RequestDetailsViewModel
    {
        public string RequesterProfileImage { get; set; }
        public string RequesterFullName { get; set; }
        public DateTime ActivityCreatedOn { get; set; }
        public string ActivityImageUrl { get; set; }
        public string ActivityVidUrl { get; set; }
        public string ActivityContent { get; set; }
        public string RequestMessage { get; set; }
        public string AddedRecommendation { get; set; }
    }
}