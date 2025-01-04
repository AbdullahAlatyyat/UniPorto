using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationProject.WebAPI.Manger;

namespace GraduationProject.WebAPI.Tests.Controllers
{
    [TestClass]
    public class ProfileTests
    {
        [TestMethod]
        public void AddProfileTest()
        {
            var result1 = ProfileManger.AddProfile(new Profile
            {
                UserId = "Hellitself",
                FirstName = "mahmoud",
                LastName = "khar",
                Email = "abd@hot.com",
                JobTitle = "IT",
                MobileNumber = "092130482",
                CityID = 1,
                CountryID = 1
            }
                );
        }
        /*[TestMethod]
        public void DeleteprofileTest()
        {
            var result2 = ProfileManger.DeleteProfile(3);
        }
        */
    }
}
