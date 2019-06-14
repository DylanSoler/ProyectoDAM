using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FootballTrainingManagerUI.ViewModels.Converters
{
    public class clsConverterRutaImagenFormTact : IValueConverter
    {
        //Dado un sistema (Ej. 4-2-3-1), se convierte al source de la imagen correspondiente de dicha tactica
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string sistema = (string)value;
            sistema = "ms-appx:///Assets/"+sistema+".png";

            return sistema;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
