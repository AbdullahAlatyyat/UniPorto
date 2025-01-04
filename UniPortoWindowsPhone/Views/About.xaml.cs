using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UniPortoWindowsPhone.Helper;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniPortoWindowsPhone.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class About : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="About"/> class.
        /// </summary>
        public About()
        {
            this.InitializeComponent();
            LoadData();
        }
        /// <summary>
        /// Loads the data.
        /// </summary>
        public async void LoadData()
        {
            var profile = UniPortoMobileContext.profile;
            if (profile != null)
            {
                UsernameTxt.Text = profile.FullName;
                txtAddress.Text = profile.Address != null ? profile.Address : string.Empty;
                txtCity.Text = profile.City != null ? profile.City : string.Empty;
                txtDateOfBirth.Text = profile.DateOfBirthday != null ? profile.DateOfBirthday.Value.ToString("dd.MM.yyy") : string.Empty;
                txtEmail.Text = profile.Email!=null?profile.Email:string.Empty;
                txtGendar.Text = profile.Gender != null ? profile.Gender : string.Empty;
                txtHobbies.Text = profile.Hobbies != null ? profile.Hobbies : string.Empty;
                txtMajor.Text = profile.Major != null ? profile.Major : string.Empty;
                txtPhoneNo.Text = profile.PhoneNo != null ? profile.PhoneNo : string.Empty;
                txtSkills.Text = profile.Skills != null ? profile.Skills : string.Empty;
                txtIntrests.Text = profile.interests != null ? profile.interests : string.Empty;
            }
            else
            {
                MessageDialog msg = new MessageDialog("Something Error Happend ");
                await msg.ShowAsync();
            }


        }
    }
}
