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

namespace UniPortoAndroid.Model
{
    class ActivityModel
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Status { get; set; }
        public int? AttachmentsTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AttachmentUrl { get; set; }
        public string DateOfActivity { get; set; }
        public List<ActivityModel> allActivities { get; set; }
    }
}