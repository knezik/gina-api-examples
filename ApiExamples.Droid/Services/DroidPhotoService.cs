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


using Media.Plugin;
using System.Threading.Tasks;

namespace ApiExamples.Droid.Services
{
    class DroidPhotoService : Core.Services.IPhotoService
    {
        public async Task<bool> TakePhoto()
        {

            if (!CrossMedia.Current.IsCameraAvailable)
            {
                return false;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Media.Plugin.Abstractions.StoreCameraMediaOptions
            {
                Directory = "GINA",
                Name = "photo"
            });

            return true;
        }
    }
}