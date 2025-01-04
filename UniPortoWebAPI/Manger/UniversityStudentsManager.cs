using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public class UniversityStudentsManager
    {
        static UniversityStudentsRepository respository = new UniversityStudentsRepository();
        public static UniversityStudent CheckTheStudet(string username)
        {
            return respository.CheckTheStudet(username);
        }
    }
}