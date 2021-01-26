using System;
using Foundation;
using UIKit;
using XCore.Models;

namespace XNativeiOS.Storyboards
{
    public partial class FirstDemoView : UIViewController
    {
        public FirstDemoView(IntPtr handle) : base(handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			string translatedNumber = "";

			BtnTranslate.TouchUpInside += (object sender, EventArgs e) => {
				// Convert the phone number with text to a number 
				// using PhoneTranslator.cs
				translatedNumber = PhoneTranslator.ToNumber(
					TxtPhone.Text);

				// Dismiss the keyboard if text field was tapped
				TxtPhone.ResignFirstResponder();

				if (translatedNumber == "")
				{
					BtnCall.SetTitle("Call ", UIControlState.Normal);
					BtnCall.Enabled = false;
				}
				else
				{
					BtnCall.SetTitle("Call " + translatedNumber,
						UIControlState.Normal);
					BtnCall.Enabled = true;
				}
			};

			BtnCall.TouchUpInside += (object sender, EventArgs e) => {
				var url = new NSUrl("tel:" + translatedNumber);
				// Use URL handler with tel: prefix to invoke Apple's Phone app, 
				// otherwise show an alert dialog                
				if (!UIApplication.SharedApplication.OpenUrl(url))
				{
					var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
					PresentViewController(alert, true, null);
				}
			};
		}
	}
}