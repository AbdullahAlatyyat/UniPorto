using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public class LanguageManager
    {
        static LanguageRepository respository = new LanguageRepository();
        public static List<Language> GetAlllanguage()
        {
            var res = respository.GetAllLanguage();
            return res; 

        }
        public static int AddLanguage(Language language)
        {
            var res = respository.AddLanguage(language);

            return res;

        }

        public static bool Deletelanguage(int id)
        {
            var res = respository.DeleteLanguage(id);

            return res;

        }

        public static bool Editlanguage(Language language)
        {
            var res = respository.EditLanguage(language);

            return res;

        }

        public static Language GetlanguageByID(int id)
        {
            var res = respository.GetLanguageByID(id);

            return res;

        }

       public static List<string> GetAllWorldLanguages()
        {
            var res = respository.GetAllWorldLanguages();
            return res;
        }
    }
}