using System;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using XCore.Models;
using XCore.ViewModels;

namespace XNativeAndroid.Views
{
    [Activity(Label = "MVVMCross Demo", Theme = "@style/AppTheme")]
    public class MVVMDemo : MvxActivity<FirstDemoViewModel>
    {
        TextView txtTitle;
        EditText txtName;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.mvvm_first_demo);

            Button callButton = FindViewById<Button>(Resource.Id.CallButton);

            callButton.Click += (sender, e) =>
            {
                //With native
                var permissionCheck = ContextCompat.CheckSelfPermission(this, Manifest.Permission.CallPhone);

                if (permissionCheck != Android.Content.PM.Permission.Granted)
                {
                    ActivityCompat.RequestPermissions(
                            this,
                            new String[] { Manifest.Permission.CallPhone },
                            0);
                }
                else
                {
                    Intent callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:3777789888"));
                    StartActivity(callIntent);
                }

                //With xamarin essentails
                //PhoneDialer.Open("3777789888");


                //Intent Filter demo
                //Intent si = new Intent(Intent.ActionSend);
                //si.SetType("text/plain");
                //si.PutExtra("email", "support@tutlane.com");
                //StartActivity(Intent.CreateChooser(si, "Choose Mail App"));
            };
        }
    }
}
