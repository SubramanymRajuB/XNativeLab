using System;
using System.Collections.Generic;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using XCore.Models;

namespace XCore.ViewModels
{
    public class MVVMTaskDetailsViewModel : MvxViewModel<Task>
    {
        private readonly IMvxNavigationService _navigationService;
        IMvxMessenger _messenger;

        public IMvxCommand SaveCommand => new MvxCommand(SaveTask);
        public IMvxCommand DeleteCommand => new MvxCommand(DeleteTask);
        Task _task;
        string _action;
        public MVVMTaskDetailsViewModel(IMvxNavigationService navigationService, IMvxMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
        }

        public override void Prepare(Task task)
        {
            _task = task;
            if (_task != null)
            {
                Name = _task.Name;
                Notes = _task.Notes;
                Done = _task.Done;
                _action = "update";
                IsDelete = true;
            }
            else
            {
                IsDelete = false;
                _action = "insert";
            }
        }

        string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;
                RaisePropertyChanged();
            }
        }

        string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public string _notes;
        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                RaisePropertyChanged();
            }
        }

        public bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                _done = value;
                RaisePropertyChanged();
            }
        }

        public bool _isDelete=false;
        public bool IsDelete
        {
            get => _isDelete;
            set
            {
                _isDelete = value;
                RaisePropertyChanged();
            }
        }

        private void SaveTask()
        {
            if (_action == "update")
            {
                _task.Name = Name;
                _task.Notes = Notes;
                _task.Done = Done;
            }
            else
            {
                _task = new Task { Id = Guid.NewGuid(), Name = Name, Notes = Notes, Done = Done };
            }
            _task.Status = _action;
            TaskMessage message = new TaskMessage(this, _task);
            _messenger.Publish<TaskMessage>(message);
            _navigationService.Close(this);
        }

        private void DeleteTask()
        {
            if (_task != null)
            {
                _task.Status = "delete";
                TaskMessage message = new TaskMessage(this, _task);
                _messenger.Publish<TaskMessage>(message);
                _navigationService.Close(this);
            }
        }
    }
}
