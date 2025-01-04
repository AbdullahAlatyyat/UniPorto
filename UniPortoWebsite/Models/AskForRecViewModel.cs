using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF.Enums;

namespace UniPortoWebsite.Models
{
    public class AskForRecViewModel
    {
        public int ActivityId { get; set; }
        public int InstructorId { get; set; }
        public int CompanyId { get; set; }  
        public string RequesterMessage { get; set; } 

    }
    public class RecomenderProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}