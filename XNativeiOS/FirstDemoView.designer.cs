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
	[Register ("FirstDemoView")]
	partial class FirstDemoView
	{
		[Outlet]
		UIKit.UIButton BtnCall { get; set; }

		[Outlet]
		UIKit.UIButton BtnTranslate { get; set; }

		[Outlet]
		UIKit.UITextField TxtPhone { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnCall != null) {
				BtnCall.Dispose ();
				BtnCall = null;
			}

			if (BtnTranslate != null) {
				BtnTranslate.Dispose ();
				BtnTranslate = null;
			}

			if (TxtPhone != null) {
				TxtPhone.Dispose ();
				TxtPhone = null;
			}
		}
	}
}
