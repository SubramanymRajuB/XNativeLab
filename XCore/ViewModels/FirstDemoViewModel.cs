using System;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using XCore.Models;

namespace XCore.ViewModels
{
    public class FirstDemoViewModel: MvxViewModel
    {
        public IMvxCommand TranslateCommand => new MvxCommand(TranslateText);
        public FirstDemoViewModel()
        {
        }

        bool _isCall=false;
        public bool IsCall
        {
            get => _isCall;
            set
            {
                _isCall = value;
                RaisePropertyChanged();
            }
        }

        string _translateNo;
        public string TranslateNo
        {
            get => _translateNo;
            set
            {
                _translateNo = value;
                RaisePropertyChanged();
            }
        }

        string _callTitle= "Call";
        public string CallTitle
        {
            get => _callTitle;
            set
            {
                _callTitle = value;
                RaisePropertyChanged();
            }
        }

        string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                RaisePropertyChanged();
            }
        }

        private void TranslateText()
        {
            TranslateNo = PhoneTranslator.ToNumber(Phone);
            IsCall = !string.IsNullOrEmpty(TranslateNo);
            if (IsCall)
            {
                CallTitle = "Call " + TranslateNo;
            }
        }
    }
}
