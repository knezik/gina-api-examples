using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;


namespace ApiExamples.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public FirstViewModel(Services.IAllTestsService service)
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
}
