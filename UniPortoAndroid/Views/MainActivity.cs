
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Net;
using UniPortoAndroid.Model;
using Newtonsoft.Json;
using System.Net.Http;
using Android.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniPortoAndroid.Helpers;
using UniPortoAndroid.Views;
using UniPortoAndroid;
using System.Threading;

namespace UniPortoAndroid
{

    [Activity(Theme = "@android:style/Theme.Material.Light",Label = "Uni Porto", MainLauncher = true, Icon = "@drawable/logo")]
    public class MainActivity : Activity
    {
        
        int count = 1;
        private object mobNetInfo;

        public static string  accessToken { get; set; }
        protected async override  void OnCreate(Bundle bundle)
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;

           
            string url = "http://uniportoapi.azurewebsites.net/Account/Register";
                base.OnCreate(bundle);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
                // Get our button from the layout resource,
                // and attach an event to it
                TextView txtUserName = FindViewById<TextView>(Resource.Id.txtEmail);
                TextView txtPassWord = FindViewById<TextView>(Resource.Id.txtPassword);
                Intent HomePage = new Intent();
                Button button = FindViewById<Button>(Resource.Id.btnLogin);

                ////button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
                button.Click += async (sender, e) =>
                {

                    if (isOnline == true)
                    {
                        AccountModel user = new AccountModel
                        {
                            Email = txtUserName.Text,
                            Password = txtPassWord.Text,
                            grant_type = "password"
                        };
                        try
                        {
                            var progressDialog = ProgressDialog.Show(this, "Please wait...", "Logining...", true);
                            new Thread(new ThreadStart(delegate
                            {
                                //LOAD METHOD TO GET ACCOUNT INFO
                                //RunOnUiThread(() => Toast.MakeText(this, "Toast within progress dialog.", ToastLength.Long).Show());
                                //HIDE PROGRESS DIALOG
                            })).Start();

                            AccountHelper x = await Login(user);
                            if (x.access_token != null)
                            {
                                string access_token = x.access_token;
                                List<string> dataList = new List<string>();
                                dataList.Add(accessToken);
                                var intent = new Intent(this, typeof(ProfileMain));
                                //intent.PutStringArrayListExtra("access_token", dataList);
                                Intent.PutExtra("access_token", access_token);
                                Application.BaseContext.ApplicationInfo.Permission = accessToken;


                                StartActivity(intent);
                            }
                            else
                            {
                                //  MessageDialog msg = new MessageDialog("Your Password Or Email Wrong");
                                //  msg.ShowAsync();
                                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                               // alert.SetTitle(str);
                                alert.SetPositiveButton("OK", (senderAlert, args) => {
                                    // write your own set of instructions
                                });
                                alert.SetMessage("Your Password Or Email Is Wrong");
                                RunOnUiThread(() => {
                                    alert.Show();
                                });
                            }
                            RunOnUiThread(() => progressDialog.Hide());


                        }
                        catch (HttpRequestException )
                        {
                            Toast.MakeText(this, "HttpRequestException", ToastLength.Long).Show();
                        }
                        
                    }
                    else
                    {
                        Toast.MakeText(this, "Not Connection Internet", ToastLength.Long).Show();
                    }
                // var response = MakePostRequest("http://10.0.2.1/UniPortoWebAPI/token", user.ToString(), false);
                ////////////////////////
                //// Create a request using a URL that can receive a post. 
                //WebRequest request = WebRequest.Create("http://10.0.2.1/UniPortoWebAPI/token");
                //// Set the Method property of the request to POST.
                //request.Method = "POST";
                //// Create POST data and convert it to a byte array.

                //byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(user.ToString());
                //// Set the ContentType property of the WebRequest.
                //request.ContentType = "application/x-www-form-urlencoded";
                //// Set the ContentLength property of the WebRequest.
                //request.ContentLength = byteArray.Length;
                //// Get the request stream.

                //Stream dataStream = request.GetRequestStream();
                //// Write the data to the request stream.
                ////dataStream.Write(byteArray, 0, byteArray.Length);
                ////// Close the Stream object.
                ////dataStream.Close();
                //// Get the response.
                //WebResponse response = request.GetResponse();

                //// Get the stream containing content returned by the server.
                //dataStream = response.GetResponseStream();
                //// Open the stream using a StreamReader for easy access.
                //StreamReader reader = new StreamReader(dataStream);
                //// Read the content.
                //string responseFromServer = reader.ReadToEnd();
                //// Display the content.

                //// Clean up the streams.
                //reader.Close();
                //dataStream.Close();
                //response.Close();
                ///////////////////////////////
                ////HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                ////request.Method = "POST";
                //////using GET - request.Headers.Add ("Authorization","Authorizaation value");
                ////request.ContentType = "application/x-www-form-urlencoded";

                ////HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
                ////string responseText;

                ////using (var response = request.GetResponse())
                ////{
                ////    using (var reader = new StreamReader(response.GetResponseStream()))
                ////    {

                ////        responseText = reader.ReadToEnd();
                ////        var koko = JsonConvert.SerializeObject(user);



                ////        //Console.WriteLine(responseText);

                ////    }
                ////}

            };
           
               
           
        }
            public async  Task<AccountHelper> Login(AccountModel user)
        {
           
            using (var client = new HttpClient())
            {
          
                string url = "http://uniportoapi.azurewebsites.net/";
              // client.BaseAddress = new System.Uri(url) ;
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("grant_type", user.grant_type),
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
                    return new AccountHelper();
                }               
            }
        }
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
    }
    }


