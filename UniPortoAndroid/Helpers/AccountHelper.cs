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
using Newtonsoft.Json;

namespace UniPortoAndroid
{
   public  class AccountHelper
    {
        [JsonProperty(PropertyName = "access_token")]
        public string access_token { get; set; }
        [JsonProperty(PropertyName = "userID")]
        public string userID { get; set; }
    }
}