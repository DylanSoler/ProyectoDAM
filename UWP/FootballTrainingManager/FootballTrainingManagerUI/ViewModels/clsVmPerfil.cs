using FootballTrainingManagerDAL.Manejadoras;
using FootballTrainingManagerEntidades.Persistencia;
using FootballTrainingManagerUI.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmPerfil : clsVMBase
    {
        #region Propiedades privadas
        private BitmapImage _imagenPerfil;
        private clsManager _manager;
        private int _edad;
        private bool _formReadOnly;
        private String _pswActual;
        private String _newPsw;
        private String _newRepPsw;
        private String _datePickerVisibility;
        private String _edadVisibility;
        private String _guardarVisibility;
        private String _editarVisibility;
        private String _passwActualVisibility;
        private String _formCambiarPswVisibility;
        private String _txbNotifyErrorPswVisibility;
        private String _txbNotifyErrorNewPswVisibility;
        private String _cancelarPswVisibility;
        private String _passwCheck;
        private DelegateCommand _guardarCommand;
        private DelegateCommand _editarCommand;
        private DelegateCommand _cancelarCommand;
        private DelegateCommand _cambiarPswLinkCommand;
        private DelegateCommand _guardarNewPswCommand;
        private DelegateCommand _cancelarNewPswCommand;
        private DelegateCommand _checkPasswordCommand;
        private DelegateCommand _editarFotoCommand;
        private DelegateCommand _cancelarFotoCommand;
        private Double _screenHeight;
        private Double _screenWidth;
        #endregion

        #region Propiedades publicas
        public BitmapImage imagenPerfil
        {
            get { return _imagenPerfil; }

            set { _imagenPerfil = value; }
        }

        public clsManager manager
        {
            get { return _manager; }

            set {
                _manager = value;
                NotifyPropertyChanged("manager");
                _edad = calcularEdad(_manager.fechaNacimiento.Year);
                NotifyPropertyChanged("edad");
            }
        }

        public int edad
        {
            get { return _edad; }

            set { _edad = value; }
        }

        public bool formReadOnly
        {
            get { return _formReadOnly; }

            set {
                _formReadOnly = value;
            }
        }

        public String pswActual
        {
            get { return _pswActual; }

            set { _pswActual = value;}
        }

        public String newRepPsw
        {
            get { return _newRepPsw; }

            set { _newRepPsw = value;
               _guardarNewPswCommand.RaiseCanExecuteChanged();
                }
        }

        public String newPsw
        {
            get { return _newPsw; }

            set { _newPsw = value; }
        }

        public String datePickerVisibility
        {
            get { return _datePickerVisibility; }

            set { _datePickerVisibility = value; }
        }

        public String edadVisibility
        {
            get { return _edadVisibility; }

            set { _edadVisibility = value; }
        }

        public String guardarVisibility
        {
            get { return _guardarVisibility; }

            set { _guardarVisibility = value; }
        }
        public String editarVisibility
        {
            get { return _editarVisibility; }

            set { _editarVisibility = value; }
        }

        public String passwActualVisibility
        {
            get { return _passwActualVisibility; }

            set { _passwActualVisibility=value; }
        }

        public String formCambiarPswVisibility
        {
            get { return _formCambiarPswVisibility; }

            set { _formCambiarPswVisibility = value; }
        }

        public String txbNotifyErrorPswVisibility
        {
            get { return _txbNotifyErrorPswVisibility; }

            set { _txbNotifyErrorPswVisibility = value; }
        }
        
        public String txbNotifyErrorNewPswVisibility
        {
            get { return _txbNotifyErrorNewPswVisibility; }

            set { _txbNotifyErrorNewPswVisibility = value; }
        }

        public String cancelarPswVisibility
        {
            get { return _cancelarPswVisibility; }

            set { _cancelarPswVisibility = value; }
        }

        public DelegateCommand guardarCommand
        {
            get
            {
                _guardarCommand = new DelegateCommand(guardarCommand_Executed, guardarCommand_CanExecuted);
                return _guardarCommand;
            }
        }

        public DelegateCommand editarCommand
        {
            get
            {
                _editarCommand = new DelegateCommand(editarCommand_Executed);
                return _editarCommand;
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

        public DelegateCommand cambiarPswLinkCommand
        {
            get
            {
                _cambiarPswLinkCommand = new DelegateCommand(cambiarPswLinkCommand_Executed);
                return _cambiarPswLinkCommand;
            }
        }
        
        public DelegateCommand guardarNewPswCommand
        {
            get
            {
                _guardarNewPswCommand = new DelegateCommand(guardarNewPswCommand_Executed, guardarNewPswCommand_CanExecuted);
                return _guardarNewPswCommand;
            }
        }

        public DelegateCommand cancelarNewPswCommand
        {
            get
            {
                _cancelarNewPswCommand = new DelegateCommand(cancelarNewPswCommand_Executed);
                return _cancelarNewPswCommand;
            }
        }
        
        public DelegateCommand checkPasswordCommand
        {
            get
            {
                _checkPasswordCommand = new DelegateCommand(checkPasswordCommand_Executed, checkPasswordCommand_CanExecuted);
                return _checkPasswordCommand;
            }
        }

        public DelegateCommand editarFotoCommand
        {
            get
            {
                _editarFotoCommand = new DelegateCommand(editarFotoCommand_Executed);
                return _editarFotoCommand;
            }
        }

        public DelegateCommand cancelarFotoCommand
        {
            get
            {
                _cancelarFotoCommand = new DelegateCommand(cancelarFotoCommand_Executed);
                return _cancelarFotoCommand;
            }
        }

        public double screenWidth
        {
            get { return _screenWidth; }

            set {
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

        #endregion

        #region Constructor
        public clsVmPerfil() {
            _manager = new clsManager(App.oAppManager.id, App.oAppManager.correo, App.oAppManager.passwordManager, App.oAppManager.nombre, App.oAppManager.apellidos, App.oAppManager.fotoPerfil, App.oAppManager.fechaNacimiento);
            _edad = calcularEdad(manager.fechaNacimiento.Year);
            _formReadOnly = true;
            _edadVisibility = "Visible";
            _editarVisibility = "Visible";
            _datePickerVisibility = "Collapsed";
            _guardarVisibility = "Collapsed";
            _passwActualVisibility = "Collapsed";
            _formCambiarPswVisibility = "Collapsed";
            _txbNotifyErrorPswVisibility = "Collapsed";
            _txbNotifyErrorNewPswVisibility = "Collapsed";
            _cancelarPswVisibility = "Collapsed";
            _pswActual = "";
        }
        #endregion
        
        #region Commands
        private bool guardarCommand_CanExecuted()
        {
            bool sePuedeGuardar = false;
            String formato = "^[^@]+@[^@]+\\.[a-zA-Z]{2,}$";

            if (!_formReadOnly && !String.IsNullOrEmpty(manager.nombre) && !String.IsNullOrEmpty(manager.apellidos) && !String.IsNullOrEmpty(manager.correo) && Regex.IsMatch(manager.correo, formato))
            {
                sePuedeGuardar = true;
            }

            return sePuedeGuardar;
            //return true;
        }
        
        private async void guardarCommand_Executed()
        {        
            bool ok;
            clsManejadoraManager manejadora = new clsManejadoraManager();

            try
            {
                ok = await manejadora.actualizarManagerDAL(manager);
                if (ok)
                {
                    _formReadOnly = true;
                    NotifyPropertyChanged("formReadOnly");
                    _edadVisibility = "Visible";
                    NotifyPropertyChanged("edadVisibility");
                    _editarVisibility = "Visible";
                    NotifyPropertyChanged("editarVisibility");
                    _datePickerVisibility = "Collapsed";
                    NotifyPropertyChanged("datePickerVisibility");
                    _guardarVisibility = "Collapsed";
                    NotifyPropertyChanged("guardarVisibility");
                    App.oAppManager = _manager;
                    _edad = calcularEdad(_manager.fechaNacimiento.Year);
                    NotifyPropertyChanged("edad");
                }
                else
                {
                    var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                    String errorGuardadoCorreo = resourceLoader.GetString("strErrorGuardadoCorreoExistente");

                    ContentDialog error = new ContentDialog();
                    error.Title = "Error";
                    error.Content = errorGuardadoCorreo;
                    error.PrimaryButtonText = "Ok";

                    ContentDialogResult resultado = await error.ShowAsync();

                    if (resultado == ContentDialogResult.Primary)
                        cancelarCommand_Executed();
                }
            }
            catch (Exception e)
            {
                var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                String errorGuardado = resourceLoader.GetString("strErrorGuardado");

                ContentDialog error = new ContentDialog();
                error.Title = "Error";
                error.Content = errorGuardado;
                error.PrimaryButtonText = "Ok";

                ContentDialogResult resultado = await error.ShowAsync();

                if (resultado == ContentDialogResult.Primary)
                    cancelarCommand_Executed();
            }
        }

        private void editarCommand_Executed()
        {
            _formReadOnly = false;
            NotifyPropertyChanged("formReadOnly");
            _edadVisibility = "Collapsed";
            NotifyPropertyChanged("edadVisibility");
            _editarVisibility = "Collapsed";
            NotifyPropertyChanged("editarVisibility");
            _datePickerVisibility = "Visible";
            NotifyPropertyChanged("datePickerVisibility");
            _guardarVisibility = "Visible";
            NotifyPropertyChanged("guardarVisibility");
            _guardarCommand.RaiseCanExecuteChanged();
        }

        private void cancelarCommand_Executed()
        {
            _formReadOnly = true;
            NotifyPropertyChanged("formReadOnly");
            _edadVisibility = "Visible";
            NotifyPropertyChanged("edadVisibility");
            _editarVisibility = "Visible";
            NotifyPropertyChanged("editarVisibility");
            _datePickerVisibility = "Collapsed";
            NotifyPropertyChanged("datePickerVisibility");
            _guardarVisibility = "Collapsed";
            NotifyPropertyChanged("guardarVisibility");
            _manager = new clsManager(App.oAppManager.id, App.oAppManager.correo, App.oAppManager.passwordManager, App.oAppManager.nombre, App.oAppManager.apellidos, App.oAppManager.fotoPerfil, App.oAppManager.fechaNacimiento);
            NotifyPropertyChanged("manager");
        }

        private void cambiarPswLinkCommand_Executed()
        {
            _passwActualVisibility = "Visible";
            NotifyPropertyChanged("passwActualVisibility");
            _cancelarPswVisibility = "Visible";
            NotifyPropertyChanged("cancelarPswVisibility");
            _checkPasswordCommand.RaiseCanExecuteChanged();
        }

        private void cancelarNewPswCommand_Executed()
        {
            _passwActualVisibility = "Collapsed";
            NotifyPropertyChanged("passwActualVisibility");
            _cancelarPswVisibility = "Collapsed";
            NotifyPropertyChanged("cancelarPswVisibility");
            _formCambiarPswVisibility = "Collapsed";
            NotifyPropertyChanged("formCambiarPswVisibility");
            _passwCheck = "";
            NotifyPropertyChanged("passwCheck");
            _pswActual = "";
            NotifyPropertyChanged("pswActual");
            _newPsw = "";
            NotifyPropertyChanged("newPsw");
            _newRepPsw = "";
            NotifyPropertyChanged("newRepPsw");
        }

        private void checkPasswordCommand_Executed()
        {
            clsManejadoraManager manejadora = new clsManejadoraManager();

            if (comprobarPassword(pswActual, _manager.passwordManager))
            {
                _formCambiarPswVisibility = "Visible";
                NotifyPropertyChanged("formCambiarPswVisibility");
                _passwActualVisibility = "Collapsed";
                NotifyPropertyChanged("passwActualVisibility");

                if (_txbNotifyErrorPswVisibility.Equals("Visible"))
                {
                    _txbNotifyErrorPswVisibility = "Collapsed";
                    NotifyPropertyChanged("txbNotifyErrorPswVisibility");
                }
            }
            else
            {
                _txbNotifyErrorPswVisibility = "Visible";
                NotifyPropertyChanged("txbNotifyErrorPswVisibility");
            }
        }

        private bool checkPasswordCommand_CanExecuted()
        {
            bool comprobar = false;

            if (_passwActualVisibility.Equals("Visible"))
                comprobar=true;

            return comprobar;
        }

        private bool guardarNewPswCommand_CanExecuted()
        {
            bool sePuedeGuardar = false;

            if (_formCambiarPswVisibility.Equals("Visible") && !String.IsNullOrEmpty(_newPsw) && !String.IsNullOrEmpty(_newRepPsw))
            {
                sePuedeGuardar = true;
            }

            return sePuedeGuardar;
        }

        private async void guardarNewPswCommand_Executed()
        {
            bool ok = false;
            clsManejadoraManager manejadora = new clsManejadoraManager();

            if (_newPsw.Equals(_newRepPsw))
            {
                if (_txbNotifyErrorNewPswVisibility == "Visible")
                {
                    _txbNotifyErrorNewPswVisibility = "Collapsed";
                    NotifyPropertyChanged("txbNotifyErrorNewPswVisibility");
                }

                try
                {
                    ok = await manejadora.actualizarPasswordManagerDAL(_manager.id, _passwCheck);
                    if (ok)
                    {
                        App.oAppManager.passwordManager = _passwCheck;
                        _manager.passwordManager = _passwCheck;
                        //Lanzar content dialog bueno
                        var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                        String success = resourceLoader.GetString("strNotificarOkCambPsw");

                        ContentDialog todoOk = new ContentDialog();
                        todoOk.Title = "";
                        todoOk.Content = success;
                        todoOk.PrimaryButtonText = "Ok";

                        ContentDialogResult resultado = await todoOk.ShowAsync();
                    }
                }
                catch (Exception e)
                {
                    var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                    String errorGuardado = resourceLoader.GetString("strErrorGuardado");

                    ContentDialog error = new ContentDialog();
                    error.Title = "Error";
                    error.Content = errorGuardado;
                    error.PrimaryButtonText = "Ok";

                    ContentDialogResult resultado = await error.ShowAsync();

                    if (resultado == ContentDialogResult.Primary)
                        cancelarNewPswCommand_Executed();
                }

                _cancelarPswVisibility = "Collapsed";
                NotifyPropertyChanged("cancelarPswVisibility");
                _formCambiarPswVisibility = "Collapsed";
                NotifyPropertyChanged("formCambiarPswVisibility");
                _passwCheck = "";
                NotifyPropertyChanged("passwCheck");
                _pswActual = "";
                NotifyPropertyChanged("pswActual");
                _newPsw = "";
                NotifyPropertyChanged("newPsw");
                _newRepPsw = "";
                NotifyPropertyChanged("newRepPsw");
            }
            else {
                _txbNotifyErrorNewPswVisibility = "Visible";
                NotifyPropertyChanged("txbNotifyErrorNewPswVisibility");
            }
        }

        private async void editarFotoCommand_Executed()
        {
            //Carpeta donde se guarda la imagen inicialmente dado que Assets es 
            //de solo lectura y no permite crear archivos en ella directamente
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            //Instanciamos selector de archivosm, personalizando las caracteristicas
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            //Obtenemos la foto
            StorageFile foto = await picker.PickSingleFileAsync();

            //Si no es nula y su tipo es correcto
            if (foto != null && (foto.ContentType!= "image/jpeg" || foto.ContentType != "image/png" || foto.ContentType != "image/jpg")) {
                try
                {
                    //Obtenemos softwareBitmap
                    SoftwareBitmap softwareBitmap;

                    IRandomAccessStream stream = await foto.OpenAsync(FileAccessMode.Read);

                    //Creamos el decodificador del stream
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);

                    //Obtenemos la representación SoftwareBitmap del archivo
                    softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                    
                    //Guardamos en el almacén de datos local de la aplicación
                    StorageFile fileSave = await storageFolder.CreateFileAsync(foto.Name, CreationCollisionOption.ReplaceExisting);
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(Windows.Graphics.Imaging.BitmapEncoder.JpegEncoderId, await fileSave.OpenAsync(FileAccessMode.ReadWrite));
                    encoder.SetSoftwareBitmap(softwareBitmap);
                    await encoder.FlushAsync();

                    //Movemos a Assets
                    StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                    StorageFolder assetsFolder = await appInstalledFolder.GetFolderAsync("Assets");

                    await fileSave.MoveAsync(assetsFolder, $"perfil{manager.id}.jpg", NameCollisionOption.ReplaceExisting);

                    //Establecemos la foto perfil
                    _manager.fotoPerfil = $"ms-appx:///Assets/perfil{manager.id}.jpg";
                    App.oAppManager.fotoPerfil = $"ms-appx:///Assets/perfil{manager.id}.jpg";
                    NotifyPropertyChanged("manager");

                    //Actualizar API
                    try {
                        clsManejadoraManager manejadora = new clsManejadoraManager();
                        bool ok = await manejadora.actualizarManagerDAL(_manager);
                    } catch (Exception e) {
                        //TODO
                    }
                }
                catch(Exception ex) {
                    //Establecemos foto perfil por defecto
                    manager.fotoPerfil = "ms-appx:///Assets/avatar.png";
                    App.oAppManager.fotoPerfil = "ms-appx:///Assets/avatar.png";
                    NotifyPropertyChanged("manager");
                }
            }
        }

        private async void cancelarFotoCommand_Executed()
        {
            //Si la foto de perfil es distinta a la foto por defecto
            if (!_manager.fotoPerfil.Equals("ms-appx:///Assets/avatar.png"))
            {
                //Se establece la foto perfil por defecto
                manager.fotoPerfil = "ms-appx:///Assets/avatar.png";
                App.oAppManager.fotoPerfil = "ms-appx:///Assets/avatar.png";
                NotifyPropertyChanged("manager");
                //Se actualiza la API
                try
                {
                    clsManejadoraManager manejadora = new clsManejadoraManager();
                    bool ok = await manejadora.actualizarManagerDAL(_manager);
                }
                catch (Exception e)
                {
                    //TODO
                }
            }
        }

        #endregion

        #region Otros métodos
        private int calcularEdad(int anioNac) {
            int age = (DateTime.Now.Year)-(anioNac);
            return age;
        }

        private Boolean comprobarPassword(String passwordToCheck, String correctPassword)
        {

            Boolean ret = false;

            SHA256 mySHA256 = SHA256.Create();
            byte[] passwToCheckHash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(passwordToCheck));

            _passwCheck = Convert.ToBase64String(passwToCheckHash);

            if (_passwCheck.Equals(correctPassword))
                ret = true;

            return ret;
        }

        private static async Task<BitmapImage> LoadImage(StorageFile file)
        {
            BitmapImage bitmapImage = new BitmapImage();
            FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);

            bitmapImage.SetSource(stream);

            return bitmapImage;

        }
        #endregion

    }
}
