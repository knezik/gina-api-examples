using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiExamples.Core.Services
{
    public interface IBackgroundServiceFactory 
    {
        IBackgroundService<T> MakeBackgroundServiceFromRunner<T>() where T : BackgroundRunners.BaseBackgroundRunner;
    }
}
