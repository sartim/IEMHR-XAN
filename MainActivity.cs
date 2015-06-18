using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace IEMHRDroidApp
{
	[Activity(Label = "IEMHR Droid App", MainLauncher = true, Icon = "@drawable/xs")]
    public class MainActivity : Activity
    {
        private Button mBtnSignUp;
        private Button mBtnSignIn;
		private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            // Main layout controlls
            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mBtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
			mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mBtnSignUp.Click += (object sender, EventArgs args) =>
                {
                    // Pull up dialog
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    dialog_SignUp signUpDialog = new dialog_SignUp();
                    signUpDialog.Show(transaction, "dialog fragement");
					
					signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;

                };
			mBtnSignIn.Click += delegate
            {
                StartActivity(typeof(TabActivity));
            };

        }
       

		void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
		{
			mProgressBar.Visibility = ViewStates.Visible;
			Thread thread = new Thread(ActLikeRequest);
			thread.Start ();
		}

		private void ActLikeRequest()
		{
			Thread.Sleep(3000);

			RunOnUiThread(() => {mProgressBar.Visibility = ViewStates.Invisible;});
		}

    }
}

