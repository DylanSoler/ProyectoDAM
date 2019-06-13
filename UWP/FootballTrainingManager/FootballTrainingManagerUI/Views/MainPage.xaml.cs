using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            perfil.IsSelected = true;
            frmPrincipal.Navigate(typeof(Perfil));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            spV.IsPaneOpen = !spV.IsPaneOpen;
        }

        private void LBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (perfil.IsSelected)
            {
                frmPrincipal.Navigate(typeof(Perfil));
            }
            else if (formTact.IsSelected)
            {
                frmPrincipal.Navigate(typeof(FormTactica));
            }
            else if (entreno.IsSelected)
            {
                frmPrincipal.Navigate(typeof(Entrenos));
            }
            else if (pizarra.IsSelected)
            {
                frmPrincipal.Navigate(typeof(Pizarra));
            }
            else if (notas.IsSelected)
            {
                frmPrincipal.Navigate(typeof(Notas));
            }
            else if (ajustes.IsSelected)
            {
                frmPrincipal.Navigate(typeof(Ajustes));
            }
            else
            {
                logout();
            }

        }

        private void logout() {
            App.oAppManager = null;
            this.Frame.Navigate(typeof(Login));
        }
    }
}
