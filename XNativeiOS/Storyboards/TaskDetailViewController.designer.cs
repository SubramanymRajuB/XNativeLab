// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XNativeiOS.Storyboards
{
	[Register ("TaskDetailViewController")]
	partial class TaskDetailViewController
	{
		[Outlet]
		UIKit.UIButton BtnDelete { get; set; }

		[Outlet]
		UIKit.UIButton BtnSave { get; set; }

		[Outlet]
		UIKit.UISwitch SwitchDone { get; set; }

		[Outlet]
		UIKit.UITextField TxtNotes { get; set; }

		[Outlet]
		UIKit.UITextField TxtTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnSave != null) {
				BtnSave.Dispose ();
				BtnSave = null;
			}

			if (BtnDelete != null) {
				BtnDelete.Dispose ();
				BtnDelete = null;
			}

			if (SwitchDone != null) {
				SwitchDone.Dispose ();
				SwitchDone = null;
			}

			if (TxtNotes != null) {
				TxtNotes.Dispose ();
				TxtNotes = null;
			}

			if (TxtTitle != null) {
				TxtTitle.Dispose ();
				TxtTitle = null;
			}
		}
	}
}
