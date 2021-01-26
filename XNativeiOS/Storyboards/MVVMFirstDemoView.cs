using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using XCore.ViewModels;

namespace XNativeiOS.Storyboards
{
    [MvxFromStoryboard("MVVMFirstDemo")]
    public partial class MVVMFirstDemoView : MvxViewController<FirstDemoViewModel>
    {
        public MVVMFirstDemoView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetLocalBindings();
        }

        void SetLocalBindings()
        {
            var bindingSet = this.CreateBindingSet<MVVMFirstDemoView, FirstDemoViewModel>();

            bindingSet.Bind(TxtPhone)
                      .For(c => c.Text)
                      .To(vm => vm.Phone);

            bindingSet.Bind(BtnTranslate)
                      .To(vm => vm.TranslateCommand);

            BtnCall.TouchUpInside += Call_Click;

            bindingSet.Bind(BtnCall).For(tf => tf.Enabled).To(vm => vm.IsCall);

            bindingSet.Bind(BtnCall).For("Title").To(vm => vm.CallTitle);


            bindingSet.Apply();
        }

        void Call_Click(object sender, EventArgs e)
        {
            var url = new NSUrl("tel:" + this.ViewModel.TranslateNo);
            // Use URL handler with tel: prefix to invoke Apple's Phone app, 
            // otherwise show an alert dialog                
            if (!UIApplication.SharedApplication.OpenUrl(url))
            {
                var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            }
        }
    }
}