using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public static class RecommendationManager
    {
        static RecommendationRespository respository = new RecommendationRespository();

        public static List<Recommendation> GetAllRecommendation()
        {
            var res = respository.GetAllRecommendation();

            return res;
               
        }

        public static bool AddRecommendation(Recommendation recommendation)
        {
            var res = respository.AddRecommendation(recommendation);

            return res;

        }

        public static bool DeleteRecommendation(int id)
        {
            var res = respository.DeleteRecommendation(id);

            return res;

        }

        public static bool EditRecommendation(Recommendation recommendation)
        {
            var res = respository.EditRecommendation(recommendation);

            return res;

        }

        public static Recommendation GetRecommendationByID(int id)
        {
            var res = respository.GetRecommendationByID(id);

            return res;

        }
    }
}