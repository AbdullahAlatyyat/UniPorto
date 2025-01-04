using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public class CompanyManager
    {
        static CompanyRepository repository = new CompanyRepository();

        public static List<CompanyAd> GetAllAtivities()
        {
            var res = repository.GetAllCompanyAds();
            return res;
        }
        public static CompanyAd GetCompanyById(int id)
        {
            var res = repository.GetCompanyAdById(id);
            return res;

        }
        public static int AddCompanyAds(CompanyAd newCompanyAds)
        {
            var res = repository.AddCommpanyAd(newCompanyAds);
            return res;

        }
        public static bool DeleteCompanyAds(int id)
        {
            var res = repository.DeleteCompanyAd(id);
            return res;

        }
        public static bool UpdateCompanyAd(CompanyAd newCompanyAds)
        {
            var res = repository.UpdateCompanyAd(newCompanyAds);
            return res;

        }

        
    }
}