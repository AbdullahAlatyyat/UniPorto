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
    public sealed partial class Logout : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Logout"/> class.
        /// </summary>
        public Logout()
        {
            this.InitializeComponent();
            Bye();
        }
        /// <summary>
        /// Byes this instance.
        /// </summary>
        public async void Bye()
        {
            MessageDialog showDialog = new MessageDialog("Are you sure you ?");
            showDialog.Commands.Add(new UICommand("Yes")
            {
                Id = 0
            });
            showDialog.Commands.Add(new UICommand("No")
            {
                Id = 1
            });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {

                Shell.HamburgerMenu.PrimaryButtons[0].Visibility = Visibility.Collapsed;
                Shell.HamburgerMenu.PrimaryButtons[1].Visibility = Visibility.Collapsed;
                Shell.HamburgerMenu.SecondaryButtons[0].Visibility = Visibility.Visible;
                Shell.HamburgerMenu.SecondaryButtons[1].Visibility = Visibility.Collapsed;
                UniPortoMobileContext.LoggedInUser = null;
                UniPortoMobileContext.profile = null;
                UniPortoMobileContext.SecurityID = null;
                Frame.Navigate(typeof(Login));

            }
            else
            {
                Frame.GoBack();
            }

        }
    }
}
