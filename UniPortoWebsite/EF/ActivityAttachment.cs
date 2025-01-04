namespace UniPortoWebsite.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActivityAttachment
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int ActivityId { get; set; }

        public int AttachmentsType { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual AttachmentsType AttachmentsType1 { get; set; }
    }
}
