using System;
using CoreGraphics;
using System.Collections.Generic;
using UIKit;
using XNativeiOS.ViewSources;

namespace XNativeiOS.Storyboards {
	public class  BasicTableView : UIViewController {
		UITableView table;

		public  BasicTableView ()
		{	
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var width = View.Bounds.Width;
			var height = View.Bounds.Height;

			table = new UITableView(new CGRect(0, 0, width, height));
			table.AutoresizingMask = UIViewAutoresizing.All;
			CreateTableItems();
			Add (table);
		}

		protected void CreateTableItems ()
		{
			List<string> tableItems = new List<string> ();
			tableItems.Add ("Vegetables");
			tableItems.Add ("Fruits");
			tableItems.Add ("Flower Buds");
			tableItems.Add ("Legumes");
			tableItems.Add ("Bulbs");
			tableItems.Add ("Tubers");
			table.Source = new BasicTableSource(tableItems.ToArray(), this);
		}

		public override bool PrefersStatusBarHidden ()
		{
			return true;
		}
	}
}