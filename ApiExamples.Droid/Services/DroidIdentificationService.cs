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

using Android.Provider;



namespace ApiExamples.Droid.Services
{
    class DroidIdentificationService : Core.Services.IIdentificationService
    {
        public String GetDeviceId()
        {
            return Settings.Secure.GetString(Application.Context.ContentResolver, Settings.Secure.AndroidId);
        }
    }
}