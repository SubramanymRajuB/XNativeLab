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
    [Activity(Label = "Task Details", Theme = "@style/AppTheme")]
    public class MVVMTaskDetailsDemo : MvxActivity<MVVMTaskDetailsViewModel>
    {
        TextView txtTitle;
        EditText txtName;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.mvvm_taskdetails);
        }
    }
}
