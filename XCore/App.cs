using MvvmCross;
using MvvmCross.ViewModels;
using XCore.ViewModels;

namespace XCore
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Mvx.RegisterType<ICalculationService, CalculationService>();

            // RegisterAppStart<FirstDemoViewModel>();
            RegisterAppStart<MVVMTaskListViewModel>();
        }
    }
}
