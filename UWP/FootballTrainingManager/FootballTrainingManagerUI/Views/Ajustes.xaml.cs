﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
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
    public sealed partial class Ajustes : Page
    {
        public Ajustes()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Habilita los botones para cambiar de idioma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HlbCambiarIdioma_Click(object sender, RoutedEventArgs e)
        {
            if (spa.Visibility==Visibility.Collapsed && eng.Visibility==Visibility.Collapsed)
            {
                spa.Visibility = Visibility.Visible;
                eng.Visibility = Visibility.Visible;
            }
            else
            {
                spa.Visibility = Visibility.Collapsed;
                eng.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Cambia el idioma a ingles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Eng_Click(object sender, RoutedEventArgs e)
        {
            if (!ApplicationLanguages.PrimaryLanguageOverride.Equals("en"))
            {
                ApplicationLanguages.PrimaryLanguageOverride = "en";
                await Task.Delay(300);
                this.Frame.Navigate(typeof(Ajustes));
                spa.Visibility = Visibility.Collapsed;
                eng.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Cambia el idioma a castellano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Spa_Click(object sender, RoutedEventArgs e)
        {
            if (!ApplicationLanguages.PrimaryLanguageOverride.Equals("es"))
            {
                ApplicationLanguages.PrimaryLanguageOverride = "es";
                await Task.Delay(300);
                this.Frame.Navigate(typeof(Ajustes));
                spa.Visibility = Visibility.Collapsed;
                eng.Visibility = Visibility.Collapsed;
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            vmAjustes.screenHeight = bounds.Height * scaleFactor;
            vmAjustes.screenWidth = bounds.Width * scaleFactor;
        }

        
private void HlbAboutMe_Click(object sender, RoutedEventArgs e)
        {
            if (txbAboutMe.Visibility == Visibility.Collapsed)
                txbAboutMe.Visibility = Visibility.Visible;
            else
                txbAboutMe.Visibility = Visibility.Collapsed;
        }

    }
}
