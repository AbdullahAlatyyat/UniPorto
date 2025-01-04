using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.EF.Enums;
using UniPortoWebAPI.Helpers;
using UniPortoWebAPI.Manager;
using UniPortoWebAPI.Models;

namespace UniPortoWebAPI.Controllers
{
    [System.Web.Http.Authorize]
    public class PrivateProfileController : ApiController
    {
        [System.Web.Http.Route("GetAllActivties")]
        public ActivityAPIModel GetAllActivties()
        {
            List<Activity> allActivties = ActivityManager.GetAllAtivities(UniPortoContext.LoggedInUser.Id);
            ActivityAPIModel model = new ActivityAPIModel();
            List<ActivityAPIModel> listOfActivties = new List<ActivityAPIModel>();
            if (allActivties.Count > 0)
            {
                string attachmentUrl = string.Empty;
                ActivityAPIModel single;
                foreach (var item in allActivties)
                {
                    if (item.AttachmentsTypeId != (int)AttachmentsTypes.Text)
                    {
                        foreach (var acct in item.ActivityAttachments)
                        {
                            attachmentUrl = acct.Url;
                        }
                    }
                    single = new ActivityAPIModel
                    {
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn,
                        Status = item.Contant,
                        AttachmentsTypeId = item.AttachmentsTypeId,
                        AttachmentUrl = attachmentUrl
                    };
                    listOfActivties.Add(single);
                }
                model.allActivities = listOfActivties;
            }
            return model;
        }

        [System.Web.Http.Route("GetProfileByUserId")]
        public ProfileAPIModel GetProfileByUserId(string userId)
        {
            var profile = ProfileManager.GetProfileBySecurityId(userId);


            ProfileAPIModel model = new ProfileAPIModel();
            if (profile!=null)
            {
                model.Id = profile.Id;
                model.PhoneNo = profile.PhoneNo;
                model.Email = profile.Email;
                model.SecurityID = profile.SecurityID;
                model.ProfileImage = profile.ProfileImage;
                model.FullName = profile.FullName;
                model.City = profile.City;
                model.Skills = profile.Skills;
                model.intersts = profile.intersts;
                model.Hobbies = profile.Hobbies;
                model.Address = profile.Address;
                model.Major = profile.Major;
                model.stuentId = profile.stuentId;
                model.DateOfBirthday = profile.DateOfBirthday;
                model.stuentId = profile.stuentId;
                model.Gender = profile.Gender;
                model.ProfilePic = profile.ProfilePic;
                model.ProfileCover = profile.ProfileCover;


            }
            return model;
        }

        [System.Web.Http.Route("AddActivity")]
        public ActivityAPIModel AddActivity(ActivityAPIModel model)
        {
            var activity = new Activity
            {
                Contant = model.Status != null?model.Status:string.Empty,
                ProfileId = model.ProfileId,
                AttachmentsTypeId = model.AttachmentsTypeId,
                CreatedBy = model.CreatedBy,
                CreatedOn = model.CreatedOn,
                Date = Convert.ToDateTime(model.DateOfActivity),
                
            };
             var temp  = ActivityManager.AddActivity(activity);
            if(temp.AttachmentsTypeId!=(int)AttachmentsTypes.Text)
            {
                var attachment = AttachmentManger.AddAttachment(new ActivityAttachment
                {
                    ActivityId = temp.Id,
                    Url = model.AttachmentUrl,
                    AttachmentsType = model.AttachmentsTypeId.Value
                });
            }
            var activityApi = new ActivityAPIModel
            {
                Status = temp.Contant,
                Id = temp.Id,
                ProfileId = temp.ProfileId,
                AttachmentsTypeId = temp.AttachmentsTypeId,
                CreatedBy = temp.CreatedBy,
                CreatedOn = temp.CreatedOn,
                DateOfActivity = temp.Date!=null?temp.Date.Value.ToString("dd.MM.yyy"):null,
                AttachmentUrl= model.AttachmentUrl
            };



            return activityApi;
        }

       
    }
}
