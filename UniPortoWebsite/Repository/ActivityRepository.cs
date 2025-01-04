using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository.Context;
using System.Data.Entity;


/// <summary>
/// 
/// </summary>
namespace UniPortoWebsite.Repository
{
    public class ActivityRepository
    {
        /// <summary>
        /// Gets all ativities.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting All Activities
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting All Activities
        /// </exception>
        public List<Activity> GetAllAtivities(int profileId)
        {
            try
            {
                UniPorto modle = new UniPorto();
                var res = modle.Activities.Where(p=> p.ProfileId == profileId).Include(p => p.ActivityAttachments).ToList();
                return res.OrderByDescending(p=>p.CreatedOn).ToList();
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting All Activities ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting All Activities ", ex);
            }
        }
        /// <summary>
        /// Gets the ativity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting By ID  Activities
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting By ID Activities
        /// </exception>
        public Activity GetAtivityById(int id)
        {
             try
            {
                var model = new UniPorto();
               var res =   model.Activities.Include(p=>p.Recommendations).Include(pr => pr.ActivityAttachments).Include(p=>p.Profile).Where(p => p.Id == id).SingleOrDefault();
                return res ;

               
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting By ID  Activities ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting By ID Activities ", ex);
            }
        }
        /// <summary>
        /// Deletes the activity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Delete  Activities
        /// or
        /// UNEXPECTED EXCEPTION WHILE Delete  Activities
        /// </exception>
        public bool DeleteActivity (int id)
        {
            bool isDeleted = false;

            try
            {
                var model = new UniPorto();
                var res = model.Activities.Find(id);
                model.Activities.Remove(res);
                model.SaveChanges();
                isDeleted = true;
                return isDeleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Delete  Activities ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Delete  Activities ", ex);
            }
        }
        /// <summary>
        /// Adds the activity.
        /// </summary>
        /// <param name="newActivity">The new activity.</param>
        /// <returns></returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Add Activities
        /// or
        /// UNEXPECTED EXCEPTION WHILE Add Activities
        /// </exception>
        public Activity AddActivity(Activity newActivity)
        {
            try
            {
                var model = new UniPorto();
                model.Activities.Add(newActivity);
                model.SaveChanges();
                return model.Activities.Include(pas => pas.ActivityAttachments).Where(p => p.Id == newActivity.Id).SingleOrDefault();


            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Add Activities ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Add Activities ", ex);
            }
        }
        /// <summary>
        /// Updates the activity.
        /// </summary>
        /// <param name="toUpdauteActivity">To updaute activity.</param>
        /// <returns></returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Updating Activity
        /// or
        /// UNEXPECTED EXCEPTION WHILE Updating Activity
        /// </exception>
        public bool UpdateActivity(Activity toUpdauteActivity )
        {
            var isUpdated = false;
            try
            {
                var model = new UniPorto();
               model.Activities.AddOrUpdate(toUpdauteActivity);
                model.SaveChanges();
                isUpdated = true;
                return isUpdated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Updating Activity", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Updating Activity", ex);
            }

        }

        /// <summary>
        /// Gets the last3 activity by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting All Activities FOR THIS PROFILE
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting All Activities FOR THIS PROFILE
        /// </exception>
        public List<Activity> GetLast3ActivityByProfileId(int profileId)
        {
            try
            {
                UniPorto modle = new UniPorto();
                var res = modle.Activities.Where(p => p.ProfileId == profileId).Include(p => p.ActivityAttachments).OrderByDescending(p=>p.CreatedOn).Take(3).ToList();
                return res.OrderByDescending(p => p.CreatedOn).ToList();
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting All Activities FOR THIS PROFILE ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting All Activities FOR THIS PROFILE ", ex);
            }
        }
        
    }
}