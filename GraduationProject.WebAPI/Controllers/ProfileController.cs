using GraduationProject.WebAPI.Manger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GraduationProject.WebAPI.Controllers
{
    [RoutePrefix("api/Profile")]
    public class ProfileController : ApiController
    {
        [Route("AddProfile")]
        [HttpPost]
        public int AddProfile(Profile profileModel)
        {
            return ProfileManger.AddProfile(profileModel);
        }
        [Route("DeleteProfile")]
        [HttpGet]
        public bool DeleteProfile(int Id)
        {
            return ProfileManger.DeleteProfile(Id);
        }
        [Route("GetProfileById")]
        [HttpGet]
        public Profile GetProfileById(int Id)
        {
            return ProfileManger.GetProfileById(Id);
        }
        [Route("UpdateProfile")]
        [HttpPost]
        public bool UpdateProfile(Profile toUpdateProfile)
        {
            return ProfileManger.UpdateProfile(toUpdateProfile);
        }
    }
}
