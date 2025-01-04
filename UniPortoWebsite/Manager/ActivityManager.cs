using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class ActivityManager.
    /// </summary>
    public static class ActivityManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        static ActivityRepository repository = new ActivityRepository();
        /// <summary>
        /// Gets all ativities.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns>List&lt;Activity&gt;.</returns>
        public static List<Activity> GetAllAtivities(int profileId)
        {
            var res = repository.GetAllAtivities(profileId);
            return res;
        }
        /// <summary>
        /// Gets the ativity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Activity.</returns>
        public static Activity GetAtivityById(int id)
        {
            var res = repository.GetAtivityById(id);
            return res;

        }

        /// <summary>
        /// Deletes the activity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteActivity(int id)
        {
            var res = repository.DeleteActivity(id);
            return res;

        }
        /// <summary>
        /// Updates the activity.
        /// </summary>
        /// <param name="newActivity">The new activity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateActivity(Activity newActivity)
        {
            var res = repository.UpdateActivity(newActivity);
            return res;

        }
        /// <summary>
        /// Adds the activity.
        /// </summary>
        /// <param name="newActivity">The new activity.</param>
        /// <returns>Activity.</returns>
        public static Activity AddActivity(Activity newActivity)
        {
            var res = repository.AddActivity(newActivity);
            return res;
        }
        /// <summary>
        /// Gets the last3 activity by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns>List&lt;Activity&gt;.</returns>
        public static List<Activity> GetLast3ActivityByProfileId(int profileId)
        {
            var res = repository.GetLast3ActivityByProfileId(profileId);
            return res;

        }
    }
}