using Android.Content;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;

using Cirrious.CrossCore;


namespace ApiExamples.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            Mvx.RegisterSingleton<Core.Services.IBatteryService>(new Services.DroidBatteryService());
            Mvx.RegisterSingleton<Core.Services.IMapService>(new Services.DroidMapService());
            Mvx.RegisterSingleton<Core.Services.IBackgroundServiceFactory>(new Services.DroidBackgroundServiceFactory());
            Mvx.RegisterSingleton<Core.Services.IIdentificationService>(new Services.DroidIdentificationService());
            Mvx.RegisterSingleton<Core.Services.IPhotoService>(new Services.DroidPhotoService());
        }
    }
}