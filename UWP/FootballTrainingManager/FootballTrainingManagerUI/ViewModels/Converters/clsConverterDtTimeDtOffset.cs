﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FootballTrainingManagerUI.ViewModels.Converters
{
    public class clsConverterDtTimeDtOffset:IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                return new DateTimeOffset(((DateTime)value).ToUniversalTime());
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                return ((DateTimeOffset)value).DateTime;
            }

    }
}
