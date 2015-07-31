using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ApiExamples.Core.Services
{
    public interface IBatteryService
    {
        bool? isCharging { get; }
        bool? usbCharge { get; }
        bool? acCharge { get; }

        float? batteryLevel { get; }
    }
}