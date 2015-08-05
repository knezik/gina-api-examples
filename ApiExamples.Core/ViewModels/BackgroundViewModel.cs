using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;


namespace ApiExamples.Core.ViewModels
{

    class BackgroundViewModel : TestViewModel
    {
        private readonly Services.IBackgroundService<BackgroundRunners.CounterRunner> _backgroundService;

        public string CounterState { get; set; }
     

        public string GetRunnerCounterState() {
            var result = _backgroundService.GetRunnerProperty("CounterState");

            return (result == null) ? "undefined" : result.ToString();
        }

        public BackgroundViewModel(Services.IBackgroundServiceFactory backgroundServiceFactory)
        {
            _backgroundService = backgroundServiceFactory.MakeBackgroundServiceFromRunner<BackgroundRunners.CounterRunner>();

            _backgroundService.StartService();
            CounterState = GetRunnerCounterState();
        }

        public ICommand StartCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _backgroundService.StartService();
                });
            }
        }

        public ICommand StopCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _backgroundService.StopService();
                });
            }
        }

        public ICommand UpdateStateCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    CounterState = GetRunnerCounterState();
                });
            }
        }
    }
}
