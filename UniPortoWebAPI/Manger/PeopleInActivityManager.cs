using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.EF.Enums;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public class PeopleInActivityManager
    {
        static PeopleInActivityRepository respository = new PeopleInActivityRepository();
        public static int AddPeople(PeopleInActivity Person)
        {
            return respository.AddPeople(Person);
        }

        public static bool DeletePeople(int id)
        {
            return respository.DeletePeople(id);
        }

        public static PeopleInActivity GetPeopleById(int id)
        {
            return respository.GetPeopleById(id);
        }

        public static List<PeopleInActivity> GetAllPeople()
        {
            return respository.GetAllPeople();
        }

        public static bool UpdatePeople(PeopleInActivity toUpdatePeople)
        {
            return respository.UpdatePeople(toUpdatePeople);
        }
    }
    }