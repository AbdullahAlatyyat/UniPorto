using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using UniPortoAndroid.Helpers;

namespace UniPortoAndroid
{
    [Activity(Label = "HomeActivity", Theme = "@android:style/Theme.DeviceDefault.Light")]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomeActivity);
            // Create your application here
            var ss = Application.BaseContext.ApplicationInfo.Permission;
            var phoneNumbers = Intent.GetStringExtra("access_token") ?? "Data not available";
            var loggedIn = UniPortoMobileContext.LoggedInUser;
            TextView accessToken = FindViewById<TextView>(Resource.Id.textView1);
            TextView seqId = FindViewById<TextView>(Resource.Id.textView2);
            accessToken.Text = UniPortoMobileContext.LoggedInUser;
            seqId.Text = UniPortoMobileContext.SecurityID;

        }
    }
}