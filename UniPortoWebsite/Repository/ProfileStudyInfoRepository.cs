using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository.Context;

namespace UniPortoWebsite.Repository
{
    /// <summary>
    /// Class ProfileStudyInfoRepository.
    /// </summary>
    public class ProfileStudyInfoRepository
    {
        /// <summary>
        /// The model
        /// </summary>
        UniPorto model = new UniPorto();



        /// <summary>
        /// Gets all study information.
        /// </summary>
        /// <returns>List&lt;ProfileStudyInfo&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting All  ProfileStudyInfo
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting All  Profile Study Info
        /// </exception>
        public List<ProfileStudyInfo> GetAllStudyInfo()
        {
            try
            {
                var res = model.ProfileStudyInfoes.ToList();

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting All  ProfileStudyInfo ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting All  Profile Study Info ", ex);
            }
        }
        /// <summary>
        /// Gets the profile study information by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProfileStudyInfo.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING  ProfileStudyInfo BY ID
        /// or
        /// UNEXPECTED EXCEPTION WHILE GETTING  ProfileStudyInfo BY ID
        /// </exception>
        public ProfileStudyInfo GetProfileStudyInfoByID(int id)
        {

            try
            {

                var res = model.ProfileStudyInfoes.Find(id);

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING  ProfileStudyInfo BY ID ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING  ProfileStudyInfo BY ID", ex);
            }
        }
        /// <summary>
        /// Adds the profile study information.
        /// </summary>
        /// <param name="profileStudyInfo">The profile study information.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING ADDING  ProfileStudyInfo
        /// or
        /// UNEXPECTED EXCEPTION WHILE ADDING  ProfileStudyInfo
        /// </exception>
        public int AddProfileStudyInfo(ProfileStudyInfo profileStudyInfo)
        {


            try
            {
                using (var context = new UniPorto())
                {
                    model.ProfileStudyInfoes.Add(profileStudyInfo);
                    model.SaveChanges();
                }
                return profileStudyInfo.Id;

            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING ADDING  ProfileStudyInfo", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE ADDING  ProfileStudyInfo", ex);
            }
        }
        /// <summary>
        /// Deletes the profile study information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE DELETING ProfileStudyInfo
        /// or
        /// UNEXPECTED EXCEPTION WHILE DELETING ProfileStudyInfo
        /// </exception>
        public bool DeleteProfileStudyInfo(int Id)
        {
            bool Deleted = false;

            try
            {

                var obj = model.ProfileStudyInfoes.Find(Id);
                model.ProfileStudyInfoes.Remove(obj);
                model.SaveChanges();
                Deleted = true;

                return Deleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE DELETING ProfileStudyInfo ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE DELETING ProfileStudyInfo", ex);
            }
        }
        /// <summary>
        /// Edits the profile study information.
        /// </summary>
        /// <param name="profileStudyInfo">The profile study information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE UPDATING ProfileStudyInfo
        /// or
        /// UNEXPECTED EXCEPTION WHILE UPDATING ProfileStudyInfo
        /// </exception>
        public bool EditProfileStudyInfo(ProfileStudyInfo profileStudyInfo)
        {
            bool Updated = false;

            try
            {

                model.ProfileStudyInfoes.AddOrUpdate(profileStudyInfo);
                model.SaveChanges();
                Updated = true;

                return Updated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE UPDATING ProfileStudyInfo ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE UPDATING ProfileStudyInfo", ex);
            }
        }

   
    }
}