using GraduationProject.UniPortoWebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.EF.Enums;

namespace UniPortoWebAPI.Repository
{
    public class ProfileRepository
    {
        public int AddProfile(Profile newProfile)
        {
            var model = new UniPorto();
            model.Profiles.Add(newProfile);
            model.SaveChanges();
            return newProfile.Id;
        }

        public bool DeleteProfile(int id)
        {
            bool isDeleted = false;
            try
            {
                var model = new UniPorto();
                var toDeleteProfile = model.Profiles.Where(mm => mm.Id == id).SingleOrDefault();
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
        public bool DeleteProfileAndASPSecurity(int id)
        {
            bool isDeleted = false;
            try
            {
                var model = new UniPorto();
                var toDeleteProfile = model.Profiles.Find(id);
                var ASPProfile = model.AspNetUsers.Find(toDeleteProfile.SecurityID);
                var IfHavePendingStatus = model.ChangeStatusPendings.Where(p => p.ProfileId == toDeleteProfile.Id).SingleOrDefault();
                if (IfHavePendingStatus != null)
                {
                    model.ChangeStatusPendings.Remove(IfHavePendingStatus);

                }
                model.Profiles.Remove(toDeleteProfile);
                model.AspNetUsers.Remove(ASPProfile);

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


        public bool UpdateProfile(Profile toUpdateProfile)
        {
            var isUpdated = false;
            try
            {
                using (var model = new UniPorto())
                {
                    var toUpdate = model.Profiles.Find(toUpdateProfile.Id);
                    toUpdate.PhoneNo = toUpdateProfile.PhoneNo;
                    toUpdate.Email = toUpdateProfile.Email;
                    toUpdate.City = toUpdateProfile.City;
                    toUpdate.Skills = toUpdateProfile.Skills;
                    toUpdate.intersts = toUpdateProfile.intersts;
                    toUpdate.Email = toUpdateProfile.Email;
                    toUpdate.Hobbies = toUpdateProfile.Hobbies;
                    toUpdate.Address = toUpdateProfile.Address;
                    toUpdate.DateOfBirthday = toUpdateProfile.DateOfBirthday;
                    model.SaveChanges();
                    isUpdated = true;
                }
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

        public List<Profile> GetAllProfiles()
        {
            try
            {
                var model = new UniPorto();
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

        public Profile GetProfileById(int id)
        {
            try
            {
                var model = new UniPorto();
                return model.Profiles.Where(mm => mm.Id == id).SingleOrDefault();
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

        public List<ChangeStatusPending> GetRequests()
        {
            try
            {
                var model = new UniPorto();
                return model.ChangeStatusPendings.ToList();
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Getting Requests from changing status", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Getting Requests from changing status", ex);
            }
        }
        public bool DeleteRequest(int id)
        {
            try
            {
                bool deleted = false;
                var model = new UniPorto();
                var temp = model.ChangeStatusPendings.Find(id);
                model.ChangeStatusPendings.Remove(temp);
                model.SaveChanges();
                deleted = true;
                return deleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE  Deleting Requests from changing status", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Deleting  Requests from changing status", ex);
            }
        }
        public bool ActiveRequest(int id)
        {
            try
            {
                bool activated = false;
                var model = new UniPorto();
                var profile = model.Profiles.Find(id);
                profile.ProfileStatusID =(int) ProfileStatuses.Active;
                model.SaveChanges();
                activated = true;
                return activated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE  Activing Requests from changing status", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Activing  Requests from changing status", ex);
            }
        }

        public bool AcceptStatusRequest(int id)
        {
            try
            {
                bool deleted = false;
                var model = new UniPorto();
                var temp = model.ChangeStatusPendings.Find(id);
                var profile = model.Profiles.Find(temp.ProfileId);
                profile.ProfileTypeID = temp.NewStatus.HasValue ? temp.NewStatus.Value : profile.ProfileTypeID;
                model.ChangeStatusPendings.Remove(temp);
                model.SaveChanges();
                deleted = true;
                return deleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE  Deleting Requests from changing status", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Deleting  Requests from changing status", ex);
            }
        }
        public Profile GetProfileBySecurityId(string id)
        {
            try
            {
                var model = new UniPorto();
                var profile = model.Profiles.Where(p =>p.SecurityID == id).Include(p => p.Languages).Include(p => p.Experiances).Include(p=>p.ProfileStudyInfoes).FirstOrDefault();
                return profile;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE  GETTING PROFILE BY SECURITY ID", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING PROFILE BY SECURITY ID", ex);
            }
        }
    }
}