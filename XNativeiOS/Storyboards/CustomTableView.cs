using System.Collections.Generic;
using UIKit;
using XNativeiOS.Models;
using XNativeiOS.ViewSources;

namespace XNativeiOS.Storyboards
{
    public class CustomTableView : UIViewController {
		UITableView table;

		public CustomTableView()
		{	
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;

			//table.BackgroundColor = UIColor.FromRGB (218, 255, 127);
			table.SeparatorColor = UIColor.FromRGB(127, 106, 0);

			List<TableItem> tableItems = new List<TableItem>();

			// credit for images
			// http://en.wikipedia.org/wiki/List_of_culinary_vegetables
			tableItems.Add(new TableItem("Vegetables") { SubHeading = "65 items", ImageName = "Images/Green/GreenMonkey.png" });
			tableItems.Add(new TableItem("Fruits") { SubHeading = "17 items", ImageName = "Images/Red/RedMonkey.png" });
			tableItems.Add(new TableItem("Flower Buds") { SubHeading = "5 items", ImageName = "Images/Green/GreenMonkey.png" });
			tableItems.Add(new TableItem("Legumes") { SubHeading = "33 items", ImageName = "Images/Red/RedMonkey.png" });
			tableItems.Add(new TableItem("Bulbs") { SubHeading = "18 items", ImageName = "Images/Green/GreenMonkey.png" });
			tableItems.Add(new TableItem("Tubers") { SubHeading = "43 items", ImageName = "Images/Red/RedMonkey.png" });
			table.Source = new CustomTableSource(tableItems);
			Add(table);
		}
	}
}