using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiExamples.Core.Services
{
    public interface IBackgroundService<T> where T : BackgroundRunners.BaseBackgroundRunner
    {
        void StartService();

        void StopService();

        object GetRunnerProperty(string name);

        void SetRunnerProperty(string name, object value);

        void SendMessage(string descriptor, params object[] args);
    }
}
