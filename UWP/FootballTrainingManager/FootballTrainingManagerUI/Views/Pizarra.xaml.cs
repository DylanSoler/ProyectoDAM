using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Input.Inking;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace FootballTrainingManagerUI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Pizarra : Page
    {
        public Pizarra()
        {
            this.InitializeComponent();

            inkC.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Touch |
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            gridPizarraPrincipal.Height = bounds.Height * scaleFactor;
            gridPizarraPrincipal.Width = bounds.Width * scaleFactor;
        }

        /// <summary>
        /// Evento asociado al botón de guardar, guarda el canvas como una imagen
        /// en la ruta especificada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GuardarComoImagen_Click(object sender, RoutedEventArgs e)
        {
            if (inkC != null)
            {
                //Abrimos selector de archivos para seleccionar ruta y nombre del archivo a guardar
                var picker = new FileSavePicker();
                picker.FileTypeChoices.Add("JPEG Image", new string[] { ".jpg",".jpeg",".png" });
                StorageFile file = await picker.PickSaveFileAsync();
                //Una vez seleccionado/creado el archivo donde se va a guardar nuestro canvas
                if (file != null)
                {
                    //Usamos librería Win2D
                    CanvasDevice device = CanvasDevice.GetSharedDevice();
                    CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int)inkC.ActualWidth, (int)inkC.ActualHeight, 96);
                    //Configuramos el fondo verde e insertamos el dibujo realizado
                    using (var ds = renderTarget.CreateDrawingSession())
                    {
                        ds.Clear(Colors.LightGreen);
                        ds.DrawInk(inkC.InkPresenter.StrokeContainer.GetStrokes());
                    }
                    //Finalmente guardamos la imagen
                    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await renderTarget.SaveAsync(fileStream, CanvasBitmapFileFormat.Jpeg, 1f);
                    }
                }

            }
        }
    }
}
