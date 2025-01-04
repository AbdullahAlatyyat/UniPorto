using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using UniPortoAndroid;
using System.Net.Http;
using UniPortoAndroid.Helpers;
using Newtonsoft.Json;
using UniPortoAndroid.Model;
using System.Net.Http.Headers;
using System.Linq;
using UniPortoAndroid.Enums;
using Android.Animation;
using Java.Util;
using UniPortoAndroid.Views;
using Square.Picasso;
using Android.Content;

namespace UniPortoAndroid
{
    
    [Activity(Theme = "@android:style/Theme.Material.Light")]
    public class ProfileMain : Activity
    {
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        public List<Email> mEmails;
        private ImageView MyImage, HederImage;
        private TextView profile_name, profile_short;
        private Context context; 

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Profail);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            MyImage = FindViewById<ImageView>(Resource.Id.user_profile_photo);
            HederImage = FindViewById<ImageView>(Resource.Id.header_cover_image);
          

            mEmails = new List<Email>();
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UniPortoMobileContext.LoggedInUser);
                var result = await client.GetAsync("http://uniportoapi.azurewebsites.net/GetProfileByUserId?userId=" + UniPortoMobileContext.SecurityID);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;
                    UniPortoMobileContext.profile = JsonConvert.DeserializeObject<ProfileModel>(res);
                    var allActivitesAPI = await client.GetAsync("http://uniportoapi.azurewebsites.net/GetAllActivties?profileId=" + UniPortoMobileContext.profile.Id);
                    if (allActivitesAPI.IsSuccessStatusCode)
                    {
                        var allActivites = JsonConvert.DeserializeObject<ActivityModel>(allActivitesAPI.Content.ReadAsStringAsync().Result);
                        foreach (var item in allActivites.allActivities)
                        {
                            if (item.AttachmentsTypeId != null)
                            {
                                mEmails.Add(new Email() { Name = UniPortoMobileContext.profile.FullName, Subject = item.DateOfActivity != null ? item.DateOfActivity : item.CreatedOn.ToString("dd.MM.yyy"), Message = item.Status, TypeAt = item.AttachmentsTypeId.Value, UrlAtt = item.AttachmentUrl });


                            }

                        }
                        if (UniPortoMobileContext.profile.Major != null && UniPortoMobileContext.profile.City != null && UniPortoMobileContext.profile.stuentId != null)
                        {
                            FindViewById<TextView>(Resource.Id.user_profile_short_bio).Text = UniPortoMobileContext.profile.stuentId + " , " + UniPortoMobileContext.profile.Major + " , " + UniPortoMobileContext.profile.City;

                        }
                        else { 
                            FindViewById<TextView>(Resource.Id.user_profile_short_bio).Text = "Plese Add information Major and City";
                            }

                        FindViewById<TextView>(Resource.Id.user_profile_name).Text = UniPortoMobileContext.profile.FullName;



                        if (UniPortoMobileContext.profile.ProfileCover != null)
                        {
                            Picasso.With(this).Load(UniPortoMobileContext.profile.ProfileCover).Into(HederImage);

                        }
                        if (UniPortoMobileContext.profile.ProfileImage != null)
                        {
                            Picasso.With(this).Load(UniPortoMobileContext.profile.ProfileImage).Into(MyImage);
                            var x = UniPortoMobileContext.profile.ProfileCover;
                          
                        }
                    }
                }
            }




            //Create our layout manager
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new RecyclerAdapter(mEmails, mRecyclerView, this);
            mRecyclerView.SetAdapter(mAdapter);

        }

    }

   
}

