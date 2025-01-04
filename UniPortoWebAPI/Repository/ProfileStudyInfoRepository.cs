using GraduationProject.UniPortoWebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;


namespace UniPortoWebAPI.Repository
{
    public class ProfileStudyInfoRepository
    {
        UniPorto model = new UniPorto();



        public List<ProfileStudyInfo> GetAllLanguage()
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