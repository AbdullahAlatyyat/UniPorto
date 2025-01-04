using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository.Context;

namespace UniPortoWebsite.Repository
{
    /// <summary>
    /// Class RecommendationRespository.
    /// </summary>
    public class RecommendationRespository
    {
        /// <summary>
        /// Gets all recommendation.
        /// </summary>
        /// <returns>List&lt;Recommendation&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING ALL RECOMMENDATIONS
        /// or
        /// UNEXPECTED EXCEPTION WHILE GETTING ALL RECOMMENDATIONS
        /// </exception>
        public List<Recommendation> GetAllRecommendation()
        {
           
            try
            {
                UniPorto model = new UniPorto();

                var res = model.Recommendations.ToList();

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING ALL RECOMMENDATIONS ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING ALL RECOMMENDATIONS", ex);
            }
        }

        /// <summary>
        /// Gets the recommendation by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Recommendation.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING RECOMMENDATIONS BY ID
        /// or
        /// UNEXPECTED EXCEPTION WHILE GETTING RECOMMENDATIONS BY ID
        /// </exception>
        public Recommendation GetRecommendationByID(int id)
        {

            try
            {
                UniPorto model = new UniPorto();

                var res = model.Recommendations.Find(id);

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING RECOMMENDATIONS BY ID ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING RECOMMENDATIONS BY ID", ex);
            }
        }

        /// <summary>
        /// Adds the recommendation.
        /// </summary>
        /// <param name="recommendation">The recommendation.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING ADDING  RECOMMENDATION
        /// or
        /// UNEXPECTED EXCEPTION WHILE ADDING  RECOMMENDATION
        /// </exception>
        public bool AddRecommendation(Recommendation recommendation)
        {
            bool added = false;

            try
            {
                UniPorto model = new UniPorto();

                model.Recommendations.Add(recommendation);
                model.SaveChanges();
                added = true;

                return added;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING ADDING  RECOMMENDATION ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE ADDING  RECOMMENDATION", ex);
            }
        }

        /// <summary>
        /// Deletes the recommendation.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE DELETING RECOMMENDATION
        /// or
        /// UNEXPECTED EXCEPTION WHILE DELETING RECOMMENDATION
        /// </exception>
        public bool DeleteRecommendation(int Id)
        {
            bool Deleted = false;

            try
            {
                UniPorto model = new UniPorto();
                var obj =model.Recommendations.Find(Id);
                model.Recommendations.Remove(obj);
                model.SaveChanges();
                Deleted = true;

                return Deleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE DELETING RECOMMENDATION ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE DELETING RECOMMENDATION", ex);
            }
        }

        /// <summary>
        /// Edits the recommendation.
        /// </summary>
        /// <param name="recommendation">The recommendation.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE UPDATING RECOMMENDATION
        /// or
        /// UNEXPECTED EXCEPTION WHILE UPDATING RECOMMENDATION
        /// </exception>
        public bool EditRecommendation(Recommendation recommendation)
        {
            bool Updated = false;

            try
            {
                UniPorto model = new UniPorto();
               model.Recommendations.AddOrUpdate(recommendation);
                model.SaveChanges();
                Updated = true;

                return Updated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE UPDATING RECOMMENDATION ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE UPDATING RECOMMENDATION", ex);
            }
        }

        public List<Recommendation> GetRecommendationsByActivityID(int activityId)
        {

            try
            {
                List<Recommendation> res = new List<Recommendation>();
                using (var context = new UniPorto())
                {
                 res = context.Recommendations.Include(p=>p.Profile).Where(p=>p.ActivityId== activityId).ToList();
                }
                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING RECOMMENDATIONS BY ID ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING RECOMMENDATIONS BY ID", ex);
            }
        }
    }
}