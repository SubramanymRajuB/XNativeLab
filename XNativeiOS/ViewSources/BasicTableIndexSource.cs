using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Foundation;
using UIKit;
using XNativeiOS.Storyboards;

namespace XNativeiOS.ViewSources
{
	public class BasicTableIndexSource : UITableViewSource
	{
		string cellIdentifier = "TableCell";

		Dictionary<string, List<string>> indexedTableItems;
		string[] keys;
		BasicTableView owner;

		public BasicTableIndexSource(string[] items, BasicTableView owner)
		{
			this.owner = owner;

			indexedTableItems = new Dictionary<string, List<string>>();
			foreach (var t in items)
			{
				if (indexedTableItems.ContainsKey(t[0].ToString()))
				{
					indexedTableItems[t[0].ToString()].Add(t);
				}
				else
				{
					indexedTableItems.Add(t[0].ToString(), new List<string>() { t });
				}
			}
			keys = indexedTableItems.Keys.ToArray();
		}

		/// <summary>
		/// Called by the TableView to determine how many sections(groups) there are.
		/// </summary>
		public override nint NumberOfSections(UITableView tableView)
		{
			return keys.Length;
		}

		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return indexedTableItems[keys[section]].Count;
		}

		/// <summary>
		/// Sections the index titles.
		/// </summary>
		public override String[] SectionIndexTitles(UITableView tableView)
		{
			return indexedTableItems.Keys.ToArray();
		}

		/// <summary>
		/// The string to show in the section header
		/// </summary>
		//public override string TitleForHeader(UITableView tableView, nint section)
		//{
		//	return keys[section];
		//}

		/// <summary>
		/// The string to show in the section footer
		/// </summary>
		//public override string TitleForFooter(UITableView tableView, nint section)
		//{
		//	return indexedTableItems[keys[section]].Count + " items";
		//}

		/// <summary>
		/// Called when a row is touched
		/// </summary>
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			UIAlertController okAlertController = UIAlertController.Create("Row Selected", indexedTableItems[keys[indexPath.Section]][indexPath.Row], UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			owner.PresentViewController(okAlertController, true, null);
			tableView.DeselectRow(indexPath, true);
		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{

			// request a recycled cell to save memory
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);


			// UNCOMMENT one of these to use that style
			var cellStyle = UITableViewCellStyle.Default;
			//			var cellStyle = UITableViewCellStyle.Subtitle;
			//			var cellStyle = UITableViewCellStyle.Value1;
			//			var cellStyle = UITableViewCellStyle.Value2;

			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell(cellStyle, cellIdentifier);

			// Value2 style doesn't support an image
			if (cellStyle != UITableViewCellStyle.Value2)
			{
				cell.ImageView.Image = UIImage.FromBundle("first");
			}


			// UNCOMMENT one of these to see that accessory
			//cell.Accessory = UITableViewCellAccessory.Checkmark;
			// cell.Accessory = UITableViewCellAccessory.DetailButton;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			//cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;  // implement AccessoryButtonTapped
			//cell.Accessory = UITableViewCellAccessory.None; // to clear the accessory

			cell.TextLabel.Text = indexedTableItems[keys[indexPath.Section]][indexPath.Row];

			return cell;
		}
	}
}