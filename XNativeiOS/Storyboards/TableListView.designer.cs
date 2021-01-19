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
	[Register ("TableListView")]
	partial class TableListView
	{
		[Outlet]
		UIKit.UIBarButtonItem BtnAdd { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnAdd != null) {
				BtnAdd.Dispose ();
				BtnAdd = null;
			}
		}
	}
}
