using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.EF.Enums;
using UniPortoWebsite.Repository.Context;

namespace UniPortoWebsite.Repository
{
    /// <summary>
    /// Class ProfileRepository.
    /// </summary>
    public class ProfileRepository
    {
        /// <summary>
        /// Adds the profile.
        /// </summary>
        /// <param name="newProfile">The new profile.</param>
        /// <returns>System.Int32.</returns>
        public int AddProfile(Profile newProfile)
        {
            var model = new UniPorto();
            model.Profiles.Add(newProfile);
            model.SaveChanges();
            return newProfile.Id;
        }

        /// <summary>
        /// Deletes the profile.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Deleting Profile
        /// or
        /// UNEXPECTED EXCEPTION WHILE Deleting Profile
        /// </exception>
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
        /// <summary>
        /// Deletes the profile and ASP security.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Deleting Profile
        /// or
        /// UNEXPECTED EXCEPTION WHILE Deleting Profile
        /// </exception>
        //public bool DeleteProfileAndASPSecurity(int id)
        //{
        //    bool isDeleted = false;
        //    try
        //    {
        //        var model = new UniPorto();
        //        var toDeleteProfile = model.Profiles.Find(id);
                
        //        var IfHavePendingStatus = model.ChangeStatusPendings.Where(p => p.ProfileId == toDeleteProfile.Id).SingleOrDefault();
        //        if (IfHavePendingStatus != null)
        //        {
        //            model.ChangeStatusPendings.Remove(IfHavePendingStatus);
        //        }       
        //        model.Profiles.Remove(toDeleteProfile);
              

        //        model.SaveChanges();
        //        isDeleted = true;
        //        return isDeleted;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        throw new DataProviderException("ERROR WHILE Deleting Profile", sqlex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Deleting Profile", ex);
        //    }
        //}

        /// <summary>
        /// Gets all profiles by type identifier.
        /// </summary>
        /// <param name="profileType">Type of the profile.</param>
        /// <returns>List&lt;Profile&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Getting All Profiles
        /// or
        /// UNEXPECTED EXCEPTION WHILE Getting All Profiles
        /// </exception>
        public List<Profile> GetAllProfilesByTypeId(ProfileTypes profileType)
        {
            try
            {
                var model = new UniPorto();
                return model.Profiles.Where(p=>p.ProfileTypeID == (int)profileType).ToList();
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

        /// <summary>
        /// Updates the profile.
        /// </summary>
        /// <param name="toUpdateProfile">To update profile.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Updating Profile
        /// or
        /// UNEXPECTED EXCEPTION WHILE Updating Profile
        /// </exception>
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
                    toUpdate.Gender = toUpdateProfile.Gender;
                    toUpdate.ProfileCover = toUpdateProfile.ProfileCover;
                    toUpdate.ProfileImage = toUpdateProfile.ProfileImage;
                    toUpdate.Major = toUpdateProfile.Major;
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
        /// <summary>
        /// Updates the profile by admin.
        /// </summary>
        /// <param name="toUpdateProfile">To update profile.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Updating Profile
        /// or
        /// UNEXPECTED EXCEPTION WHILE Updating Profile
        /// </exception>
        public bool UpdateProfileByAdmin(Profile toUpdateProfile)
        {
            var isUpdated = false;
            try
            {
                using (var model = new UniPorto())
                {
                    var toUpdate = model.Profiles.Find(toUpdateProfile.Id);
                    toUpdate.FullName = toUpdateProfile.FullName;
                    toUpdate.PhoneNo = toUpdateProfile.PhoneNo;
                    toUpdate.Email = toUpdateProfile.Email;
                    toUpdate.ProfileTypeID = toUpdateProfile.ProfileTypeID;
                    toUpdate.ProfileStatusID = toUpdateProfile.ProfileStatusID;

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
        /// <summary>
        /// Gets all profiles.
        /// </summary>
        /// <returns>List&lt;Profile&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Getting All Profiles
        /// or
        /// UNEXPECTED EXCEPTION WHILE Getting All Profiles
        /// </exception>
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

        /// <summary>
        /// Gets the profile by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Profile.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Getting Profilebyid
        /// or
        /// UNEXPECTED EXCEPTION WHILE Getting Profilebyid
        /// </exception>
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

        /// <summary>
        /// Gets the requests.
        /// </summary>
        /// <returns>List&lt;ChangeStatusPending&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Getting Requests from changing status
        /// or
        /// UNEXPECTED EXCEPTION WHILE Getting Requests from changing status
        /// </exception>
        ////public List<ChangeStatusPending> GetRequests()
        ////{
        ////    try
        ////    {
        ////        var model = new UniPorto();
        ////        return model.ChangeStatusPendings.ToList();
        ////    }
        ////    catch (SqlException sqlex)
        ////    {
        ////        throw new DataProviderException("ERROR WHILE Getting Requests from changing status", sqlex);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Getting Requests from changing status", ex);
        ////    }
        ////}
        /// <summary>
        /// Deletes the request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE  Deleting Requests from changing status
        /// or
        /// UNEXPECTED EXCEPTION WHILE Deleting  Requests from changing status
        /// </exception>
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
        /// <summary>
        /// Actives the request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE  Activing Requests from changing status
        /// or
        /// UNEXPECTED EXCEPTION WHILE Activing  Requests from changing status
        /// </exception>
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

        /// <summary>
        /// Accepts the status request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE  Deleting Requests from changing status
        /// or
        /// UNEXPECTED EXCEPTION WHILE Deleting  Requests from changing status
        /// </exception>
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
        /// <summary>
        /// Gets the profile by security identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Profile.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE  GETTING PROFILE BY SECURITY ID
        /// or
        /// UNEXPECTED EXCEPTION WHILE GETTING PROFILE BY SECURITY ID
        /// </exception>
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

        /// <summary>
        /// Gets all profile following company.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns>List&lt;FollowingCompany&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE  GETTING ALL FOLLOWING COMPANIES
        /// or
        /// UNEXPECTED EXCEPTION WHILE GETTING ALL FOLLOWING COMPANIES
        /// </exception>
        //public List <FollowingCompany> getAllProfileFollowingCompany(int profileId)
        //{
        //    try
        //    {
        //        var list = new List<FollowingCompany>();
        //    using (var context = new UniPorto())
        //    {
        //            list = context.FollowingCompanies.Where(p => p.ProfileId == profileId).Include(p=>p.Profile).Include(p=>p.Profile.Activities).ToList();
        //    }
        //    return list;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        throw new DataProviderException("ERROR WHILE  GETTING ALL FOLLOWING COMPANIES", sqlex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING ALL FOLLOWING COMPANIES", ex);
        //    }
        //}
    }
}