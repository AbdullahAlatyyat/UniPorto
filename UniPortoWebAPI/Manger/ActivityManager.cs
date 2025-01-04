using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public static class ActivityManager
    {
        static ActivityRepository repository = new ActivityRepository();
        public static List<Activity> GetAllAtivities(int profileId)
        {
            var res = repository.GetAllAtivities(profileId);
            return res;
        }
        public static Activity GetAtivityById(int id)
        {
            var res = repository.GetAtivityById(id);
            return res;

        }
       
        public static bool DeleteActivity(int id)
        {
            var res = repository.DeleteActivity(id);
            return res;

        }
        public static bool UpdateActivity(Activity newActivity)
        {
            var res = repository.UpdateActivity(newActivity);
            return res;

        }
        public static Activity AddActivity(Activity newActivity)
        {
            var res = repository.AddActivity(newActivity);
            return res;
        }
    }
}