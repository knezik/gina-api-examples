using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;


namespace ApiExamples.Core.ViewModels
{
    class PhotoViewModel : TestViewModel 
    {
        private readonly Services.IPhotoService _photoService;

        public PhotoViewModel(Services.IPhotoService photoService)
        {
            _photoService = photoService;
            _photoService.TakePhoto();
        }

        public ICommand TakePhotoCommand
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
