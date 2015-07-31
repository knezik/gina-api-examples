using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.MvvmCross.Plugins.Location;

namespace ApiExamples.Core.Services
{
    public interface ILocationService
    {
        string StatusMessage { get; }
        string Longitude { get; }
        string Latitude { get; }
    }
}
