using System;
using System.Collections.Generic;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XCore.Models;

namespace XCore.ViewModels
{
    public class MVVMTaskListViewModel: MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand AddCommand => new MvxCommand(AddTask);
        public MVVMTaskListViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            TaskList = new List<Task> {
                new Task {Name="Groceries", Notes="Buy bread, cheese, apples", Done=false},
                new Task {Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}
            };
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

        List<Task> _tasks;
        public List<Task> TaskList
        {
            get => _tasks;
            set
            {
                _tasks = value;
                RaisePropertyChanged();
            }
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
