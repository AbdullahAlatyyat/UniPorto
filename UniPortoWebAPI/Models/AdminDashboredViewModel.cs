﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;

namespace Graduation.UniPortoWebAPI.Models
{
    public class AdminDashboredViewModel
    {
        public List<Profile> ListOfUsers { get; set; }
        public List<Profile> ListOfPendingUsers { get; set; }
    }
}