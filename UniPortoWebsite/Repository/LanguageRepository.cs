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
    /// Class LanguageRepository.
    /// </summary>
    public class LanguageRepository
    {
        /// <summary>
        /// The model
        /// </summary>
        UniPorto model = new UniPorto();



        /// <summary>
        /// Gets all language.
        /// </summary>
        /// <returns>List&lt;Language&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting All Language
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting All Language
        /// </exception>
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
        /// <summary>
        /// Gets the language by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Language.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING Language BY ID
        /// or
        /// UNEXPECTED EXCEPTION WHILE GETTING Language BY ID
        /// </exception>
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
        /// <summary>
        /// Adds the language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING ADDING  Language
        /// or
        /// UNEXPECTED EXCEPTION WHILE ADDING  Language
        /// </exception>
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
        /// <summary>
        /// Deletes the language.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE DELETING Languages
        /// or
        /// UNEXPECTED EXCEPTION WHILE DELETING Languages
        /// </exception>
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
        /// <summary>
        /// Edits the language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE UPDATING Language
        /// or
        /// UNEXPECTED EXCEPTION WHILE UPDATING Language
        /// </exception>
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

        /// <summary>
        /// Gets all world languages.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting All WORLD Languages
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting All WORLD Languages
        /// </exception>
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