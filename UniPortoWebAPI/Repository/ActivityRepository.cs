using GraduationProject.UniPortoWebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;

using System.Data.Entity;


namespace UniPortoWebAPI.Repository
{
    public class ActivityRepository
    {
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
        public Activity GetAtivityById(int id)
        {
             try
            {
                var model = new UniPorto();
               var res =   model.Activities.Include(pr => pr.ActivityAttachments).Where(p => p.Id == id).SingleOrDefault();
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
        public  bool UpdateActivity(Activity toUpdauteActivity )
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


        
    }
}