using System;
using CauseMobile_Consumer.iOS.ViewSources;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using XCore.ViewModels;

namespace XNativeiOS.Storyboards
{
    [MvxFromStoryboard("MVVMCrossList")]
    //[MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MVVMTaskListView : MvxTableViewController<MVVMTaskListViewModel>
    {
        public MVVMTaskListView(IntPtr handle) : base(handle)
        {

        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "TaskSegue")
            { // set in Storyboard
                var navctlr = segue.DestinationViewController as TaskDetailViewController;
                if (navctlr != null)
                {
                    //var source = TableView.Source as RootTableSource;
                    //var rowPath = TableView.IndexPathForSelectedRow;
                    //var item = source.GetItem(rowPath.Row);
                    //navctlr.SetTask(this, item); // to be defined on the TaskDetailViewController
                }
            }
        }

        //public MVVMTaskListView() : base(nameof(MVVMTaskListView), null)
        //{
        //}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetLocalBindings();
        }

        void SetLocalBindings()
        {
            var bindingSet = this.CreateBindingSet<MVVMTaskListView, MVVMTaskListViewModel>();

            bindingSet.Bind(this)
                      .For(c => c.Title)
                      .To(vm => vm.PageTitle);

            TBTaskList.TableFooterView = new UIView() { Frame=new CoreGraphics.CGRect(0,0,0,0.001)};
            var source = new TaskListViewSource(TBTaskList, this.ViewModel);
            TBTaskList.Source = source;

                    bindingSet.Bind(source)
                              .To(vm => vm.TaskList).TwoWay();

                    bindingSet.Bind(source)
                              .For(c => c.SelectedItem)
                              .To(vm => vm.SelectedTask);


            bindingSet.Bind(BtnAdd)
                      .To(vm => vm.AddCommand);

            bindingSet.Apply();
        }
    }
}