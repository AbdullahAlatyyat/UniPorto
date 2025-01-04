using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class RecommendationManager.
    /// </summary>
    public static class RecommendationManager
    {
        /// <summary>
        /// The respository
        /// </summary>
        static RecommendationRespository respository = new RecommendationRespository();

        /// <summary>
        /// Gets all recommendation.
        /// </summary>
        /// <returns>List&lt;Recommendation&gt;.</returns>
        public static List<Recommendation> GetAllRecommendation()
        {
            var res = respository.GetAllRecommendation();

            return res;
               
        }

        /// <summary>
        /// Adds the recommendation.
        /// </summary>
        /// <param name="recommendation">The recommendation.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AddRecommendation(Recommendation recommendation)
        {
            var res = respository.AddRecommendation(recommendation);

            return res;

        }

        /// <summary>
        /// Deletes the recommendation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteRecommendation(int id)
        {
            var res = respository.DeleteRecommendation(id);

            return res;

        }

        /// <summary>
        /// Edits the recommendation.
        /// </summary>
        /// <param name="recommendation">The recommendation.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool EditRecommendation(Recommendation recommendation)
        {
            var res = respository.EditRecommendation(recommendation);

            return res;

        }

        /// <summary>
        /// Gets the recommendation by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Recommendation.</returns>
        public static Recommendation GetRecommendationByID(int id)
        {
            var res = respository.GetRecommendationByID(id);

            return res;

        }

        /// <summary>
        /// Gets the recommendation by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Recommendation.</returns>
        public static List<Recommendation> GetRecommendationByActivityID(int activityId)
        {
            var res = respository.GetRecommendationsByActivityID(activityId);

            return res;

        }

    }
}