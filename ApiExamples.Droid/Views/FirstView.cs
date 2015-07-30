using Android.App;
using Android.OS;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.Droid.Views;

namespace ApiExamples.Droid.Views
{
    [Activity(Label = "Api examples")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }

    [Activity(NoHistory = true)]
    public class BatteryView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Battery);
        }
    }
}