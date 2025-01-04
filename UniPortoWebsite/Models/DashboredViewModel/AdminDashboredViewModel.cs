using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;

namespace UniPortoWebsite.Models.DashboredViewModel
{
    public class AdminDashboredViewModel
    {
        public List<Profile> RegisterPendingUsers { get; set; }
        public List<ChangeStatusPending> StatusPendingUsers { get; set; }
        public List<Profile> NewestUsers { get; set; }
        public int StudentsAndAlumniCount { get; set; }
        public int CompaniesCount { get; set; }
        public int instructorCount { get; set; }
        public int PendingCount { get; set; }
    }
}