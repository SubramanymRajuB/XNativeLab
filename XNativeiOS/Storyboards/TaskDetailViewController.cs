using Foundation;
using System;
using UIKit;
using XNativeiOS.Models;

namespace XNativeiOS.Storyboards
{
	public partial class TaskDetailViewController : UITableViewController
	{
		Chores currentTask { get; set; }
		public TableListView Delegate { get; set; }

		public TaskDetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			BtnSave.TouchUpInside += (sender, e) =>
			{
				currentTask.Name = TxtTitle.Text;
				currentTask.Notes = TxtNotes.Text;
				currentTask.Done = SwitchDone.On;
				Delegate.SaveTask(currentTask);
			};

			BtnDelete.TouchUpInside += (sender, e) => Delegate.DeleteTask(currentTask);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			TxtTitle.Text = currentTask.Name;
			TxtNotes.Text = currentTask.Notes;
			SwitchDone.On = currentTask.Done;
		}

		// this will be called before the view is displayed
		public void SetTask(TableListView d, Chores task)
		{
			Delegate = d;
			currentTask = task;
		}
	}
}