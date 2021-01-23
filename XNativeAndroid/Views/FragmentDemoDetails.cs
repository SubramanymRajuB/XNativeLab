using Android.App;
using Android.OS;
using Android.Support.V7.App;
using XNativeAndroid.Fragements;

namespace XNativeAndroid.Views
{
    [Activity(Label = "Details Activity", Theme = "@style/Theme.AppCompat")]
    public class FragmentDemoDetails : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var index = Intent.Extras.GetInt("current_play_id", 0);

            var details = DetailsFragment.NewInstance(index); // Details
            var fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.Add(Android.Resource.Id.Content, details);
            fragmentTransaction.Commit();

    //        SupportFragmentManager // Get the support fragment manager instead of the FragmentManager
    //.BeginTransaction() // Start a transaction
    //.Add(Resource.Id.container, details, "coursesFragment") // Add the fragment
    //.Commit(); // Commit the changes
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }
    }
}