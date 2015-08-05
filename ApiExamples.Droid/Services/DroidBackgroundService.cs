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
using System.Threading.Tasks;

namespace ApiExamples.Droid.Services
{
    public class DroidBackgroundService<T> : Core.Services.IBackgroundService<T> where T : Core.BackgroundRunners.BaseBackgroundRunner
    {
        // binder class
        private class RunnerBinder<T> : Binder where T : Core.BackgroundRunners.BaseBackgroundRunner
        {
            public RunnerService<T> Service
            {
                get { return _service; }
            }

            protected RunnerService<T> _service;

            public bool IsBound { get; set; }

            public RunnerBinder(RunnerService<T> service)
            {
                _service = service;
            }
        }


        // service class
        [Service]
        private class RunnerService<T> : Service where T : Core.BackgroundRunners.BaseBackgroundRunner
        {
            private IBinder _binder;
            private Core.BackgroundRunners.BaseBackgroundRunner _runner;


            public override IBinder OnBind(Intent intent)
            {
                _binder = new RunnerBinder<T>(this);
                return _binder;
            }

            public void StartRunner()
            {
                _runner = (Core.BackgroundRunners.BaseBackgroundRunner) Activator.CreateInstance(typeof(T));
                _runner.Run();
            }

            public object GetRunnerProperty(string name)
            {
                return _runner.GetType().GetProperty(name).GetValue(_runner, null);
            }

            public void SetRunnerProperty(string name, object value)
            {
                _runner.GetType().GetProperty(name).SetValue(_runner, value);
            }

            public void SendMessageToRunner(string descriptor, params object[] args)
            {
                _runner.PushMessage(descriptor, args);
            }
        }


        // connection class 
        private class RunnerConnection<T> : Java.Lang.Object, IServiceConnection where T : Core.BackgroundRunners.BaseBackgroundRunner
        {
            public RunnerBinder<T> Binder { get; private set; }

            public RunnerConnection(RunnerBinder<T> binder)
            {
                if (binder != null)
                {
                    Binder = binder;
                }
            }

            public void OnServiceConnected(ComponentName name, IBinder service)
            {
                RunnerBinder<T> serviceBinder = service as RunnerBinder<T>;

                if (serviceBinder != null)
                {
                    Binder = serviceBinder;
                    Binder.IsBound = true;
                    Binder.Service.StartRunner();
                }
            }

            public void OnServiceDisconnected(ComponentName name)
            {
                Binder.IsBound = false;
            }
        }



        // main class
        RunnerConnection<T> _runnerConnection;

        public void StartService()
        {
            _runnerConnection = new RunnerConnection<T>(null);

            new Task(() => {
             Android.App.Application.Context.StartService(
                new Intent(Android.App.Application.Context, typeof(RunnerService<T>)));

             Intent serviceIntent =
                new Intent(Android.App.Application.Context, typeof(RunnerService<T>));

             Android.App.Application.Context.BindService(
                serviceIntent, _runnerConnection, Bind.AutoCreate);
            }).Start();
        }


        public void StopService()
        {
            if (_runnerConnection != null)
                Android.App.Application.Context.UnbindService(_runnerConnection);
        }


        public object GetRunnerProperty(string name)
        {
            if (_runnerConnection.Binder != null)
            {
                return _runnerConnection.Binder.Service.GetRunnerProperty(name);
            }
            else {
                return null;
            }
        }


        public void SetRunnerProperty(string name, object value)
        {
            if (_runnerConnection.Binder != null)
            {
                _runnerConnection.Binder.Service.SetRunnerProperty(name, value);
            }
        }


        public void SendMessage(string descriptor, params object[] args)
        {
            if (_runnerConnection.Binder != null)
            {
                _runnerConnection.Binder.Service.SendMessageToRunner(descriptor, args);
            }
        }
    }

}