using System;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace XCore.Models
{
    public class Task : MvxNotifyPropertyChanged
    {
        public Guid Id { get; set; }

        string _name;
		public string Name { get => _name;

            set => SetProperty(ref _name, value);
        }

        string _notes;
        public string Notes
        {
            get => _notes;

            set => SetProperty(ref _notes, value);
        }

        bool _done;
        public bool Done
        {
            get => _done;

            set => SetProperty(ref _done, value);
        }

        public string Status { get; set; }
    }


    public class TaskMessage : MvxMessage
    {
        public TaskMessage(object sender, Task task)
       : base(sender)
        {
            this.Task = task;
        }
        public Task Task;
    }
}
