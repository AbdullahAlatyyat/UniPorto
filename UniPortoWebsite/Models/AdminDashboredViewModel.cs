﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;

namespace Graduation.UniPortoWebsite.Models
{
    public class AdminDashboredViewModel
    {
        public List<Profile> ListOfUsers { get; set; }
        public List<Profile> ListOfPendingUsers { get; set; }
    }
}