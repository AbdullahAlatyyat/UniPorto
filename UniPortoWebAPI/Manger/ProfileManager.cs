using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.EF.Enums;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public class ProfileManager
    {
        static ProfileRepository respository = new ProfileRepository();
        public static int AddProfile(Profile newProfile)
        {
            return respository.AddProfile(newProfile);
        }

        public static bool DeleteProfile(int id)
        {
            return respository.DeleteProfile(id);
        }
        public static bool DeleteProfileAndASPSecurity(int id)
        {
            return respository.DeleteProfileAndASPSecurity(id);
        }

        public static Profile GetProfileById(int id)
        {
            return respository.GetProfileById(id);
        }

        public static List<Profile> GetAllProfiles()
        {
            return respository.GetAllProfiles();
        }

        public static bool UpdateProfile(Profile toUpdateProfile)
        {
            return respository.UpdateProfile(toUpdateProfile);
        }
        public static bool DeleteRequest(int id)
        {
            return respository.DeleteRequest(id);
        }
        public static bool ActiveRequest(int id)
        {
            return respository.ActiveRequest(id);
        }
        public static bool AcceptStatusRequest(int id)
        {
            return respository.AcceptStatusRequest(id);
        }
        
        public static List<ChangeStatusPending> GetRequests()
        {
            return respository.GetRequests();
        }

        public static Profile GetProfileBySecurityId(string id)
        {
            return respository.GetProfileBySecurityId(id);
        }
    }
}