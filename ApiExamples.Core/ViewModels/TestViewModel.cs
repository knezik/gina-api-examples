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
    public abstract class TestViewModel : MvxViewModel
    {
        public ICommand NextCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    var all = Mvx.Resolve<Services.IAllTestsService>();
                    var next = all.NextViewModelType(this);
                    if (next == null)
                        Close(this);
                    else
                        ShowViewModel(next);
                });
            }
        }
    }
}
