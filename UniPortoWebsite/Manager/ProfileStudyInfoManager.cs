using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class ProfileStudyInfoManager.
    /// </summary>
    public class ProfileStudyInfoManager
    {
        /// <summary>
        /// The respository
        /// </summary>
        static ProfileStudyInfoRepository respository = new ProfileStudyInfoRepository();
        /// <summary>
        /// Gets all study information.
        /// </summary>
        /// <returns>List&lt;ProfileStudyInfo&gt;.</returns>
        public static List<ProfileStudyInfo> GetAllStudyInfo()
        {
            var res = respository.GetAllStudyInfo();
            return res;

        }
        /// <summary>
        /// Adds the profile study information.
        /// </summary>
        /// <param name="profileStudyInfo">The profile study information.</param>
        /// <returns>System.Int32.</returns>
        public static int AddProfileStudyInfo(ProfileStudyInfo profileStudyInfo)
        {
            var res = respository.AddProfileStudyInfo(profileStudyInfo);

            return res;

        }

        /// <summary>
        /// Deletes the profile study information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteProfileStudyInfo(int id)
        {
            var res = respository.DeleteProfileStudyInfo(id);

            return res;

        }

        /// <summary>
        /// Edits the profile study information.
        /// </summary>
        /// <param name="profileStudyInfo">The profile study information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool EditProfileStudyInfo(ProfileStudyInfo profileStudyInfo)
        {
            var res = respository.EditProfileStudyInfo(profileStudyInfo);

            return res;

        }

        /// <summary>
        /// Gets the profile study information by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProfileStudyInfo.</returns>
        public static ProfileStudyInfo GetProfileStudyInfoByID(int id)
        {
            var res = respository.GetProfileStudyInfoByID(id);

            return res;

        }

        
    }
}