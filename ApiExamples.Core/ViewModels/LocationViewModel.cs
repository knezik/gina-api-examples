using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiExamples.Core.ViewModels
{
    class LocationViewModel : TestViewModel
    {
        private readonly Services.ILocationService _locationService;

        public String StatusMessage { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }

        public LocationViewModel(Services.ILocationService locationService)
        {
            _locationService = locationService;

            StatusMessage = locationService.StatusMessage;
            Latitude = locationService.Latitude;
            Longitude = locationService.Longitude;
        }
    }
 }
