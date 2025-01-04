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
    public class LanguageRepository
    {
        UniPorto model = new UniPorto();

       

        public List<Language> GetAllLanguage()
        {
            try
            {
                var res = model.Languages.ToList();

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting All Language ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting All Language ", ex);
            }
        }
        public Language GetLanguageByID(int id)
        {

            try
            {
       
                var res = model.Languages.Find(id);

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING Language BY ID ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING Language BY ID", ex);
            }
        }
        public int AddLanguage(Language language)
        {
            

            try
            {
                using (var context = new UniPorto())
                {
                    model.Languages.Add(language);
                    model.SaveChanges();
                }
                return language.Id;

            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING ADDING  Language", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE ADDING  Language", ex);
            }
        }
        public bool DeleteLanguage(int Id)
        {
            bool Deleted = false;

            try
            {
                
                var obj = model.Languages.Find(Id);
                model.Languages.Remove(obj);
                model.SaveChanges();
                Deleted = true;

                return Deleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE DELETING Languages ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE DELETING Languages", ex);
            }
        }
        public bool EditLanguage(Language language)
        {
            bool Updated = false;

            try
            {

                model.Languages.AddOrUpdate(language);
                model.SaveChanges();
                Updated = true;

                return Updated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE UPDATING Language ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE UPDATING Language", ex);
            }
        }

        public List<string> GetAllWorldLanguages()
        {
            try
            {
                var res = model.AvalibleLanguages.Select(p => p.Language).ToList();

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting All WORLD Languages ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting All WORLD Languages ", ex);
            }
        }

    }
}