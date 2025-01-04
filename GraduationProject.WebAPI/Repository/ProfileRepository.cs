using GraduationProject.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GraduationProject.WebAPI.Repository
{
    internal class ProfileRepository
    {
        internal int AddProfile(Profile newProfile)
        {
            var model = new Model1();
            model.Profiles.Add(newProfile);
            model.SaveChanges();
            return newProfile.ID;
        }

        internal bool DeleteProfile(int id)
        {
            bool isDeleted = false;
            try
            {
                var model = new Model1();
                var toDeleteProfile = model.Profiles.Where(mm => mm.ID == id).SingleOrDefault();
                model.Profiles.Remove(toDeleteProfile);
                model.SaveChanges();
                isDeleted = true;
                return isDeleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Deleting Profile", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Deleting Profile", ex);
            }
        }

        internal bool UpdateProfile(Profile toUpdateProfile)
        {
            var isUpdated = false;
            try
            {
                var model = new Model1();
                var toUpdate = model.Profiles.Where(p => p.ID == toUpdateProfile.ID).SingleOrDefault();
                toUpdate.UserId = toUpdateProfile.UserId;
                toUpdate.FirstName = toUpdateProfile.FirstName;
                toUpdate.LastName = toUpdateProfile.LastName;
                toUpdate.Email = toUpdateProfile.Email;
                toUpdate.JobTitle = toUpdateProfile.JobTitle;
                toUpdate.MobileNumber = toUpdateProfile.MobileNumber;
                toUpdate.CityID = toUpdateProfile.CityID;
                toUpdate.CountryID = toUpdateProfile.CountryID;
                toUpdate.Email = toUpdateProfile.Email;
;

                model.SaveChanges();
                isUpdated = true;
                return isUpdated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Updating Profile", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Updating Profile", ex);
            }
        }

        internal List<Profile> GetAllProfiles()
        {
            try
            {
                var model = new Model1();
                return model.Profiles.ToList();
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Getting All Profiles", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Getting All Profiles", ex);
            }
        }

        internal Profile GetProfileById(int id)
        {
            try
            {
                var model = new Model1();
                return model.Profiles.Where(mm => mm.ID == id).SingleOrDefault();
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Getting Profilebyid", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Getting Profilebyid", ex);
            }
        }
    }
}