using FootballTrainingManagerDAL.Manejadoras;
using FootballTrainingManagerEntidades.Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace FootballTrainingManagerUI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Registro : Page
    {
        public Registro()
        {
            this.InitializeComponent();
        }

        private async void btnRegistrar(object sender, RoutedEventArgs e)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
            String strRegConfirmOk = resourceLoader.GetString("strRegConfirmOk");
            String strRegConfirmError = resourceLoader.GetString("strRegConfirmError");
            String strRegFormError = resourceLoader.GetString("strRegFormError");

            if (formCorrecto()){

                DateTime date = dpDate.Date.DateTime;

                SHA256 mySHA256 = SHA256.Create();
                byte[] psw = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(pwbPassword.Password));
                String password = Convert.ToBase64String(psw);

                clsManejadoraManager manejadora = new clsManejadoraManager();
                clsManejadoraEntreno manejEntreno = new clsManejadoraEntreno();
                clsManejadoraFormacionTactica manejFormTact = new clsManejadoraFormacionTactica();
                clsManager oMng = new clsManager(0, txbCorreo.Text, password, txbNombre.Text, txbApellidos.Text, "ms-appx:///Assets/avatar.png", date);

                bool ok = await manejadora.insertarManagerDAL(oMng);

                if (ok)
                {   
                    txbNotifyUser.Text = strRegConfirmOk;
                    txbNotifyUser.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                    System.Threading.Thread.Sleep(2000);
                    this.Frame.Navigate(typeof(Login));
                }
                else
                    txbNotifyUser.Text = strRegConfirmError;

            } else {
                txbNotifyUser.Text = strRegFormError;
            }

        }

        private bool formCorrecto() {

            bool ret = false;
            String formato = "^[^@]+@[^@]+\\.[a-zA-Z]{2,}$";

            if (!String.IsNullOrEmpty(txbNombre.Text) && !String.IsNullOrEmpty(txbApellidos.Text) && Regex.IsMatch(txbCorreo.Text, formato) 
                && dpDate.Date!=null && pwbPassword.Password!=null && pwbRepeatPassword!=null && pwbPassword.Password.Equals(pwbRepeatPassword.Password))
                ret = true;

            return ret;
        }

        private void btnVolverClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }

    }
}
