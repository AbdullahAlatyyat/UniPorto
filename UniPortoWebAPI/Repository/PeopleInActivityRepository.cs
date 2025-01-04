using GraduationProject.UniPortoWebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.EF.Enums;

namespace UniPortoWebAPI.Repository
{
    public class PeopleInActivityRepository
    {
        public int AddPeople(PeopleInActivity Person)
        {
            var model = new UniPorto();
            model.PeopleInActivities.Add(Person);
            model.SaveChanges();
            return Person.Id;
        }

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