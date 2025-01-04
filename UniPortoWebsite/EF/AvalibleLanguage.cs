using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.EF
{
    public class AvalibleLanguage
    {
        [Key]
        [StringLength(50)]
        public string Language { get; set; }
    }
}