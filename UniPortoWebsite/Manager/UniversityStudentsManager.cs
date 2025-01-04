using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class UniversityStudentsManager.
    /// </summary>
    public class UniversityStudentsManager
    {
        /// <summary>
        /// The respository
        /// </summary>
        static UniversityStudentsRepository respository = new UniversityStudentsRepository();
        /// <summary>
        /// Checks the studet.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>UniversityStudent.</returns>
        public static UniversityStudent CheckTheStudet(string username)
        {
            return respository.CheckTheStudet(username);
        }
    }
}