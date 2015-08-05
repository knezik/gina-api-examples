using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore;
using ApiExamples.Core.BackgroundRunners;
using ApiExamples.Core.Services;


namespace ApiExamples.Droid.Services
{
    class DroidBackgroundServiceFactory : Core.Services.IBackgroundServiceFactory
    {
        public IBackgroundService<T> MakeBackgroundServiceFromRunner<T>() where T : BaseBackgroundRunner
        {
            return new DroidBackgroundService<T>();
        }
    }
}
