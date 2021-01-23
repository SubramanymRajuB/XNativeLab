using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using XNativeAndroid.Fragements;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;


namespace XNativeAndroid.Views
{
    public class TabsDemo : AppCompatActivity
    {

        ViewPager viewpager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.tabs_demo);

            viewpager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            //SupportActionBar.SetIcon(Resource.Drawable.ic_done);
            SupportActionBar.SetTitle(Resource.String.tab_demo_label);

            //SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            //SupportActionBar.SetDisplayShowTitleEnabled(false);
            //SupportActionBar.SetHomeButtonEnabled(false);


            setupViewPager(viewpager);


            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (sender, e) => {
                Snackbar.Make(fab, "Here's a snackbar!", Snackbar.LengthLong).SetAction("Action",
                    v => Console.WriteLine("Action handler")).Show();
            };

            var tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewpager);
        }

        void setupViewPager(Android.Support.V4.View.ViewPager viewPager)
        {
            var adapter = new Adapter(SupportFragmentManager);
            adapter.AddFragment(new WhatsOnFragment(), GetString(Resource.String.whatson_tab_label));
            adapter.AddFragment(new SpeakersFragment(), GetString(Resource.String.speakers_tab_label));
            adapter.AddFragment(new SessionsFragment(), GetString(Resource.String.sessions_tab_label));

            viewPager.Adapter = adapter;
            viewpager.Adapter.NotifyDataSetChanged();
            //viewpager.OffscreenPageLimit(4);
        }

    }

    class Adapter : Android.Support.V4.App.FragmentPagerAdapter
    {
        List<V4Fragment> fragments = new List<V4Fragment>();
        List<string> fragmentTitles = new List<string>();


        public Adapter(V4FragmentManager fm) : base(fm)
        {
        }

        public void AddFragment(V4Fragment fragment, String title)
        {
            fragments.Add(fragment);
            fragmentTitles.Add(title);


        }

        public override V4Fragment GetItem(int position)
        {
            return fragments[position];

        }

        public override int Count
        {
            get { return fragments.Count; }
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(fragmentTitles[position]);
        }


    }

}