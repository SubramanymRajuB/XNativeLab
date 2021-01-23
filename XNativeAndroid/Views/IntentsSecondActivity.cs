using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace XNativeAndroid.Views
{
    // [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    //[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
//    [IntentFilter(new[] { Intent.ActionSend }, Categories = new[] {
//    Intent.CategoryDefault,
//    Intent.CategoryBrowsable
//}, DataMimeType = "text/plain")]
    public class IntentsSecondActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.intent_demo);

            // Get intent, action and MIME type
            string action = Intent.Action;
            //Get intent type
            string type = Intent.Type;//Check if intent matches type and action
            if (Intent.ActionSend.Equals(action) && type != null)
            {
                if ("text/plain".Equals(type))
                {

                    // Make sure to check whether returned data will be null.
                    string titleOfPage = Intent.GetStringExtra(Intent.ExtraSubject);
                    string urlOfPage = Intent.GetStringExtra(Intent.ExtraText);
                    var imageUriOfPage = (Android.Net.Uri)Intent.GetParcelableExtra(Intent.ExtraStream);
                }
            }

            EditText txtName = FindViewById<EditText>(Resource.Id.TxtName);
            TextView txtTitle = FindViewById<TextView>(Resource.Id.txtTitle);
            txtTitle.Text = "First Activity Value";

             //Retrieve the data using Intent.GetStringExtra method    
             string name = Intent.GetStringExtra("Name");
            txtName.Text = name;

            ////The 0 is the default value if the key is not found
            int code = Intent.GetIntExtra("code", 0);


            Button submitButton = FindViewById<Button>(Resource.Id.SubmitButton);
            submitButton.Text = "Back";
            submitButton.Click += (sender, e) =>
            {
                // closes the activity and returns to first screen
                //this.Finish();

                //retun result
                Intent intent = new Intent(this, typeof(IntentsDemo)); //Added the type of Main Activity
                
                intent.PutExtra("resultBack", txtName.Text);
                SetResult(Result.Ok, intent); //added the SetResult method.
                this.Finish();
            };

            Button callButton = FindViewById<Button>(Resource.Id.CallButton);
            callButton.Visibility = Android.Views.ViewStates.Gone;

            Button urlButton = FindViewById<Button>(Resource.Id.UrlButton);
            urlButton.Visibility = Android.Views.ViewStates.Gone;
        }
    }
}
