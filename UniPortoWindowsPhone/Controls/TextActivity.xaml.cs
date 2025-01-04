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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UniPortoWindowsPhone.Controls
{
    /// <summary>
    /// Class TextActivity. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.UserControl" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class TextActivity : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextActivity"/> class.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public TextActivity(ActivityModel activity)
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
            txtTime.Text = activity.DateOfActivity!=null?activity.DateOfActivity:activity.CreatedOn.ToString("dd.MM.yyy");
            txtStatus.Text = activity.Status;
            


        }
    }
}
