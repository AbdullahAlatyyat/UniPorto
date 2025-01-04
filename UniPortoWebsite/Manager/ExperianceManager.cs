using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class ExperianceManager.
    /// </summary>
    public class ExperianceManager
    {
        /// <summary>
        /// The respository
        /// </summary>
        static ExperianceRepository respository = new ExperianceRepository();
        /// <summary>
        /// Gets all experiance.
        /// </summary>
        /// <returns>List&lt;Experiance&gt;.</returns>
        public static List<Experiance> GetAllExperiance()
        {
            var res = respository.GetAllExperiance();
            return res;

        }
        /// <summary>
        /// Adds the experiance.
        /// </summary>
        /// <param name="experiance">The experiance.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AddExperiance(Experiance experiance)
        {
            var res = respository.AddExperiance(experiance);

            return res;

        }

        /// <summary>
        /// Deletes the experiance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteExperiance(int id)
        {
            var res = respository.DeleteExperiance(id);

            return res;

        }

        /// <summary>
        /// Edits the experiance.
        /// </summary>
        /// <param name="experiance">The experiance.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool EditExperiance(Experiance experiance)
        {
            var res = respository.EditExperiance(experiance);

            return res;

        }

        /// <summary>
        /// Gets the experiance by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Experiance.</returns>
        public static Experiance GetExperianceByID(int id)
        {
            var res = respository.GetExperianceByID(id);

            return res;

        }
    }
}