using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public class ProfileStudyInfoManager
    {
        static ProfileStudyInfoRepository respository = new ProfileStudyInfoRepository();
        public static List<ProfileStudyInfo> GetAlllanguage()
        {
            var res = respository.GetAllLanguage();
            return res;

        }
        public static int AddProfileStudyInfo(ProfileStudyInfo profileStudyInfo)
        {
            var res = respository.AddProfileStudyInfo(profileStudyInfo);

            return res;

        }

        public static bool DeleteProfileStudyInfo(int id)
        {
            var res = respository.DeleteProfileStudyInfo(id);

            return res;

        }

        public static bool EditProfileStudyInfoe(ProfileStudyInfo profileStudyInfo)
        {
            var res = respository.EditProfileStudyInfo(profileStudyInfo);

            return res;

        }

        public static ProfileStudyInfo GetProfileStudyInfoByID(int id)
        {
            var res = respository.GetProfileStudyInfoByID(id);

            return res;

        }

        
    }
}