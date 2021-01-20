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
	[Register ("MVVMTaskCell")]
	partial class MVVMTaskCell
	{
		[Outlet]
		UIKit.UILabel TxtHeader { get; set; }

		[Outlet]
		UIKit.UILabel TxtSubHeader { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TxtSubHeader != null) {
				TxtSubHeader.Dispose ();
				TxtSubHeader = null;
			}

			if (TxtHeader != null) {
				TxtHeader.Dispose ();
				TxtHeader = null;
			}
		}
	}
}
