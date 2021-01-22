using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;

namespace XNativeAndroid.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.DesignDemo", MainLauncher = true)]
    //[Activity(Label = "@string/app_name", Theme = "@style/Theme.DesignDemo")]
    public class NavigationDrawerDemo : AppCompatActivity
    {

        DrawerLayout drawerLayout;
        NavigationView navigationView;
        private string mDrawerTitle;
        V7Toolbar toolbar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            mDrawerTitle = "Navigation Drawer";
            Title = mDrawerTitle;
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.navigation_drawer);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);


            // Create ActionBarDrawerToggle button and add it to the toolbar
            toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            //drawerToggle.DrawerIndicatorEnabled = false;
            //drawerToggle.SetHomeAsUpIndicator(Resource.Drawable.ic_done);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView);
        }

        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) => {
                switch (e.MenuItem.ItemId)
                {
                    case (Resource.Id.nav_home):
                        // React on 'nav_home' selection
                        break;
                    case (Resource.Id.nav_messages):
                        //
                        break;
                    case (Resource.Id.nav_friends):
                        // React on 'Friends' selection
                        break;
                    case (Resource.Id.nav_discussion):
                        // React on 'Friends' selection
                        break;
                }

                // update the main content by replacing fragments
                var fragment = PlanetFragment.NewInstance(e.MenuItem.ItemId);

                var fragmentManager = this.FragmentManager;
                var ft = fragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();

                Title = e.MenuItem.ToString();
                // Close drawer
                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            navigationView.InflateMenu(Resource.Menu.nav_menu);
            return true;

            // Inflate the menu; this adds items to the action bar if it is present.
            //this.MenuInflater.Inflate(Resource.Menu.navigation_drawer, menu);
            //return true;

        }

        internal class MyActionBarDrawerToggle : ActionBarDrawerToggle
        {
            NavigationDrawerDemo owner;

            public MyActionBarDrawerToggle(NavigationDrawerDemo activity, DrawerLayout layout, V7Toolbar toolbar, int openRes, int closeRes)
                : base(activity, layout, toolbar, openRes, closeRes)
            {
                owner = activity;
            }

            public override void OnDrawerClosed(View drawerView)
            {
                owner.Title = owner.Title;
                owner.InvalidateOptionsMenu();
            }

            public override void OnDrawerOpened(View drawerView)
            {
                owner.toolbar.Title = owner.mDrawerTitle;
                owner.InvalidateOptionsMenu();
            }
        }

        /**
	     * Fragment that appears in the "content_frame", shows a selected menu text
	     */
        internal class PlanetFragment : Fragment
        {
            public const string ARG_PLANET_NUMBER = "menu_number";

            public PlanetFragment()
            {
                // Empty constructor required for fragment subclasses
            }

            public static Fragment NewInstance(int position)
            {
                Fragment fragment = new PlanetFragment();
                Bundle args = new Bundle();
                args.PutInt(PlanetFragment.ARG_PLANET_NUMBER, position);
                fragment.Arguments = args;
                return fragment;
            }

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                               Bundle savedInstanceState)
            {
                View rootView = inflater.Inflate(Resource.Layout.drawerfragment, container, false);
                var i = this.Arguments.GetInt(ARG_PLANET_NUMBER);
                var iv = rootView.FindViewById<TextView>(Resource.Id.TxtSelectedMenu);
                iv.Text = this.Activity.Title +" Content";
                return rootView;
            }
        }

    }
}