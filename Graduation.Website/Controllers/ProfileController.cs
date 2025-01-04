using Graduation.Website.Models;
using Graduation.Website.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graduation.Website.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            ProfileServices service = new ProfileServices();
            var model =service.GetAllProfiles();
            return View(model);
        }
    }
}