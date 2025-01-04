using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.EF.Enums;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class ProfileManager.
    /// </summary>
    public class ProfileManager
    {
        /// <summary>
        /// The respository
        /// </summary>
        static ProfileRepository respository = new ProfileRepository();
        /// <summary>
        /// Adds the profile.
        /// </summary>
        /// <param name="newProfile">The new profile.</param>
        /// <returns>System.Int32.</returns>
        public static int AddProfile(Profile newProfile)
        {
            return respository.AddProfile(newProfile);
        }

        /// <summary>
        /// Deletes the profile.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteProfile(int id)
        {
            return respository.DeleteProfile(id);
        }
        /// <summary>
        /// Deletes the profile and ASP security.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        //public static bool DeleteProfileAndASPSecurity(int id)
        //{
        //    return respository.DeleteProfileAndASPSecurity(id);
        //}

        /// <summary>
        /// Gets the profile by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Profile.</returns>
        public static Profile GetProfileById(int id)
        {
            return respository.GetProfileById(id);
        }

        /// <summary>
        /// Gets all profiles.
        /// </summary>
        /// <returns>List&lt;Profile&gt;.</returns>
        public static List<Profile> GetAllProfiles()
        {
            return respository.GetAllProfiles();
        }

        /// <summary>
        /// Updates the profile.
        /// </summary>
        /// <param name="toUpdateProfile">To update profile.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateProfile(Profile toUpdateProfile)
        {
            return respository.UpdateProfile(toUpdateProfile);
        }
        /// <summary>
        /// Updates the profile by admin.
        /// </summary>
        /// <param name="toUpdateProfile">To update profile.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateProfileByAdmin(Profile toUpdateProfile)
        {
            return respository.UpdateProfileByAdmin(toUpdateProfile);
        }

        /// <summary>
        /// Deletes the request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteRequest(int id)
        {
            return respository.DeleteRequest(id);
        }
        /// <summary>
        /// Actives the request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ActiveRequest(int id)
        {
            return respository.ActiveRequest(id);
        }
        /// <summary>
        /// Accepts the status request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AcceptStatusRequest(int id)
        {
            return respository.AcceptStatusRequest(id);
        }

        /// <summary>
        /// Gets the requests.
        /// </summary>
        /// <returns>List&lt;ChangeStatusPending&gt;.</returns>
        //public static List<ChangeStatusPending> GetRequests()
        //{
        //    return respository.GetRequests();
        //}

        /// <summary>
        /// Gets the profile by security identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Profile.</returns>
        public static Profile GetProfileBySecurityId(string id)
        {
            return respository.GetProfileBySecurityId(id);
        }

        /// <summary>
        /// Gets all profile following company.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns>List&lt;FollowingCompany&gt;.</returns>
        //public static List<FollowingCompany> getAllProfileFollowingCompany(int profileId)
        //{
        //    return respository.getAllProfileFollowingCompany(profileId);
        //}

        /// <summary>
        /// Gets all profiles by type identifier.
        /// </summary>
        /// <param name="profileType">Type of the profile.</param>
        /// <returns>List&lt;Profile&gt;.</returns>
        public static List<Profile> GetAllProfilesByTypeId(ProfileTypes profileType)
        {
            return respository.GetAllProfilesByTypeId(profileType);
        }
    }
}