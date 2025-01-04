namespace UniPortoWebAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AvalibleLanguage
    {
        [Key]
        [StringLength(50)]
        public string Language { get; set; }
    }
}
