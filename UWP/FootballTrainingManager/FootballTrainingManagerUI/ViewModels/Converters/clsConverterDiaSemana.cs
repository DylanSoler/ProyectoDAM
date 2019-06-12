using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization;
using Windows.UI.Xaml.Data;

namespace FootballTrainingManagerUI.ViewModels.Converters
{
    public class clsConverterDiaSemana : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String dia = "";

            if (ApplicationLanguages.PrimaryLanguageOverride.Equals("en"))
            {
                switch ((int)value)
                {
                    case 1: dia = "Monday"; break;
                    case 2: dia = "Tuesday"; break;
                    case 3: dia = "Wednesday"; break;
                    case 4: dia = "Thursday"; break;
                    case 5: dia = "Friday"; break;
                    case 6: dia = "Saturday"; break;
                    case 7: dia = "Sunday"; break;
                }
            } else {
                switch ((int)value)
                {
                    case 1: dia = "Lunes"; break;
                    case 2: dia = "Martes"; break;
                    case 3: dia = "Miércoles"; break;
                    case 4: dia = "Jueves"; break;
                    case 5: dia = "Viernes"; break;
                    case 6: dia = "Sábado"; break;
                    case 7: dia = "Domingo"; break;
                }
            }
            return dia;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
