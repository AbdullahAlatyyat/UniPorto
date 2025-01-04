namespace UniPortoWebAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FollowingCompany
    {
        public int id { get; set; }

        public int ProfileId { get; set; }

        public int CompanyId { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Profile Profile1 { get; set; }
    }
}
