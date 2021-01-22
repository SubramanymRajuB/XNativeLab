using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using XNativeAndroid;
using XNativeAndroid.Adapters;
using XNativeAndroid.Models;

namespace XNativeAndroid.Views
{
    //[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    //[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class CustomArrayAdapterDemo : ListActivity
    {
        List<TableItem> tableItems = new List<TableItem>();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            tableItems.Add(new TableItem() { Heading = "Vegetables", SubHeading = "65 items", ImageResourceId = Resource.Drawable.Vegetables });
            tableItems.Add(new TableItem() { Heading = "Fruits", SubHeading = "17 items", ImageResourceId = Resource.Drawable.Fruits });
            tableItems.Add(new TableItem() { Heading = "Flower Buds", SubHeading = "5 items", ImageResourceId = Resource.Drawable.FlowerBuds });
            tableItems.Add(new TableItem() { Heading = "Legumes", SubHeading = "33 items", ImageResourceId = Resource.Drawable.Legumes });
            tableItems.Add(new TableItem() { Heading = "Bulbs", SubHeading = "18 items", ImageResourceId = Resource.Drawable.Bulbs });
            tableItems.Add(new TableItem() { Heading = "Tubers", SubHeading = "43 items", ImageResourceId = Resource.Drawable.Tubers });

            // Select multiple rows for activated ListViews:
            // ListView.ChoiceMode = ChoiceMode.Multiple;
            ListView.ChoiceMode = ChoiceMode.Single;

            ListAdapter = new BasicTableAdapter(this, tableItems);
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = tableItems[position];
            Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t.Heading);
        }
    }
}
