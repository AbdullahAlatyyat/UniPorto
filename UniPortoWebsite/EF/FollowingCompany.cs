using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.EF
{
    public partial class FollowingCompany
    {
        public int id { get; set; }

        public int ProfileId { get; set; }

        public int CompanyId { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Profile Profile1 { get; set; }
    }
}