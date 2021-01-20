using System;
using System.Collections.Generic;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XCore.Models;

namespace XCore.ViewModels
{
    public class MVVMTaskDetailsViewModel : MvxViewModel<Task>
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand SaveCommand => new MvxCommand(SaveTask);
        public IMvxCommand DeleteCommand => new MvxCommand(DeleteTask);
        Task _task;
        public MVVMTaskDetailsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(Task task)
        {
            _task = task;
            if (_task != null)
            {
                Name = _task.Name;
                Notes = _task.Notes;
                Done = _task.Done;
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

        private void SaveTask()
        {
            //TranslateNo = PhoneTranslator.ToNumber(Phone);
            //IsCall = !string.IsNullOrEmpty(TranslateNo);
            //if (IsCall)
            //{
            //    CallTitle = "Call " + TranslateNo;
            //}


        }

        private void DeleteTask()
        {
            //TranslateNo = PhoneTranslator.ToNumber(Phone);
            //IsCall = !string.IsNullOrEmpty(TranslateNo);
            //if (IsCall)
            //{
            //    CallTitle = "Call " + TranslateNo;
            //}
        }
    }
}
