using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using XCore.ViewModels;

namespace XNativeiOS.Storyboards
{
    [MvxFromStoryboard("MVVMCrossList")]
    public partial class MVVMTaskDetailsView : MvxTableViewController<MVVMTaskDetailsViewModel>
    {
        public MVVMTaskDetailsView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetLocalBindings();
        }

        void SetLocalBindings()
        {
            var bindingSet = this.CreateBindingSet<MVVMTaskDetailsView, MVVMTaskDetailsViewModel>();

            bindingSet.Bind(TxtHeader)
                      .For(c => c.Text)
                      .To(vm => vm.Name);

            bindingSet.Bind(TxtNotes)
                      .For(c => c.Text)
                      .To(vm => vm.Notes);

            bindingSet.Bind(SwitchDone)
                      .For(c => c.On)
                      .To(vm => vm.Done);

            bindingSet.Bind(BtnSave)
                      .To(vm => vm.SaveCommand);

            bindingSet.Bind(BtnDelete)
                      .To(vm => vm.DeleteCommand);

            bindingSet.Apply();
        }
    }
}