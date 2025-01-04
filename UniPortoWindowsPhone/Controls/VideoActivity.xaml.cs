using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UniPortoWindowsPhone.Helper;
using UniPortoWindowsPhone.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniPortoWindowsPhone.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class VideoActivity : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoActivity"/> class.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public VideoActivity(ActivityModel activity)
        {
            this.InitializeComponent();
            putData(activity);
        }
        /// <summary>
        /// Puts the data.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public void putData(ActivityModel activity)
        {
            if (UniPortoMobileContext.profile.ProfileImage != null)
                UserProfilePic.UriSource = new Uri(UniPortoMobileContext.profile.ProfileImage);
            txtTime.Text = activity.DateOfActivity != null ? activity.DateOfActivity : activity.CreatedOn.ToString("dd.MM.yyy");
            txtStatus.Text = activity.Status;
            if(activity.AttachmentUrl!=null && activity.AttachmentUrl!="")
            Video.Source = new Uri(activity.AttachmentUrl);
        }
    }
}
