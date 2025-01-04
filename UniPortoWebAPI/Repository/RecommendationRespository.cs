using GraduationProject.UniPortoWebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;


namespace UniPortoWebAPI.Repository
{
    public class RecommendationRespository
    {
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
    }
}