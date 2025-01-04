﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniPortoWebAPI.Models
{
    public class ProfileAPIModel
    {
        public int Id { get; set; }


        public string PhoneNo { get; set; }


        public string Email { get; set; }

        public string SecurityID { get; set; }

        public string ProfileImage { get; set; }

        public string FullName { get; set; }

        public string City { get; set; }

        public string Skills { get; set; }

        public string intersts { get; set; }

        public string Hobbies { get; set; }


        public string Address { get; set; }

        public string Major { get; set; }

        public string stuentId { get; set; }

        public DateTime? DateOfBirthday { get; set; }

        public string Gender { get; set; }

        public string ProfilePic { get; set; }

        public string ProfileCover { get; set; }
    }
}