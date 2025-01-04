using System.Web.Mvc;
namespace UniPortoWebsite.Controllers
{
    using Microsoft.AspNet.Identity;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using Uni_Porto_BlobStoage;
    using UniPortoWebsite.EF;
    using UniPortoWebsite.EF.Enums;
    using UniPortoWebsite.Helpers;
    using UniPortoWebsite.Manager;
    using UniPortoWebsite.Models;

    /// <summary>
    /// Class PrivateProfileController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class PrivateProfileController : Controller
    {
        // GET: PrivateProfile
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            List<Activity> allActivties = ActivityManager.GetAllAtivities(UniPortoContext.LoggedInUser.Id);
            ActivityViewModel model = new ActivityViewModel();
          
            List<ActivityViewModel> listOfActivties = new List<ActivityViewModel>();
            if (allActivties.Count > 0)
            {
                string attachmentUrl = string.Empty;
                ActivityViewModel single;
                foreach (var item in allActivties)
                {
                    if (item.AttachmentsTypeId != (int)AttachmentsTypes.Text)
                    {
                        foreach (var acct in item.ActivityAttachments)
                        {
                            attachmentUrl = acct.Url;
                        }

                    }
                    single = new ActivityViewModel
                    {
                        Id = item.Id,
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn,
                        Status = item.Contant,
                        AttachmentsTypeId = item.AttachmentsTypeId,
                        AttachmentUrl = attachmentUrl,
                        DateOfActivity = item.Date != null ? item.Date.Value.ToShortDateString() : null

                    };
                    listOfActivties.Add(single);
                }
                model.allActivities = listOfActivties;
            }
            model.AttachmentsTypeId = (int)AttachmentsTypes.Text;

            return View(model);
        }
        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult About()
        {
            var identity = User.Identity.GetUserId();
            var profile = ProfileManager.GetProfileBySecurityId(identity);
            return View(profile);
        }
        /// <summary>
        /// Fulls the timeline.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult FullTimeline()
        {
            List<Activity> allActivties = ActivityManager.GetAllAtivities(UniPortoContext.LoggedInUser.Id);
            ActivityViewModel model = new ActivityViewModel();
            List<ActivityViewModel> listOfActivties = new List<ActivityViewModel>();
            if (allActivties.Count > 0)
            {
                string attachmentUrl = string.Empty;
                ActivityViewModel single;
                foreach (var item in allActivties)
                {
                    if (item.AttachmentsTypeId != (int)AttachmentsTypes.Text)
                    {
                        foreach (var acct in item.ActivityAttachments)
                        {
                            attachmentUrl = acct.Url;
                        }

                    }
                    single = new ActivityViewModel
                    {
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn,
                        Status = item.Contant,
                        AttachmentsTypeId = item.AttachmentsTypeId,
                        AttachmentUrl = attachmentUrl,
                        DateOfActivity = item.Date != null ? item.Date.Value.ToShortDateString() : null
                    };
                    listOfActivties.Add(single);
                }
                model.allActivities = listOfActivties;
            }
            model.AttachmentsTypeId = (int)AttachmentsTypes.Text;
            return View(model);
        }
        /// <summary>
        /// Attaches the specified photo.
        /// </summary>
        /// <param name="photo">The photo.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult Attach(HttpPostedFileBase photo)
        {
            string AttachmentUrl = string.Empty;
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentType.Contains("image") || Request.Files[0].ContentType.Contains("video"))
                {
                    AttachmentUrl = BlobHelper.UplodeContent(Request.Files[0]);
                }
            }
            else
            {
                AttachmentUrl = "No File Choosen";
            }
            //byte[] fileContents = null;
            //Bitmap myBitmap = null;
            //Image myThumbnail = null;
            //byte[] image;
            //using (var reader = new BinaryReader(Request.Files[0].InputStream))
            //{
            //    image = reader.ReadBytes(Request.Files[0].ContentLength);
            //}

            //var ImageFormate = fileContent.ContentType;

            ////TO DO Save image in Blob storage and retrive the link to save it.
            //MemoryStream ms = new MemoryStream(image);
            //Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            //myBitmap = new Bitmap(ms);
            //myThumbnail = myBitmap.GetThumbnailImage(120, 120, myCallback, IntPtr.Zero);

            //MemoryStream ms1 = new MemoryStream();

            //if (ImageFormate == "image/png")
            //    myThumbnail.Save(ms1, ImageFormat.Png);
            //else if (ImageFormate == "image/jpg" || ImageFormate == "image/jpeg")
            //    myThumbnail.Save(ms1, ImageFormat.Jpeg);
            //else if (ImageFormate == "image/bmp")
            //    myThumbnail.Save(ms1, ImageFormat.Bmp);
            //else
            //    throw new Exception("unknow image format, for the profile image");
            //ms1.Position = 0;
            return Json(AttachmentUrl, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Updates the cover photo.
        /// </summary>
        /// <returns>JsonResult.</returns>
        public JsonResult UpdateCoverPhoto()
        {
            string AttachmentUrl = string.Empty;
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentType.Contains("image"))
                {
                    if (UniPortoContext.LoggedInUser.ProfileCover == null)
                    { AttachmentUrl = BlobHelper.UplodeContent(Request.Files[0]); }
                    else
                    { AttachmentUrl = BlobHelper.UplodeContent(Request.Files[0], UniPortoContext.LoggedInUser.ProfileCover.Substring(UniPortoContext.LoggedInUser.ProfileCover.LastIndexOf('/') + 1)); }
                    if (UniPortoContext.LoggedInUser.ProfileCover != (AttachmentUrl))
                    {
                        if (AttachmentUrl != "")
                        {
                            Profile toUpdate = UniPortoContext.LoggedInUser;
                            toUpdate.ProfileCover = AttachmentUrl;
                            var updated = ProfileManager.UpdateProfile(toUpdate);
                        }
                    }

                }
            }
            else
            {
                AttachmentUrl = "No File Choosen";
            }
            return Json(AttachmentUrl, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Updates the profile photo.
        /// </summary>
        /// <returns>JsonResult.</returns>
        public JsonResult UpdateProfilePhoto()
        {
            string AttachmentUrl = string.Empty;
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentType.Contains("image"))
                {
                    if (UniPortoContext.LoggedInUser.ProfileImage == null)
                    { AttachmentUrl = BlobHelper.UplodeContent(Request.Files[0]); }
                    else
                    { AttachmentUrl = BlobHelper.UplodeContent(Request.Files[0], UniPortoContext.LoggedInUser.ProfileImage.Substring(UniPortoContext.LoggedInUser.ProfileCover.LastIndexOf('/') + 1)); }
                    if (UniPortoContext.LoggedInUser.ProfileImage != (AttachmentUrl))
                    {
                        if (AttachmentUrl != "")
                        {
                            Profile toUpdate = UniPortoContext.LoggedInUser;
                            toUpdate.ProfileImage = AttachmentUrl;
                            var updated = ProfileManager.UpdateProfile(toUpdate);
                        }
                    }

                }
            }
            else
            {
                AttachmentUrl = "No File Choosen";
            }
            return Json(AttachmentUrl, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Thumbnails the callback.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ThumbnailCallback()
        {
            return false;
        }
        /// <summary>
        /// Adds the activity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>PartialViewResult.</returns>
        public PartialViewResult AddActivity(ActivityViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var loggedIn = ProfileManager.GetProfileBySecurityId(userId);
            var res = ActivityManager.AddActivity(new EF.Activity
            {
                Contant = model.Status,
                ProfileId = loggedIn.Id,
                AttachmentsTypeId = (int)AttachmentsTypes.Text,
                CreatedBy = loggedIn.FullName,
                CreatedOn = DateTime.Now
            });
            ActivityViewModel newModel = new ActivityViewModel
            {
                CreatedBy = res.CreatedBy,
                CreatedOn = res.CreatedOn,
                Status = res.Contant,
                AttachmentsTypeId = res.AttachmentsTypeId,
                DateOfActivity = res.Date != null ? res.Date.Value.ToShortDateString() : null
            };    // return Json(res, JsonRequestBehavior.AllowGet);
                  //return View(Newtonsoft.Json.JsonConvert.SerializeObject(res));
            return PartialView("~/Views/PrivateProfile/_Block.cshtml", newModel);
            //}
            // return View();
            // return Json("Error While adding an actvity", JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Adds the activity t.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>PartialViewResult.</returns>
        public PartialViewResult AddActivityT(ActivityViewModel model)
        {
            if (model.DateOfActivity == "Choose Date of Your Event")
            {
                model.DateOfActivity = null;
            }
            var res = ActivityManager.AddActivity(new EF.Activity
            {
                Contant = model.Status,
                ProfileId = UniPortoContext.LoggedInUser.Id,
                AttachmentsTypeId = model.AttachmentsTypeId,
                CreatedBy = UniPortoContext.LoggedInUser.FullName,
                CreatedOn = DateTime.Now,
                Date = model.DateOfActivity != null ? DateTime.Parse(model.DateOfActivity) : (DateTime?)null
            });
            Activity wholeAct = new Activity();
            string attachmetntUrl = string.Empty;
            if (model.AttachmentsTypeId != (int)AttachmentsTypes.Text)
            {
                ActivityAttachment attachment = new ActivityAttachment();
                attachment.ActivityId = res.Id;
                attachment.AttachmentsType = res.AttachmentsTypeId.Value;
                attachment.Url = model.AttachmentUrl;
                var isAdded = AttachmentManger.AddAttachment(attachment);
                wholeAct = ActivityManager.GetAtivityById(res.Id);
                foreach (var item in wholeAct.ActivityAttachments)
                {
                    attachmetntUrl = item.Url;
                }
            }

            ActivityViewModel newModel = new ActivityViewModel
            {
                Id = res.Id,
                CreatedBy = res.CreatedBy,
                CreatedOn = res.CreatedOn,
                Status = res.Contant,
                AttachmentsTypeId = res.AttachmentsTypeId,
                AttachmentUrl = attachmetntUrl,
                DateOfActivity = res.Date != null ? res.Date.Value.ToShortDateString() : null
            };
            return PartialView("~/Views/PrivateProfile/_TimeLineBlock.cshtml", newModel);

        }
        /// <summary>
        /// Creates the activity partial.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>PartialViewResult.</returns>
        [HttpPost]
        public PartialViewResult CreateActivityPartial(ActivityViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var loggedIn = ProfileManager.GetProfileBySecurityId(userId);
            var res = ActivityManager.AddActivity(new EF.Activity
            {
                Contant = model.Status,
                ProfileId = loggedIn.Id,
                AttachmentsTypeId = (int)AttachmentsTypes.Text,
                CreatedBy = loggedIn.FullName,
                CreatedOn = DateTime.Now,

            });

            return PartialView("~/Views/PrivateProfile/_Block.cshtml", res);
        }
        /// <summary>
        /// Removes the attachment.
        /// </summary>
        /// <param name="attUrl">The att URL.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult RemoveAttachment(string attUrl)
        {
            BlobManager manger = new BlobManager();
            string blobName = attUrl.Substring(attUrl.LastIndexOf('/') + 1);
            var res = manger.DeleteBlob("uniporto", blobName);
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Adds the language.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AddLanguage()
        {
            var AllLanguages = LanguageManager.GetAllWorldLanguages();
            ViewBag.Title = new SelectList(AllLanguages, "Language");
            return PartialView("AddLanguage");
        }
        /// <summary>
        /// Adds the language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult AddLanguage(Language language)
        {
            if (ModelState.IsValid)
            {
           
            language.ProfileId = UniPortoContext.LoggedInUser.Id;
            var res = LanguageManager.AddLanguage(language);
            return Json(res, JsonRequestBehavior.AllowGet);
            }
            return Json(language);

        }
        /// <summary>
        /// Removes the language.
        /// </summary>
        /// <param name="LanguageId">The language identifier.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult RemoveLanguage(int LanguageId)
        {
            var res = LanguageManager.Deletelanguage(LanguageId);

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Edits the profile.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult EditProfile()
        {
            var profile = ProfileManager.GetProfileBySecurityId(User.Identity.GetUserId());
            var model = new EditProfileViewModel();
            if (profile != null)
            {
                model = new EditProfileViewModel()
                {
                    Id = profile.Id,
                    intersts = profile.intersts,
                    Address = profile.Address,
                    Email = profile.Email,
                    City = profile.City,
                    DateOfBirthday = profile.DateOfBirthday,
                    Gender = profile.Gender,
                    Hobbies = profile.Hobbies,
                    PhoneNo = profile.PhoneNo,
                    Skills = profile.Skills,
                    Major=profile.Major
                };
            }


            return PartialView("EditProfile", model);
        }
        /// <summary>
        /// Edits the profile.
        /// </summary>
        /// <param name="EditedProfile">The edited profile.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult EditProfile(EditProfileViewModel EditedProfile)
        {
            var profile = new Profile()
            {
                Id = EditedProfile.Id,
                intersts = EditedProfile.intersts,
                Address = EditedProfile.Address,
                Email = EditedProfile.Email,
                City = EditedProfile.City,
                DateOfBirthday = EditedProfile.DateOfBirthday,
                Gender = EditedProfile.Gender,
                Hobbies = EditedProfile.Hobbies,
                PhoneNo = EditedProfile.PhoneNo,
                Skills = EditedProfile.Skills,
                Major = EditedProfile.Major

            };
            var updated = ProfileManager.UpdateProfile(profile);
            return Json(updated, JsonRequestBehavior.AllowGet);


        }

        /// <summary>
        /// Creates the experiance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult CreateExperiance()
        {
            return PartialView("CreateExperiance");
        }

        /// <summary>
        /// Creates the experiance.
        /// </summary>
        /// <param name="experiance">The experiance.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult CreateExperiance(Experiance experiance)
        {
            experiance.profileId = UniPortoContext.LoggedInUser.Id;
            var res = ExperianceManager.AddExperiance(experiance);


            return Json(res, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Edits the experiance.
        /// </summary>
        /// <param name="ExperianceId">The experiance identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult EditExperiance(int ExperianceId)
        {
            var model = ExperianceManager.GetExperianceByID(ExperianceId);

            return PartialView("EditExperiance", model);
        }
        /// <summary>
        /// Edits the experiance.
        /// </summary>
        /// <param name="experiance">The experiance.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult EditExperiance(Experiance experiance)
        {
            var res = ExperianceManager.EditExperiance(experiance);

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Edits the study information.
        /// </summary>
        /// <param name="StudyId">The study identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult EditStudyInfo(int StudyId)
        {
            var model = ProfileStudyInfoManager.GetProfileStudyInfoByID(StudyId);

            return PartialView("EditStudyInfo", model);
        }
        /// <summary>
        /// Edits the study information.
        /// </summary>
        /// <param name="studyInfo">The study information.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult EditStudyInfo(ProfileStudyInfo studyInfo)
        {
            var res = ProfileStudyInfoManager.EditProfileStudyInfo(studyInfo);

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Removes the study information.
        /// </summary>
        /// <param name="studyInfoId">The study information identifier.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult RemoveStudyInfo(int studyInfoId)
        {
            var res = ProfileStudyInfoManager.DeleteProfileStudyInfo(studyInfoId);

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates the study information.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult CreateStudyInfo()
        {
            return this.PartialView("CreateStudyInfo");
        }

        /// <summary>
        /// Creates the study information.
        /// </summary>
        /// <param name="studyInfo">The study information.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult CreateStudyInfo(ProfileStudyInfo studyInfo)
        {
            studyInfo.ProfileId = UniPortoContext.LoggedInUser.Id;
            var res = ProfileStudyInfoManager.AddProfileStudyInfo(studyInfo);


            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Removes the experiance.
        /// </summary>
        /// <param name="experianceId">The experiance identifier.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult RemoveExperiance(int experianceId)
        {
            var res = ExperianceManager.DeleteExperiance(experianceId);

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Asks for reccomendation.
        /// </summary>
        /// <param name="ActivityId">The activity identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult AskForReccomendation(int ActivityId)
        {
            AskForRecViewModel model = new AskForRecViewModel();
            model.ActivityId = ActivityId;
            //model.InstructorsDDL = GetAllInstructorsProfiles();
            //model.CompaniesDDL = GetAllCompaniesProfiles();
            return PartialView("_AskForReccomendation",model);
        }
        /// <summary>
        /// Asks for reccomendation.
        /// </summary>
        /// <param name="ActivityId">The activity identifier.</param>
        [HttpPost]
        public JsonResult AskForReccomendation(string  jsonRequest)
        {
           var  isAsked = false;
            var model = JsonConvert.DeserializeObject<AskForRecViewModel>(jsonRequest);
            if (model.InstructorId != 0)
            {
                RecommendationQueue requestRec = new RecommendationQueue
                {
                    ProfileId = UniPortoContext.LoggedInUser.Id,
                    InstructorId = model.InstructorId,
                    ActivityId = model.ActivityId,
                    Message = model.RequesterMessage,
                    CreateOn = DateTime.Now,
                    CreatedBy = UniPortoContext.LoggedInUser.FullName
                };
                RecommendationQueueManager.AddOnQueue(requestRec);
                isAsked = true;
            }
            if (model.CompanyId != 0)
            {
                RecommendationQueue requestRec = new RecommendationQueue
                {
                    ProfileId = UniPortoContext.LoggedInUser.Id,
                    InstructorId = model.CompanyId,
                    ActivityId = model.ActivityId,
                    Message = model.RequesterMessage,
                    CreateOn = DateTime.Now,
                    CreatedBy = UniPortoContext.LoggedInUser.FullName
                };
                RecommendationQueueManager.AddOnQueue(requestRec);
                isAsked = true;
            }

            return Json(isAsked);
        }
        /// <summary>
        /// Gets all instructors profiles.
        /// </summary>
        /// <returns>List&lt;RecomenderProfile&gt;.</returns>
        [HttpPost]
        public JsonResult GetAllInstructorsProfiles()
        {
            var instructors = ProfileManager.GetAllProfilesByTypeId(ProfileTypes.Instructor);
            List<Profile> AllProfiles = new List<EF.Profile>();
            List<RecomenderProfile> RecomenderProfiles = new List<RecomenderProfile>();
            foreach (var item in instructors)
            {

                RecomenderProfile recomenderProfile = new RecomenderProfile
                {
                    Id = item.Id,
                    FullName = item.FullName
                };
                RecomenderProfiles.Add(recomenderProfile);
               
            }
            return Json(RecomenderProfiles);
    }

        /// <summary>
        /// Gets all companies profiles.
        /// </summary>
        /// <returns>List&lt;RecomenderProfile&gt;.</returns>
        [HttpPost]
        public JsonResult GetAllCompaniesProfiles()
        {
            var instructors = ProfileManager.GetAllProfilesByTypeId(ProfileTypes.Company);
            List<Profile> AllProfiles = new List<EF.Profile>();
            List<RecomenderProfile> RecomenderProfiles = new List<RecomenderProfile>();
            foreach (var item in instructors)
            {

                RecomenderProfile recomenderProfile = new RecomenderProfile
                {
                    Id = item.Id,
                    FullName = item.FullName
                };
                RecomenderProfiles.Add(recomenderProfile);

            }
            return Json(RecomenderProfiles);
        }
        public ActionResult GetNotifications()
        {
            var res = RecommendationQueueManager.GetQueueByInstructorId(UniPortoContext.LoggedInUser.Id);


            List<Request> requests = new List<Request>();
            foreach (var item in res)
            {
                var requster = ProfileManager.GetProfileById(item.ProfileId);
                Request req = new Request
                {
                    RequesterId = requster.Id,
                    RequesterImage = requster.ProfileImage,
                    RequesterName = requster.FullName,
                    RequestCreatedOn = item.CreateOn.ToShortDateString(),
                    RequestId = item.Id
                };
                requests.Add(req);
            }
           
            NotificationViewModel model = new NotificationViewModel
            {
                NotificationCount = res.Count,
                ReccomendRequests = requests
            };
          
            return PartialView("_Notification", model);
        }
        public ActionResult PortoProfile(int ProfileId)
        {
           var profile= ProfileManager.GetProfileById(ProfileId);
            List<Activity> allActivties = ActivityManager.GetAllAtivities(ProfileId);
            PortoProfileViewModel model = new PortoProfileViewModel();
            List<ActivityViewModel> listOfActivties = new List<ActivityViewModel>();
            model.UserProfile = profile;
            if (allActivties.Count > 0)
            {
               
                string attachmentUrl = string.Empty;
                ActivityViewModel single;
                foreach (var item in allActivties)
                {
                    if (item.AttachmentsTypeId != (int)AttachmentsTypes.Text)
                    {
                        foreach (var acct in item.ActivityAttachments)
                        {
                            attachmentUrl = acct.Url;
                        }

                    }
                    single = new ActivityViewModel
                    {
                        Id = item.Id,
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn,
                        Status = item.Contant,
                        AttachmentsTypeId = item.AttachmentsTypeId,
                        AttachmentUrl = attachmentUrl,
                        DateOfActivity = item.Date != null ? item.Date.Value.ToShortDateString() : null

                    };
                    listOfActivties.Add(single);
                }
                model.allActivities = listOfActivties;
            }
            return View(model);
        }
        public ActionResult PortoAbout(int ProfileId)
        {
            PortoAboutViewModel model = new PortoAboutViewModel { UserProfile = ProfileManager.GetProfileById(ProfileId) };

                       return View(model);
        }
        public ActionResult ViewRequestDetails(int RequestId)
        {
       var res =     RecommendationQueueManager.GetQueueByRequestId(RequestId);

            var attachmentUrl = ActivityManager.GetAtivityById(res.ActivityId);
            string url=null;
            foreach (var item in attachmentUrl.ActivityAttachments)
            {
                url = item.Url;
            }
            RecommendationQueueViewModel model = new RecommendationQueueViewModel()
            {
                ActivityId = res.ActivityId,
                AttachmentUrl = url,
                CreatedBy = res.CreatedBy,
                CreateOn = res.CreateOn,
                InstructorId = res.InstructorId,
                Message = res.Message,
                AttachmentsTypeId = res.Activity.AttachmentsTypeId != null ? res.Activity.AttachmentsTypeId.Value : (int)AttachmentsTypes.Text,
                ProfileCity = res.Profile.City != null ? res.Profile.City : string.Empty,
                ProfileImage = res.Profile.ProfileImage != null ? res.Profile.ProfileImage : "~/Content/user-default.png",
                ProfileFullName=res.Profile.FullName,
                ActivityContent=res.Activity.Contant,
                Id=res.Id
               
            };
            return PartialView("_RequestDetails", model);
        }
        [HttpPost]
        public JsonResult AddRecommendation(int activityId,string Title)
        {
            if(activityId!=null && Title!=null)
            {

            Recommendation recommendation = new Recommendation()
            {
                ActivityId = activityId,
                Title = Title,
                CreatedBy = UniPortoContext.LoggedInUser.FullName,
                CreatedOn = DateTime.Now,
                ProfileId = UniPortoContext.LoggedInUser.Id
            };
                var res = RecommendationManager.AddRecommendation(recommendation);
                return Json(res,JsonRequestBehavior.AllowGet);
            }
            else
                return Json(false, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult LoadAllRecommendation(int activityId)
        {
            var recommendations = RecommendationManager.GetRecommendationByActivityID(activityId);
            return PartialView("AllRecommendations", recommendations);
        }
        [HttpPost]
        public JsonResult RejectRecommendationQueue(int queueId)
        {
            var res = RecommendationQueueManager.DeleteFromQueueByInstructor(queueId);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}