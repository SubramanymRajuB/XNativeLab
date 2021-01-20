using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using XCore.ViewModels;
using XNativeiOS.Storyboards;

namespace CauseMobile_Consumer.iOS.ViewSources
{
    public class TaskListViewSource : MvxTableViewSource
    {

        NSString _cellIdentifier = new NSString("MVVMTaskCell");
        MVVMTaskListViewModel _viewModel;

        public TaskListViewSource(UITableView tableView, MVVMTaskListViewModel viewmodel) : base(tableView)
        {
            _viewModel = viewmodel;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var taskCell = (MVVMTaskCell)tableView.DequeueReusableCell(_cellIdentifier);

            if (indexPath.Row % 2 == 0)
            {
                taskCell.BackgroundColor = UIColor.White;
            }
            else
            {
                taskCell.BackgroundColor = UIColor.FromRGB(239, 218, 225);
            }
            return taskCell;
        }

        bool isLoadingMore = true;

        public async override void Scrolled(UIScrollView scrollView)
        {
            //scrollView.KeyboardDismissMode = UIScrollViewKeyboardDismissMode.OnDrag;
            //var height = scrollView.Frame.Size.Height;
            //var contentYoffset = scrollView.ContentOffset.Y;
            //var distanceFromBottom = scrollView.ContentSize.Height - contentYoffset;
            //if (isLoadingMore && distanceFromBottom < height)
            //{
            //    isLoadingMore = false;
            //    _viewModel.paymentPageNumber++;
            //    await _viewModel.RetrieveData(_viewModel.paymentPageNumber);
            //    isLoadingMore = true;
            //}
        }
    }
}
