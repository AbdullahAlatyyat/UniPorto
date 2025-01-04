using GraduationProject.WebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.WebAPI.Manger
{
    public class ProfileManger
    {
        static ProfileRepository respository = new ProfileRepository();
        public static int AddProfile(Profile newProfile)
        {
            return respository.AddProfile(newProfile);
        }
        public static bool UpdateProfile(Profile toUpdateProfile)
        {
            return respository.UpdateProfile(toUpdateProfile);
        }
        public static bool DeleteProfile(int id)
        {
            return respository.DeleteProfile(id);
        }
        public static Profile GetProfileById(int id)
        {
            return respository.GetProfileById(id);
        }
        public static List<Profile> GetAllProfiles()
        {
            return respository.GetAllProfiles();
        }

       
    }
}