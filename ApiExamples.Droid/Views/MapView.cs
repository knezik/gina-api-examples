using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;


namespace ApiExamples.Droid.Views
{
    [Activity(Label = "Map test", NoHistory = true)]
    public class MapView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Map);

            var mapLoader = Mvx.Resolve<Core.Services.IMapService>();

            Nutiteq.Ui.MapView mapViewer = (Nutiteq.Ui.MapView) FindViewById(Resource.Id.mapViewer);
            mapLoader.LoadNutiteqMap(mapViewer);
        }
    }
}