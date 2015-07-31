using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;


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
}
