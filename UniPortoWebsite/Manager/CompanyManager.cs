using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class CompanyManager.
    /// </summary>
    public class CompanyManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        static CompanyRepository repository = new CompanyRepository();

        /// <summary>
        /// Gets all company ads.
        /// </summary>
        /// <returns>List&lt;CompanyAd&gt;.</returns>
        public static List<CompanyAd> GetAllCompanyAds()
        {
            var res = repository.GetAllCompanyAds();
            return res;
        }
        /// <summary>
        /// Gets the company by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CompanyAd.</returns>
        public static CompanyAd GetCompanyById(int id)
        {
            var res = repository.GetCompanyAdById(id);
            return res;

        }
        /// <summary>
        /// Adds the company ads.
        /// </summary>
        /// <param name="newCompanyAds">The new company ads.</param>
        /// <returns>System.Int32.</returns>
        public static int AddCompanyAds(CompanyAd newCompanyAds)
        {
            var res = repository.AddCommpanyAd(newCompanyAds);
            return res;

        }
        /// <summary>
        /// Deletes the company ads.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteCompanyAds(int id)
        {
            var res = repository.DeleteCompanyAd(id);
            return res;

        }
        /// <summary>
        /// Updates the company ad.
        /// </summary>
        /// <param name="newCompanyAds">The new company ads.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateCompanyAd(CompanyAd newCompanyAds)
        {
            var res = repository.UpdateCompanyAd(newCompanyAds);
            return res;

        }

        
    }
}