using System;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;

namespace XNativeAndroid.Views
{
    public class FragmentDemo : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            try
            {
                SetContentView(Resource.Layout.fragemnt_demo_main);
            }
            catch (Exception ex)
            {
                Log.Debug("MainActivity", ex.Message);
            }
        }
    }
}