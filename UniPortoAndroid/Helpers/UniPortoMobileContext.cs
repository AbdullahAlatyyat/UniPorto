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
using UniPortoAndroid.Model;

namespace UniPortoAndroid.Helpers
{
   public  static class UniPortoMobileContext
    {
        public static string LoggedInUser
        {
            get;
            set;
           
        }
        public static string SecurityID
        {
            get;
            set;

        }
        public static ProfileModel profile { get; set; }

    }
}