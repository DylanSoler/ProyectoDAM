using FootballTrainingManagerDAL.Listados;
using FootballTrainingManagerDAL.Manejadoras;
using FootballTrainingManagerEntidades.Persistencia;
using FootballTrainingManagerUI.Views;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace FootballTrainingManagerUI
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void registrarClick(object sender, RoutedEventArgs e)
        {

        }

        private void recuperarPasswClick(object sender, RoutedEventArgs e)
        {

        }

        private async void btnEntrarClick(object sender, RoutedEventArgs e)
        {
            clsManejadoraManager manejadora = new clsManejadoraManager();
            clsManager mng = new clsManager();
            //List<clsTactica> tacts = new List<clsTactica>();
            //clsListadoTacticas listados = new clsListadoTacticas();

            /*String formato = "^[^@]+@[^@]+\\.[a-zA-Z]{2,}$";

            String correo = txbCorreo.Text;
            String psw = pwbPassword.Password;

            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
            String errorFormatResw = resourceLoader.GetString("strErrorLoginFormat");
            String errorLoginResw = resourceLoader.GetString("strErrorLogin");

            if (!String.IsNullOrEmpty(correo) && Regex.IsMatch(correo, formato) && !String.IsNullOrEmpty(psw))
            {
                this.txbErrorLogin.Text = "";
                clsManager mng = new clsManager();
                mng = await manejadora.obtenerManagerPorEmail(correo);

                if (mng != null) {
                    this.Frame.Navigate(typeof(MainPage));
                } else {
                    this.txbErrorLogin.Text = errorLoginResw;
                }
            }
            else
                this.txbErrorLogin.Text = errorFormatResw;*/

            mng = await manejadora.obtenerManagerPorIDDAL(5);
            //tacts = await listados.listadoCompletoTacticasDAL();
            var a = 1;
        }
    }
}
