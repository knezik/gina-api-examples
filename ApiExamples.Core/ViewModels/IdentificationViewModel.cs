using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;
 

namespace ApiExamples.Core.ViewModels
{
    public class IdentificationViewModel : TestViewModel
    {
        private readonly Services.IIdentificationService _identificationService;

        public string ID { get; set; }

        public IdentificationViewModel(Services.IIdentificationService identificationService)
        {
            _identificationService = identificationService;

            if (_identificationService == null) {
                ID = "unknown";
            } else {
                ID = _identificationService.GetDeviceId(); 
            }
        }
    }
}
