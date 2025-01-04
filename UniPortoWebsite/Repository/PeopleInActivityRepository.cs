using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.EF.Enums;
using UniPortoWebsite.Repository.Context;

namespace UniPortoWebsite.Repository
{
    /// <summary>
    /// Class PeopleInActivityRepository.
    /// </summary>
    public class PeopleInActivityRepository
    {
        /// <summary>
        /// Adds the people.
        /// </summary>
        /// <param name="Person">The person.</param>
        /// <returns>System.Int32.</returns>
        public int AddPeople(PeopleInActivity Person)
        {
            var model = new UniPorto();
            model.PeopleInActivities.Add(Person);
            model.SaveChanges();
            return Person.Id;
        }

        /// <summary>
        /// Deletes the people.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Deleting Person
        /// or
        /// UNEXPECTED EXCEPTION WHILE Deleting Person
        /// </exception>
        public bool DeletePeople(int id)
        {
            bool isDeleted = false;
            try
            {
                var model = new UniPorto();
                var toDeletePeople = model.PeopleInActivities.Where(mm => mm.Id == id).SingleOrDefault();
                model.PeopleInActivities.Remove(toDeletePeople);
                model.SaveChanges();
                isDeleted = true;
                return isDeleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Deleting Person", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Deleting Person", ex);
            }
        }
        /// <summary>
        /// Updates the people.
        /// </summary>
        /// <param name="toUpdatePeople">To update people.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Updating Person
        /// or
        /// UNEXPECTED EXCEPTION WHILE Updating Person
        /// </exception>
        public bool UpdatePeople(PeopleInActivity toUpdatePeople)
        {
            var isUpdated = false;
            try
            {
                var model = new UniPorto();
                var toUpdate = model.PeopleInActivities.Where(p => p.Id == toUpdatePeople.Id).SingleOrDefault();
                toUpdate.ActivityId = toUpdatePeople.ActivityId;
                toUpdate.ProfileId = toUpdatePeople.ProfileId;
                model.SaveChanges();
                isUpdated = true;
                return isUpdated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Updating Person", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Updating Person", ex);
            }
        }

        /// <summary>
        /// Gets all people.
        /// </summary>
        /// <returns>List&lt;PeopleInActivity&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Getting All People
        /// or
        /// UNEXPECTED EXCEPTION WHILE Getting All People
        /// </exception>
        public List<PeopleInActivity> GetAllPeople()
        {
            try
            {
                var model = new UniPorto();
                return model.PeopleInActivities.ToList();
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Getting All People", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Getting All People", ex);
            }
        }

        /// <summary>
        /// Gets the people by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PeopleInActivity.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Getting Personbyid
        /// or
        /// UNEXPECTED EXCEPTION WHILE Getting Personbyid
        /// </exception>
        public PeopleInActivity GetPeopleById(int id)
        {
            try
            {
                var model = new UniPorto();
                //var model1 = new 
                return model.PeopleInActivities.Where(mm => mm.Id == id).SingleOrDefault();
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Getting Personbyid", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Getting Personbyid", ex);
            }
        }
    }
}