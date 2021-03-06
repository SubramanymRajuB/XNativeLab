﻿using System;

using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using XNativeAndroid.Models;

namespace XNativeAndroid.Fragements
{
    public class DetailsFragment : Fragment
    {
        public int ShownPlayId => Arguments.GetInt("current_play_id", 0);

        public static DetailsFragment NewInstance(int playId)
        {
            var detailsFrag = new DetailsFragment { Arguments = new Bundle() };
            detailsFrag.Arguments.PutInt("current_play_id", playId);
            return detailsFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                // Currently in a layout without a container, so no reason to create our view.
                return null;
            }

            var scroller = new ScrollView(Activity);

            var text = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            text.SetPadding(padding, padding, padding, padding);
            text.TextSize = 24;
            text.Text = Shakespeare.Dialogue[ShownPlayId];

            scroller.AddView(text);

            return scroller;
        }

        public override void OnInflate(Activity activity, IAttributeSet attrs, Bundle savedInstanceState)
        {
            base.OnInflate(activity, attrs, savedInstanceState);
        }

        public override void OnAttach(Activity activity)
        {
            base.OnAttach(activity);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnPause()
        {
            base.OnPause();
        }
    }
}
