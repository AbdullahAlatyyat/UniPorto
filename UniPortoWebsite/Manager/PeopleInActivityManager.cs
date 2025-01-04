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
    /// Class PeopleInActivityManager.
    /// </summary>
    public class PeopleInActivityManager
    {
        /// <summary>
        /// The respository
        /// </summary>
        static PeopleInActivityRepository respository = new PeopleInActivityRepository();
        /// <summary>
        /// Adds the people.
        /// </summary>
        /// <param name="Person">The person.</param>
        /// <returns>System.Int32.</returns>
        public static int AddPeople(PeopleInActivity Person)
        {
            return respository.AddPeople(Person);
        }

        /// <summary>
        /// Deletes the people.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeletePeople(int id)
        {
            return respository.DeletePeople(id);
        }

        /// <summary>
        /// Gets the people by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PeopleInActivity.</returns>
        public static PeopleInActivity GetPeopleById(int id)
        {
            return respository.GetPeopleById(id);
        }

        /// <summary>
        /// Gets all people.
        /// </summary>
        /// <returns>List&lt;PeopleInActivity&gt;.</returns>
        public static List<PeopleInActivity> GetAllPeople()
        {
            return respository.GetAllPeople();
        }

        /// <summary>
        /// Updates the people.
        /// </summary>
        /// <param name="toUpdatePeople">To update people.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdatePeople(PeopleInActivity toUpdatePeople)
        {
            return respository.UpdatePeople(toUpdatePeople);
        }
    }
    }