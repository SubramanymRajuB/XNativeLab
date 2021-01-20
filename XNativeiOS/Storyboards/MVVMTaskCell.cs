using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using XCore.Models;

namespace XNativeiOS.Storyboards
{
    [MvxFromStoryboard("MVVMCrossList")]
    public partial class MVVMTaskCell : MvxTableViewCell
    {
        public MVVMTaskCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() => {
            var charitySet = this.CreateBindingSet<MVVMTaskCell, Task>();
                        charitySet.Bind(TxtHeader)
                          .To(ci => ci.Name);

                        charitySet.Bind(TxtSubHeader)
                                 .To(ci => ci.Notes);
                        charitySet.Apply();

            });
        }
    }
}