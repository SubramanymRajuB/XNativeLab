
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XNativeAndroid.Fragements
{
    // these fragemtns for tab layout demo
    public class SpeakersFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragement_tab, null);
            view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.speakers_tab_label);

            var img = view.FindViewById<ImageView>(Resource.Id.imageView1);
            img.SetImageResource(Resource.Drawable.ic_action_speakers);
            var filter = new PorterDuffColorFilter(Color.Black, PorterDuff.Mode.SrcIn);
            img.SetColorFilter(filter);

            return view;
        }
    }

    public class SessionsFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragement_tab, null);
            view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.sessions_tab_label);

            var img = view.FindViewById<ImageView>(Resource.Id.imageView1);
            img.SetImageResource(Resource.Drawable.ic_action_sessions);
            var filter = new PorterDuffColorFilter(Color.Black, PorterDuff.Mode.SrcIn);
            img.SetColorFilter(filter);

            return view;
        }
    }

    public class WhatsOnFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragement_tab, null);
            view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.sessions_tab_label);

            var img = view.FindViewById<ImageView>(Resource.Id.imageView1);
            img.SetImageResource(Resource.Drawable.ic_action_whats_on);
            var filter = new PorterDuffColorFilter(Color.Black, PorterDuff.Mode.SrcIn);
            img.SetColorFilter(filter);

            return view;
        }
    }
}
