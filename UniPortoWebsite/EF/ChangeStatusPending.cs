
namespace UniPortoWebsite.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChangeStatusPending")]
    public partial class ChangeStatusPending
    {
        public int id { get; set; }

        public int ProfileId { get; set; }

        public int? CurrentStatus { get; set; }

        public int? NewStatus { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ProfileType ProfileType { get; set; }
    }
}