using Graduation.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graduation.Website.Controllers
{
    public class AdminstrationController : Controller
    {
        // GET: Adminstration
        public ActionResult Index()
        {
          List<  AdminDashboredViewModel> model = new List<AdminDashboredViewModel>();
            return View(model);
        }
      
    }
}