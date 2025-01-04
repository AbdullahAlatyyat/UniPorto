using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class LanguageManager.
    /// </summary>
    public class LanguageManager
    {
        /// <summary>
        /// The respository
        /// </summary>
        static LanguageRepository respository = new LanguageRepository();
        /// <summary>
        /// Gets the alllanguage.
        /// </summary>
        /// <returns>List&lt;Language&gt;.</returns>
        public static List<Language> GetAlllanguage()
        {
            var res = respository.GetAllLanguage();
            return res; 

        }
        /// <summary>
        /// Adds the language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns>System.Int32.</returns>
        public static int AddLanguage(Language language)
        {
            var res = respository.AddLanguage(language);

            return res;

        }

        /// <summary>
        /// Deletelanguages the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Deletelanguage(int id)
        {
            var res = respository.DeleteLanguage(id);

            return res;

        }

        /// <summary>
        /// Editlanguages the specified language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Editlanguage(Language language)
        {
            var res = respository.EditLanguage(language);

            return res;

        }

        /// <summary>
        /// Getlanguages the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Language.</returns>
        public static Language GetlanguageByID(int id)
        {
            var res = respository.GetLanguageByID(id);

            return res;

        }

        /// <summary>
        /// Gets all world languages.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> GetAllWorldLanguages()
        {
            var res = respository.GetAllWorldLanguages();
            return res;
        }
    }
}