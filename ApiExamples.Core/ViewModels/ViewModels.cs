using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using ApiExamples.Core.ViewModels.Helpers;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;
using System;

namespace ApiExamples.Core.ViewModels
{
    public class StripConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            return value.Replace((string)parameter, string.Empty);
        }
    }

    public class FirstViewModel
        : MvxViewModel
    {
        public FirstViewModel(IAllTestsService service)
        {
            Tests = service.All;
        }

        private IList<Type> _tests;
        public IList<Type> Tests
        {
            get { return _tests; }
            set { _tests = value; RaisePropertyChanged(() => Tests); }
        }

        public ICommand GotoTestCommand
        {
            get { return new MvxCommand<Type>(type => ShowViewModel(type)); }
        }
    }

    public abstract class TestViewModel
        : MvxViewModel
    {
        public ICommand NextCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        var all = Mvx.Resolve<IAllTestsService>();
                        var next = all.NextViewModelType(this);
                        if (next == null)
                            Close(this);
                        else
                            ShowViewModel(next);
                    });
            }
        }
    }

    public class BatteryViewModel
        : TestViewModel
    {
        public String State { get; set; }

        public BatteryViewModel()
        {
            State = 63 + "%";
        }
    }
}
