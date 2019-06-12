using FootballTrainingManagerDAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmAjustes : clsVMBase
    {

        #region Propiedades privadas
        private String _password;
        private DelegateCommand _linkEliminarCuentaCommand;
        private DelegateCommand _eliminarCuentaCommand;
        private DelegateCommand _cancelarCommand;
        private Double _screenHeight;
        private Double _screenWidth;
        private String _formPswVisibility;
        private String _txbNotifyErrorPswVisibility;
        #endregion

        #region Propiedades publicas
        public String password
        {
            get { return _password; }

            set { _password = value; }
        }

        public DelegateCommand linkEliminarCuentaCommand
        {
            get
            {
                _linkEliminarCuentaCommand = new DelegateCommand(linkEliminarCuentaCommand_Executed);
                return _linkEliminarCuentaCommand;
            }
        }

        public DelegateCommand eliminarCuentaCommand
        {
            get
            {
                _eliminarCuentaCommand = new DelegateCommand(eliminarCuentaCommand_Executed);
                return _eliminarCuentaCommand;
            }
        }

        public DelegateCommand cancelarCommand
        {
            get
            {
                _cancelarCommand = new DelegateCommand(cancelarCommand_Executed);
                return _cancelarCommand;
            }
        }

        public double screenWidth
        {
            get { return _screenWidth; }

            set
            {
                _screenWidth = value;
                NotifyPropertyChanged("screenWidth");
            }
        }

        public double screenHeight
        {
            get { return _screenHeight; }

            set
            {
                _screenHeight = value;
                NotifyPropertyChanged("screenHeight");
            }
        }
       
        public String formPswVisibility
        {
            get { return _formPswVisibility; }

            set{ _formPswVisibility = value; }
        }

        public String txbNotifyErrorPswVisibility
        {
            get { return _txbNotifyErrorPswVisibility; }

            set { _txbNotifyErrorPswVisibility = value; }
        }
        #endregion

        #region Constructor
        public clsVmAjustes()
        {
            _formPswVisibility = "Collapsed";
            _txbNotifyErrorPswVisibility = "Collapsed";
        }
        #endregion

        #region Commands
        private void linkEliminarCuentaCommand_Executed()
        {
            _formPswVisibility = "Visible";
            NotifyPropertyChanged("formPswVisibility");
        }

        private async void eliminarCuentaCommand_Executed()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
            String strBorrarCuenta = resourceLoader.GetString("strBorrarCuenta");
            String strAjustesContentDialog = resourceLoader.GetString("strAjustesContentDialog");
            String strAjustesOkDialog = resourceLoader.GetString("strAjustesOkDialog");
            String strAjustesCancelDialog = resourceLoader.GetString("strAjustesCancelDialog");

            clsManejadoraManager manejadora = new clsManejadoraManager();

            if (!String.IsNullOrEmpty(_password) && comprobarPassword(_password, App.oAppManager.passwordManager))
            {
                if (_txbNotifyErrorPswVisibility.Equals("Visible")){
                    _txbNotifyErrorPswVisibility = "Collapsed";
                    NotifyPropertyChanged("txbNotifyErrorPswVisibility");
                }

                ContentDialog confirmarEliminar = new ContentDialog();

                confirmarEliminar.Title = strBorrarCuenta;
                confirmarEliminar.Content = strAjustesContentDialog;
                confirmarEliminar.PrimaryButtonText = strAjustesCancelDialog;
                confirmarEliminar.SecondaryButtonText = strAjustesOkDialog;

                ContentDialogResult resultado = await confirmarEliminar.ShowAsync();
                if(resultado == ContentDialogResult.Secondary)
                {

                    try {
                        manejadora.eliminarManagerDAL(App.oAppManager.id);

                        /*//Eliminar foto perfil
                        // Delete a file by using File class static method...
                        if (System.IO.File.Exists($"ms-appx:///Assets/perfil{App.oAppManager.id}.jpg"))
                        {
                            // Use a try block to catch IOExceptions, to
                            // handle the case of the file already being
                            // opened by another process.
                            try
                            {
                                System.IO.File.Delete($"ms-appx:///Assets/perfil{App.oAppManager.id}.jpg");
                            }
                            catch (System.IO.IOException e)
                            {
                                
                            }
                        }*/

                        Frame frame = Window.Current.Content as Frame;
                        frame.Navigate(typeof(Login));
                    } catch (Exception ex) {

                    }
                } else {
                    cancelarCommand_Executed();
                }

            }
            else
            {
                _txbNotifyErrorPswVisibility = "Visible";
                NotifyPropertyChanged("txbNotifyErrorPswVisibility");
            }
        }

        private void cancelarCommand_Executed()
        {
            _formPswVisibility = "Collapsed";
            NotifyPropertyChanged("formPswVisibility");
            _password = "";
            NotifyPropertyChanged("password");
        }
        #endregion

        #region Otros métodos
        private Boolean comprobarPassword(String passwordToCheck, String correctPassword)
        {

            Boolean ret = false;

            SHA256 mySHA256 = SHA256.Create();
            byte[] passwToCheckHash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(passwordToCheck));

            _password = Convert.ToBase64String(passwToCheckHash);

            if (_password.Equals(correctPassword))
                ret = true;

            return ret;
        }
        #endregion

    }
}
