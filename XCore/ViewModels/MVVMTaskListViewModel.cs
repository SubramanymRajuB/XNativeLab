using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using XCore.Models;

namespace XCore.ViewModels
{
    public class MVVMTaskListViewModel: MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly MvxSubscriptionToken _token;

        public IMvxCommand AddCommand => new MvxCommand(AddTask);

        public MVVMTaskListViewModel(IMvxNavigationService navigationService, IMvxMessenger messenger)
        {
            _navigationService = navigationService;
            TaskList = new ObservableCollection<Task> {
                new Task {Id=Guid.NewGuid(), Name="Groceries", Notes="Buy bread, cheese, apples", Done=false},
                new Task {Id=Guid.NewGuid(), Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}
            };

            _token = messenger.Subscribe<TaskMessage>(UpdateItem);
        }

        void UpdateItem(TaskMessage message)
        {
            var task = message.Task;
            if (task != null)
            {
                if (task.Status == "delete")
                {
                    TaskList.Remove(task);
                }
                else if (task.Status == "insert")
                {
                    TaskList.Add(task);
                }
                else if (task.Status == "update")
                {
                    var item = TaskList.FirstOrDefault(x => x.Id == task.Id);
                    if (item != null)
                    {
                        item.Name = task.Name;
                        item.Notes = task.Notes;
                        item.Done = task.Done;
                    }
                }
            }
        }

        public string pageTitle;
        public string PageTitle
        {
            get => pageTitle;
            set
            {
                pageTitle = value;
                RaisePropertyChanged();
            }
        }

        ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> TaskList
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        Task _selectedTask;
        public Task SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                _navigationService.Navigate<MVVMTaskDetailsViewModel, Task>(_selectedTask);
                RaisePropertyChanged();
            }
        }

        public MvxCommand<Task> ItemClickCommand
        {
            get
            {
                return new MvxCommand<Task>(selectedList =>
                {
                    _navigationService.Navigate<MVVMTaskDetailsViewModel, Task>(selectedList);
                });
            }
        }

        private void AddTask()
        {
            _navigationService.Navigate<MVVMTaskDetailsViewModel, Task>(null);
        }
    }
}
