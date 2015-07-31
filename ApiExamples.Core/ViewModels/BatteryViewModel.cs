using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;
 

namespace ApiExamples.Core.ViewModels
{
    public class BatteryViewModel : TestViewModel
    {
        private readonly Services.IBatteryService _batteryService;

        public String State { get; set; }

        public BatteryViewModel(Services.IBatteryService batteryService)
        {
            _batteryService = batteryService;

            if (_batteryService.batteryLevel == null) {
                State = "unknown";
            } else {
                State = _batteryService.batteryLevel + "%"; 
            }
        }
    }
}
