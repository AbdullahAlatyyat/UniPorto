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
using Android.Support.V7.Widget;
using Android.Animation;
using System.Net.Http;
using System.Net.Http.Headers;
using UniPortoAndroid.Helpers;
using Newtonsoft.Json;
using UniPortoAndroid.Model;

namespace UniPortoAndroid.Views
{
    [Activity(Label = "ProfailActivity")]
    public class ProfailActivity : Activity
    {
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        private List<Email> mEmails;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          //  SetContentView(Resource.Layout.Profail);
            //Bring Logged In Profile 
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UniPortoMobileContext.LoggedInUser);

                var result = await client.GetAsync("http://uniportoapi.azurewebsites.net/GetProfileByUserId?userId=" + UniPortoMobileContext.SecurityID);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;
                    UniPortoMobileContext.profile = JsonConvert.DeserializeObject<ProfileModel>(res);
                    // Those Information need to be on the layout 
                    ////////////////////////////////////////////////
                    // UsernameTxt.Text = UniPortoMobileContext.profile.FullName;
                    //ImageSource imgSource = new BitmapImage();
                    //  if (UniPortoMobileContext.profile.ProfileImage != null)
                    //   UserProfilePic.UriSource = new Uri(UniPortoMobileContext.profile.ProfileImage);
                    ////////////////////////////////////////////////
                    ///Get All Activites 
                    var allActivitesAPI = await client.GetAsync("http://uniportoapi.azurewebsites.net/GetAllActivties?profileId=" + UniPortoMobileContext.profile.Id);
                    if (allActivitesAPI.IsSuccessStatusCode)
                    {
                        var allActivites = JsonConvert.DeserializeObject<ActivityModel>(allActivitesAPI.Content.ReadAsStringAsync().Result);
                        foreach (var item in allActivites.allActivities.Take(10))
                        {
                            // Create your application here
                            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
                            mEmails = new List<Email>();
                            mEmails.Add(new Email() { Name = UniPortoMobileContext.profile.FullName, Subject = item.DateOfActivity!=null?item.DateOfActivity:item.CreatedOn.ToString("dd.MM.yyy"), Message = item.Status });

                            //Create our layout manager
                            mLayoutManager = new LinearLayoutManager(this);
                            mRecyclerView.SetLayoutManager(mLayoutManager);
                            ///////////////
                            mAdapter = new RecyclerAdapter(mEmails, mRecyclerView, this);
                            mRecyclerView.SetAdapter(mAdapter);
                        }
                    }

                }
            }


        }
       // public override bool OnCreateOptionsMenu(IMenu menu)
       // {
       //     MenuInflater.Inflate(Resource.Menu.actionbar, menu);
        //    return base.OnCreateOptionsMenu(menu);
       // }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add:
                    //Add button clicked
                    mEmails.Add(new Email() { Name = "New Name", Subject = "New Subject", Message = "New Message" });
                    mAdapter.NotifyItemInserted(mEmails.Count - 1);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
    public class RecyclerAdapter : RecyclerView.Adapter
    {
        private List<Email> mEmails;
        private RecyclerView mRecyclerView;
        private Context mContext;
        private int mCurrentPosition = -1;

        public RecyclerAdapter(List<Email> emails, RecyclerView recyclerView, Context context)
        {
            mEmails = emails;
            mRecyclerView = recyclerView;
            mContext = context;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public TextView mName { get; set; }
            public TextView mSubject { get; set; }
            public TextView mMessage { get; set; }

            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }

        public class MyView2 : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }

            public MyView2(View view) : base(view)
            {
                mMainView = view;
            }
        }

        public override int GetItemViewType(int position)
        {
            if ((position % 2) == 0)
            {
                //Even number
                return Resource.Layout.row1;
            }

            else
            {
                //Odd number
                return Resource.Layout.row2;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == Resource.Layout.row1)
            {
                //First card view
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row1, parent, false);

                TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
                TextView txtSubject = row.FindViewById<TextView>(Resource.Id.txtSubject);
                TextView txtMessage = row.FindViewById<TextView>(Resource.Id.txtMessage);

                MyView view = new MyView(row) { mName = txtName, mSubject = txtSubject, mMessage = txtMessage };
                return view;
            }

            else
            {
                //Second card view
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row2, parent, false);
                MyView2 view = new MyView2(row);
                return view;
            }

        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is MyView)
            {
                //First view
                MyView myHolder = holder as MyView;
                myHolder.mMainView.Click += mMainView_Click;
                myHolder.mName.Text = mEmails[position].Name;
                myHolder.mSubject.Text = mEmails[position].Subject;
                myHolder.mMessage.Text = mEmails[position].Message;

                if (position > mCurrentPosition)
                {
                    int currentAnim = Resource.Animation.slide_left_to_right;
                    SetAnimation(myHolder.mMainView, currentAnim);
                    mCurrentPosition = position;
                }
            }

            else
            {
                //Second View
                MyView2 myHolder = holder as MyView2;
                if (position > mCurrentPosition)
                {
                    int currentAnim = Resource.Animation.slide_right_to_left;
                    SetAnimation(myHolder.mMainView, currentAnim);
                    mCurrentPosition = position;
                }
            }

        }

        private void SetAnimation(View view, int currentAnim)
        {
            Animator animator = AnimatorInflater.LoadAnimator(mContext, Resource.Animation.flip);
            animator.SetTarget(view);
            animator.Start();
            //Animation anim = AnimationUtils.LoadAnimation(mContext, currentAnim);
            //view.StartAnimation(anim);
        }

        void mMainView_Click(object sender, EventArgs e)
        {
            int position = mRecyclerView.GetChildPosition((View)sender);
            Console.WriteLine(mEmails[position].Name);
        }

        public override int ItemCount
        {
            get { return mEmails.Count; }
        }
    }
}