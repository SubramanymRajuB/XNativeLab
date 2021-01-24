using Android;
using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace XNativeAndroid
{
    [Activity(
        MainLauncher = true,
        Label = "XNativeAndroid",
        Icon = "@mipmap/ic_launcher",
        Theme = "@style/Theme.Splash",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.mvvm_splash)
        {
        }
    }
}