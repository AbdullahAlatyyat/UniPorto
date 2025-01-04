using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public class ExperianceManager
    {
        static ExperianceRepository respository = new ExperianceRepository();
        public static List<Experiance> GetAllExperiance()
        {
            var res = respository.GetAllExperiance();
            return res;

        }
        public static bool AddExperiance(Experiance experiance)
        {
            var res = respository.AddExperiance(experiance);

            return res;

        }

        public static bool DeleteExperiance(int id)
        {
            var res = respository.DeleteExperiance(id);

            return res;

        }

        public static bool EditExperiance(Experiance experiance)
        {
            var res = respository.EditExperiance(experiance);

            return res;

        }

        public static Experiance GetExperianceByID(int id)
        {
            var res = respository.GetExperianceByID(id);

            return res;

        }
    }
}