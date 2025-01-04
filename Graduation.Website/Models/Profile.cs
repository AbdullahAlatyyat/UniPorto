using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graduation.Website.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string MobileNumber { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
    }
}