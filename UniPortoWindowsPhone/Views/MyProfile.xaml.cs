using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UniPortoPhoneStroage;
using UniPortoWindowsPhone.Controls;
using UniPortoWindowsPhone.EF;
using UniPortoWindowsPhone.Helper;
using UniPortoWindowsPhone.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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
    public sealed partial class MyProfile : Page
    {
        /// <summary>
        /// The image URL
        /// </summary>
        string imageUrl = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="MyProfile"/> class.
        /// </summary>
        public MyProfile()
        {
            this.InitializeComponent();
            OnLoad();
        }
        /// <summary>
        /// Called when [load].
        /// </summary>
        public async void OnLoad()
        {
            Busy.SetBusy(true, "Loading ..");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UniPortoMobileContext.LoggedInUser);

                var result = await client.GetAsync("http://uniportoapi.azurewebsites.net/GetProfileByUserId?userId=" + UniPortoMobileContext.SecurityID);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;
                    UniPortoMobileContext.profile = JsonConvert.DeserializeObject<ProfileModel>(res);
                    UsernameTxt.Text = UniPortoMobileContext.profile.FullName;
                    ImageSource imgSource = new BitmapImage();
                    if (UniPortoMobileContext.profile.ProfileImage != null)
                        UserProfilePic.UriSource = new Uri(UniPortoMobileContext.profile.ProfileImage);
                    var allActivitesAPI = await client.GetAsync("http://uniportoapi.azurewebsites.net/GetAllActivties?profileId=" + UniPortoMobileContext.profile.Id);
                    if (allActivitesAPI.IsSuccessStatusCode)
                    {
                        var allActivites = JsonConvert.DeserializeObject<ActivityModel>(allActivitesAPI.Content.ReadAsStringAsync().Result);
                        if (allActivites.allActivities != null)
                        {
                            foreach (var item in allActivites.allActivities.Take(10))
                            {
                                if (item.AttachmentsTypeId == (int)AttachmentsTypes.Text)
                                {
                                    TextActivity textView = new TextActivity(item);
                                    activites.Children.Add(textView);
                                }
                                else if (item.AttachmentsTypeId == (int)AttachmentsTypes.Image)
                                {
                                    ImageActivity imageView = new ImageActivity(item);
                                    activites.Children.Add(imageView);
                                }
                                else
                                {
                                    VideoActivity videoView = new VideoActivity(item);
                                    activites.Children.Add(videoView);
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageDialog msg = new MessageDialog("Can't Load Activites Now");
                        await msg.ShowAsync();
                    }
                }

            }

            Busy.SetBusy(false);


        }
        /// <summary>
        /// Handles the Tapped event of the TextBlock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TappedRoutedEventArgs"/> instance containing the event data.</param>
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }
        /// <summary>
        /// BTNs the upload image.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btnUploadImage(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                await UploadFile(file);
                uploadedImage.Source = new BitmapImage(new Uri(imageUrl));
                uploadedImage.Visibility = Visibility.Visible;
                UploadImage.Visibility = Visibility.Collapsed;
                btnRemoveImage.Visibility = Visibility.Visible;
            }

        }

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>Task.</returns>
        private async Task UploadFile(StorageFile file)
        {
            try
            {
                Busy.SetBusy(true, "Uploading");
                BlobManager manager = new BlobManager();

                imageUrl = await manager.UploadImageAsync(file, Guid.NewGuid().ToString(), "uniporto");

                Busy.SetBusy(false);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// BTNs the add activity.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btnAddActivity(object sender, RoutedEventArgs e)
        {
            Busy.SetBusy(true, "Posting ...");
            var activity = new ActivityModel()
            {
                Status = status.Text,
                ProfileId = UniPortoMobileContext.profile.Id,
                CreatedBy = UniPortoMobileContext.profile.FullName + "[WindowsPhone]",
                CreatedOn = DateTime.Now,
            };
            if (imageUrl == null)
            {
                activity.AttachmentsTypeId = (int)AttachmentsTypes.Text;
            }
            else
            {
                activity.AttachmentsTypeId = (int)AttachmentsTypes.Image;
                activity.AttachmentUrl = imageUrl;
            }

            using (var client = new HttpClient())
            {
                
                var json = JsonConvert.SerializeObject(activity);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UniPortoMobileContext.LoggedInUser);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("http://uniportoapi.azurewebsites.net/AddActivity", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<ActivityModel>(res);
                    imageUrl = null;
                    status.Text = "";
                    uploadedImage.Visibility = Visibility.Collapsed;
                    uploadedImage.Source = null;
                    uploadedImage.Visibility = Visibility.Collapsed;
                    UploadImage.Visibility = Visibility.Visible;
                    btnRemoveImage.Visibility = Visibility.Collapsed;
                    activites.Children.Clear();
                    this.OnLoad();
                }
                else
                {
                    MessageDialog msg = new MessageDialog("Error");
                    await msg.ShowAsync();
                }
                Busy.SetBusy(false);
            }
        }

        /// <summary>
        /// Removes the image.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RemoveImage(object sender, RoutedEventArgs e)
        {
            uploadedImage.Visibility = Visibility.Collapsed;
            uploadedImage.Source = null;
            imageUrl = null;
            uploadedImage.Visibility = Visibility.Collapsed;
            UploadImage.Visibility = Visibility.Visible;
            btnRemoveImage.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Statuses the text changing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="TextBoxTextChangingEventArgs"/> instance containing the event data.</param>
        private void status_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (status.Text != "" )
            {
                btnPost.IsEnabled = true;
            }
            else
            {
                btnPost.IsEnabled = false;
            }
        }



    }
}

