namespace UniPortoWebsite.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PeopleInActivity")]
    public partial class PeopleInActivity
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }

        public int ProfileId { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
