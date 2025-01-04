using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UniPortoWindowsPhone.EF;
using UniPortoWindowsPhone.Helper;
using UniPortoWindowsPhone.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace UniPortoWindowsPhone.Views
{


    /// <summary>
    /// Class Login. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class Login : Page
    {
        /// <summary>
        /// The access token
        /// </summary>
        public static string access_token;
        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        public Login()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Determines whether this instance is internet.
        /// </summary>
        /// <returns><c>true</c> if this instance is internet; otherwise, <c>false</c>.</returns>
        public static bool IsInternet()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            bool internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            return internet;

        }


        /// <summary>
        /// Handles the Click event of the btnReg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btnReg_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Register Not Working Now");
            await msg.ShowAsync();
        }
        /// <summary>
        /// Loginses the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task&lt;AccountHelper&gt;.</returns>
        public async Task<AccountHelper> Logins(AccountModel user)
        {
          
            
            using (var client = new HttpClient())
            {

                    // client.BaseAddress = new System.Uri(url) ;
                    var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("grant_type", "password"),
                 new KeyValuePair<string, string>("username", user.Email),
                  new KeyValuePair<string, string>("Password", user.Password)
            });
                    var result = await client.PostAsync("http://uniportoapi.azurewebsites.net/token", content);
                    if (result.IsSuccessStatusCode)
                    {
                        var res = result.Content.ReadAsStringAsync().Result;
                        var resss = JsonConvert.DeserializeObject<AccountHelper>(res);
                        UniPortoMobileContext.LoggedInUser = resss.access_token;
                        UniPortoMobileContext.SecurityID = resss.userID;
                        return resss;
                    }
                    else
                    {
                        return null;
                    }
                
               
            }

        }

        /// <summary>
        /// Makes the post request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="serializedDataString">The serialized data string.</param>
        /// <param name="isJson">if set to <c>true</c> [is json].</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> MakePostRequest(string url, string serializedDataString, bool isJson = true)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (isJson)
                request.ContentType = "application/json";
            else
                request.ContentType = "application/x-www-form-urlencoded";

            request.Method = "POST";

            var stream = await request.GetRequestStreamAsync();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(serializedDataString);
                writer.Flush();
                writer.Dispose();
            }

            var response = await request.GetResponseAsync();
            var respStream = response.GetResponseStream();

            using (StreamReader sr = new StreamReader(respStream))
            {
                return sr.ReadToEnd();
            }
        }
        /// <summary>
        /// Posts the form URL encoded.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="postData">The post data.</param>
        public static async void PostFormUrlEncoded<TResult>(string url, IEnumerable<KeyValuePair<string, string>> postData)
        {

            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    //return await response.Content.ReadAsAsync<TResult>();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(IsInternet())
                {
                    Busy.SetBusy(true, "Logging in ...");
                    AccountModel user = new AccountModel
                    {
                        Email = txtEmail.Text,
                        Password = txtPassword.Password,
                        grant_type = "password"
                    };

                    AccountHelper x = await Logins(user);
                    if (x != null)
                    {
                        access_token = x.access_token;
                        List<string> dataList = new List<string>();
                        dataList.Add(access_token);
                        Shell.HamburgerMenu.PrimaryButtons[0].Visibility = Visibility.Visible;
                        Shell.HamburgerMenu.PrimaryButtons[1].Visibility = Visibility.Visible;
                        Shell.HamburgerMenu.SecondaryButtons[0].Visibility = Visibility.Collapsed;
                        Shell.HamburgerMenu.SecondaryButtons[1].Visibility = Visibility.Visible;

                        Busy.SetBusy(false);
                        Frame.Navigate(typeof(MyProfile));
                    }
                    else
                    {
                        Busy.SetBusy(false);
                        MessageDialog msg = new MessageDialog("Worng email or password");
                        await msg.ShowAsync();
                    }


                }
                else
                {
                    MessageDialog msg = new MessageDialog("No Internet Conenction");
                    await msg.ShowAsync();
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// Texts the email text changing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="TextBoxTextChangingEventArgs"/> instance containing the event data.</param>
        private void txtEmail_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (txtEmail.Text != "" && txtPassword.Password != "")
            {
                BtnLog.IsEnabled = true;
            }
            else
            {
                BtnLog.IsEnabled = false;
            }
        }

        /// <summary>
        /// Handles the PasswordChanged event of the txtPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text != "" && txtPassword.Password != "")
            {
                BtnLog.IsEnabled = true;
            }
            else
            {
                BtnLog.IsEnabled = false;
            }
        }
    }
}
