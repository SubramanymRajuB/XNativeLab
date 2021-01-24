using System;
using Android;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using Xamarin.Essentials;

namespace XNativeAndroid.Views
{
    public class IntentsDemo : AppCompatActivity
    {
        TextView txtTitle;
        EditText txtName;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.intent_demo);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Get our UI controls from the loaded layout

            txtTitle = FindViewById<TextView>(Resource.Id.txtTitle);

            txtName = FindViewById<EditText>(Resource.Id.TxtName);


            Button submitButton = FindViewById<Button>(Resource.Id.SubmitButton);

            submitButton.Click += (sender, e) =>
            {
                //if EditText in not Empty    
                if (txtName.Text != "")
                {
                    //Navigation Without Data
                    //var intent = new Intent(this, typeof(IntentsSecondActivity));
                    //StartActivity(intent);

                    //Navigation With simple Data
                    //Intent i = new Intent(this, typeof(IntentsSecondActivity));
                    //i.PutExtra("Name", txtName.Text.ToString());
                    //StartActivity(i);

                    //Navigation With multi Data
                    //Intent i = new Intent(this, typeof(IntentsSecondActivity));
                    //i.PutExtra("Name", txtName.Text.ToString());
                    //i.PutExtra("in_reply_to", "george");
                    //i.PutExtra("code", 400);
                    //StartActivity(i);

                    //Navigation With returning result
                    Intent i = new Intent(this, typeof(IntentsSecondActivity));
                    i.PutExtra("Name", txtName.Text.ToString());
                    i.PutExtra("in_reply_to", "george");
                    i.PutExtra("code", 400);
                    StartActivityForResult(i, 0);
                }
                else
                {
                    Toast.MakeText(this, "Please Provide Name", ToastLength.Short).Show();
                }
            };

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

            Button urlButton = FindViewById<Button>(Resource.Id.UrlButton);

            urlButton.Click += (sender, e) =>
            {
                Intent browserIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://xamarin.com"));
                StartActivity(browserIntent);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                txtTitle.Text = "Second Activity Value";
                txtName.Text = data.GetStringExtra("resultBack");
            }
        }
    }
}
