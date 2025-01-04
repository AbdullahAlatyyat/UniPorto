using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Manager;
using UniPortoWebsite.Models;

namespace UniPortoWebsite.Helpers
{
    public static class UniPortoContext
    {
        public static Profile LoggedInUser
        {
            get
            {
                var um = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(new ApplicationDbContext()));
                var user = um.Users.Where(p => p.UserName == Thread.CurrentPrincipal.Identity.Name).SingleOrDefault();
                var profile = new Profile();
                if (user!=null)
                {
                     profile = ProfileManager.GetProfileBySecurityId(user.Id);
                }
                return profile;
            }
        }
    }
}