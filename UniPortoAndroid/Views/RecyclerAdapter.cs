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
using UniPortoAndroid.Helpers;
using Square.Picasso;
using Android.Webkit;
using Android.Media.Session;
using Android.Views.Animations;

namespace UniPortoAndroid.Views
{
    public class RecyclerAdapter : RecyclerView.Adapter
    {

       
        private List<Email> mEmails;
        private RecyclerView mRecyclerView;
        private Context mContext;
        private ImageView ImgUrl;
        private int mCurrentPosition = -1;


        // private int mCurrentPosition = -1;

        public RecyclerAdapter(List<Email> emails, RecyclerView recyclerView, Context context)
        {
            mEmails = emails;
            mRecyclerView = recyclerView;
            mContext = context;
            var myImage = UniPortoMobileContext.profile.ProfileImage;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public TextView mName { get; set; }
            public TextView mSubject { get; set; }
            public TextView mMessage { get; set; }
            public ImageView mUrlpro { get; set; }


            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public class MyView2 : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public TextView mName { get; set; }
            public TextView mSubject { get; set; }
            public TextView mMessage { get; set; }
            public ImageView mImgUrl { get; set; }
            public ImageView mUrlpro { get; set; }
            public MyView2(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public class MyView3 : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public TextView mName { get; set; }
            public TextView mSubject { get; set; }
            public TextView mMessage { get; set; }
            public TextView mUrl { get; set; }
            public ImageView mUrlpro { get; set; }
            public WebView mVidoe { get; set; }
            public VideoView m1Vidoe { get; set; }
            public Button bt1 { get; set; }


            public MyView3(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public class MyView4 : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }

            public MyView4(View view) : base(view)
            {
                mMainView = view;
            }
        }

        public override int GetItemViewType(int position)
        {
            //if (mEmails[x].TypeAt == 2)
            if (mEmails[position].TypeAt == 1)
            {
               //Even number
                return Resource.Layout.row1;
            }

            else if (mEmails[position].TypeAt == 2)
            {
                //Odd number
                return Resource.Layout.row2;
            }
            else if (mEmails[position].TypeAt == 3)
            {
                return Resource.Layout.row3;
            }
            else
            {
                return Resource.Layout.row4;
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
                ImageView ImgurlPro = row.FindViewById<ImageView>(Resource.Id.circleImageView1);

                MyView view = new MyView(row) { mName = txtName, mSubject = txtSubject, mMessage = txtMessage,mUrlpro = ImgurlPro };
                return view;
            }
            else if (viewType == Resource.Layout.row2)
            {
                //Second card view
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row2, parent, false);
                TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
                TextView txtSubject = row.FindViewById<TextView>(Resource.Id.txtSubject);
                TextView txtMessage = row.FindViewById<TextView>(Resource.Id.txtMessage);
                ImageView ImgUrl = row.FindViewById<ImageView>(Resource.Id.imageView1);
                ImageView ImgurlPro = row.FindViewById<ImageView>(Resource.Id.circleImageView1);
               


                MyView2 view = new MyView2(row) { mName = txtName, mSubject = txtSubject, mMessage = txtMessage,mImgUrl=ImgUrl, mUrlpro = ImgurlPro };
                
                return view;
            }
            else if (viewType == Resource.Layout.row3)
            {
                //Second card view
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row3, parent, false);
                TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
                TextView txtSubject = row.FindViewById<TextView>(Resource.Id.txtSubject);
                TextView txtMessage = row.FindViewById<TextView>(Resource.Id.txtMessage);
                ImageView ImgurlPro = row.FindViewById<ImageView>(Resource.Id.circleImageView1);
                  WebView videourl  = row.FindViewById<WebView>(Resource.Id.webView1);

               // Button btn = row.FindViewById<Button>(Resource.Id.button1);
              // VideoView video = row.FindViewById<VideoView>(Resource.Id.videoView1);
                MyView3 view = new MyView3(row) { mName = txtName, mSubject = txtSubject, mMessage = txtMessage, mUrlpro = ImgurlPro , mVidoe=videourl};
                return view;
            }
            else
            {
                //Second card view
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row4, parent, false);
                MyView4 view = new MyView4(row);
                return view;
            }

        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is MyView)
            {
                //First view
                MyView myHolder = holder as MyView;

                myHolder.mName.Text = mEmails[position].Name;
                myHolder.mSubject.Text = mEmails[position].Subject;
                myHolder.mMessage.Text = mEmails[position].Message;
                if (UniPortoMobileContext.profile.ProfileImage != null)
                {
                    Picasso.With(mContext).Load(UniPortoMobileContext.profile.ProfileImage).Into(myHolder.mUrlpro);
                }
                if (position > mCurrentPosition)
                {
                    int currentAnim = Resource.Animation.slide_left_to_right;
                    SetAnimation(myHolder.mMainView, currentAnim);
                    mCurrentPosition = position;
                }

            }

            else if (holder is MyView2)
            {
                //Second View
                MyView2 myHolder = holder as MyView2;
                myHolder.mName.Text = mEmails[position].Name;
                myHolder.mSubject.Text = mEmails[position].Subject;
                myHolder.mMessage.Text = mEmails[position].Message;
                Picasso.With(mContext).Load(mEmails[position].UrlAtt).Into(myHolder.mImgUrl);
                if (UniPortoMobileContext.profile.ProfileImage != null)
                {
                    Picasso.With(mContext).Load(UniPortoMobileContext.profile.ProfileImage).Into(myHolder.mUrlpro);
                }
                if (position > mCurrentPosition)
                {
                    int currentAnim = Resource.Animation.slide_right_to_left;
                    SetAnimation(myHolder.mMainView, currentAnim);
                    mCurrentPosition = position;
                }

            }
            else if (holder is MyView3)
            {
                //third View
                MyView3 myHolder = holder as MyView3;
               
                myHolder.mName.Text = mEmails[position].Name;
                myHolder.mSubject.Text = mEmails[position].Subject;
                myHolder.mMessage.Text = mEmails[position].Message;
                //var Uri = Android.Net.Uri.Parse(mEmails[position].UrlAtt);
          
                // WebSettings webSettings = myHolder.mVidoe.Settings;

                string x = "<html><body><video poster preload='true' controls autoplay width='320' controls>< source src =" + mEmails[position].UrlAtt +" type ='video/mp4'></video></body></html>";
              // myHolder.mVidoe.LoadData(x, "text/html", null);
                //  myHolder.mVidoe.LoadDataWithBaseURL("file:///android_asset/ht.html?name=https://uniporto.blob.core.windows.net/uniporto/6b82632b-d7d1-46fe-be58-e8af7dd57ee0", "https://uniporto.blob.core.windows.net/uniporto/6b82632b-d7d1-46fe-be58-e8af7dd57ee0", "text/html", "UTF-8", null);
                

                // myHolder.mVidoe.SetWebViewClient(new HelloWebViewClient());
                // myHolder.mVidoe.SetWebChromeClient(new WebChromeClient());
                // myHolder.mVidoe.LoadUrl(mEmails[position].UrlAtt);
                // Android.Widget.MediaController med = new Android.Widget.MediaController(mContext);
                //  med.SetAnchorView(myHolder.m1Vidoe);
                // var Uri = Android.Net.Uri.Parse(mEmails[position].UrlAtt);
                // myHolder.m1Vidoe.SetVideoURI(Uri);
                //  myHolder.m1Vidoe.SetMediaController(med);
                //  myHolder.m1Vidoe.SetVideoURI(Uri);
                // myHolder.m1Vidoe.RequestFocus();
                // myHolder.m1Vidoe.Start();
                // myHolder.bt1.Click += delegate
                // {
                //   myHolder.m1Vidoe.SetVideoURI(Uri);
                //   myHolder.m1Vidoe.Start();
                // };
                myHolder.mVidoe.SetWebChromeClient(new WebChromeClient());

                myHolder.mVidoe.SetWebViewClient(new WebViewClient());
                myHolder.mVidoe.Settings.JavaScriptEnabled = true;
                myHolder.mVidoe.LoadUrl(mEmails[position].UrlAtt);
                //myHolder.mVidoe.LoadData(x, "Video/html", "UTF-8");
                if (UniPortoMobileContext.profile.ProfileImage != null)
                {
                    Picasso.With(mContext).Load(UniPortoMobileContext.profile.ProfileImage).Into(myHolder.mUrlpro);
                }
                if (position > mCurrentPosition)
                {
                    int currentAnim = Resource.Animation.slide_right_to_left;
                    SetAnimation(myHolder.mMainView, currentAnim);
                    mCurrentPosition = position;
                }
            }
            else
            {
                //Second View
                MyView4 myHolder = holder as MyView4;

            }

        }
        public class HelloWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
        }

        private void SetAnimation(View view, int currentAnim)
        {
            //Animator animator = AnimatorInflater.LoadAnimator(mContext, Resource.Animation.flip);
            // animator.SetTarget(view);
            // animator.Start();
            Animation anim = AnimationUtils.LoadAnimation(mContext, currentAnim);
            view.StartAnimation(anim);
        }



        public override int ItemCount
        {
            get { return mEmails.Count; }
        }
    }
}