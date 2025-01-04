// ***********************************************************************
// Assembly         : UniPortoWebsite
// Author           : RamiQ
// Created          : 12-30-2016
//
// Last Modified By : RamiQ
// Last Modified On : 12-30-2016
// ***********************************************************************
// <copyright file="HomeController.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Mvc;
using UniPortoWebsite.EF;
using UniPortoWebsite.Manager;
using UniPortoWebsite.Models;

namespace UniPortoWebsite.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Mains this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Main()
        {
            var res = CompanyManager.GetAllCompanyAds();
            MainViewModel model = new MainViewModel();
            model.Companise = res;
            return View(model);
        }
        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// Blocks the view.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult BlockView(CompanyAd model)
        {
           
                return PartialView("BlockView",model);

        }
        /// <summary>
        /// Sends the cv to company.
        /// </summary>
        /// <param name="adId">The ad identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult SendCVToCompany(int adId)
        {
            SendCVToCompanyModel model = new SendCVToCompanyModel();
            model.offerId = adId;
            return View(model);
        }
        /// <summary>
        /// Sends the cv to company.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Threading.Tasks.Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> SendCVToCompany(SendCVToCompanyModel model)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyManager.GetCompanyById(model.offerId);
                EmailService service = new EmailService();
                await service.SendAsync(new Microsoft.AspNet.Identity.IdentityMessage
                {
                    Destination = company.CompanyEmail,
                    Subject = "[Uni-Porto] Requesting for job",
                    Body = "<h2>Dear " + company.CompanyName + "</h2><br/><h3> your job offer with ID :" + model.offerId + " have the following request </h3><p><b> User Name : </b>" + model.FullName + " <br /><b> Email :</b>" + model.Email + " <br /><b> Phone Number : </b> " + model.PhoneNo + "<br /><b> Message :</b> " + model.Message + " </p>"
                });
                return RedirectToAction("Main", "Home");
            }

            return View(model);
        }
    }
}