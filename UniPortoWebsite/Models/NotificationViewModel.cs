using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.Models
{
    public class NotificationViewModel
    {
        public int NotificationCount { get; set; }
        public List<Request> ReccomendRequests { get; set; }
    }
    public class Request
    {
        public int RequesterId { get; set; }
        public string RequesterImage { get; set; }
        public string RequesterName { get; set; }
        public string RequestCreatedOn { get; set; }
        public int RequestId { get; set; }
    }
}