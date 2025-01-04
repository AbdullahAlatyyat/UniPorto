using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;

namespace UniPortoWebsite.Models
{
    public class PortoProfileViewModel
    {
        public List<ActivityViewModel> allActivities { get; set; }
        public Profile UserProfile { get; set; }
    }

}