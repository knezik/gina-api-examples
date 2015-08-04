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

namespace ApiExamples.Droid.Services
{
    [Service]
    class DroidBackgroundService : Service, Core.Services.IBackgroundService
    {
        private IBinder _binder;

        public override IBinder OnBind(Intent intent)
        {
            _binder = new DroidBackgroundServiceBinder(this);
            return _binder;
        }

        [Obsolete]
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            return StartCommandResult.Sticky;
        }
    }


    public class DroidBackgroundServiceBinder : Binder
    {
        public DroidBackgroundService Service
        {
            get { return _service; }
        }

        protected DroidBackgroundService _service;

        public bool IsBound { get; set; }

        public DroidBackgroundServiceBinder(DroidBackgroundService service) {
            _service = service;
        }
    }
}