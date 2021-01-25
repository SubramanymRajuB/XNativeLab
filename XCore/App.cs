using MvvmCross;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using XCore.ViewModels;

namespace XCore
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Mvx.Resolve<IMvxMessenger>();
            //Mvx.RegisterType<ICalculationService, CalculationService>();

            //RegisterAppStart<FirstDemoViewModel>();
            RegisterAppStart<MVVMTaskListViewModel>();
        }
    }
}
