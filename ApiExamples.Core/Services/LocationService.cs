using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;


namespace ApiExamples.Core.Services
{

    public class LocationService : ILocationService
    {
        public string StatusMessage { get; private set; }

        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        private readonly IMvxLocationWatcher _watcher;

        public LocationService(IMvxLocationWatcher watcher)
        {
            StatusMessage = "Current location is being resolved...";

            _watcher = watcher;
            _watcher.Start(new MvxLocationOptions() { TimeBetweenUpdates = new TimeSpan(0, 0, 1), Accuracy = MvxLocationAccuracy.Fine }, OnLocation, OnError);
        }

        private void OnLocation(MvxGeoLocation location)
        {
            StatusMessage = "Current location is:";
            Latitude = location.Coordinates.Latitude.ToString();
            Longitude = location.Coordinates.Longitude.ToString();
        }

        private void OnError(MvxLocationError error)
        {
            switch (error.Code) {
                case MvxLocationErrorCode.PermissionDenied : StatusMessage = "Access to location service denied"; break;
                case MvxLocationErrorCode.PositionUnavailable: StatusMessage = "Current position is unavailable"; break;
                case MvxLocationErrorCode.ServiceUnavailable: StatusMessage = "Location service is unavailable"; break;
                case MvxLocationErrorCode.Timeout: StatusMessage = "Location service has a timeout"; break;
            }

            Latitude = "";
            Longitude = "";
        }
    }
}
