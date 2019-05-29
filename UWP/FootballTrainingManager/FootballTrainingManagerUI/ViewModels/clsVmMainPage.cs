using FootballTrainingManagerDAL.Manejadoras;
using FootballTrainingManagerEntidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmMainPage : clsVMBase
    {
        #region Propiedades privadas
        private String _imagenPerfil;
        private clsManager _manager;
        private int _edad;
        private bool _formReadOnly;
        private String _datePickerVisibility;
        private String _edadVisibility;
        private String _guardarVisibility;
        private String _editarVisibility;
        private DelegateCommand _guardarCommand;
        private DelegateCommand _editarCommand;
        private DelegateCommand _cancelarCommand;
        #endregion

        #region Propiedades publicas
        public String imagenPerfil
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
                _edad = calcularEdad(manager.fechaNacimiento.Year);
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
        #endregion

        #region Constructor
        public clsVmMainPage() {
            _manager = new clsManager(App.oAppManager.id, App.oAppManager.correo, App.oAppManager.passwordManager, App.oAppManager.nombre, App.oAppManager.apellidos, App.oAppManager.fotoPerfil, App.oAppManager.fechaNacimiento);
            _imagenPerfil = App.oAppManager.fotoPerfil;
            _edad = calcularEdad(manager.fechaNacimiento.Year);
            _formReadOnly = true;
            _edadVisibility = "Visible";
            _editarVisibility = "Visible";
            _datePickerVisibility = "Collapsed";
            _guardarVisibility = "Collapsed";
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
        }
        
        private async void guardarCommand_Executed()
        {
            bool ok;
            clsManejadoraManager manejadora = new clsManejadoraManager();
            //ContentDialog confirmadoCorrectamente = new ContentDialog();

            try
            {
                ok = await manejadora.actualizarManagerDAL(manager);
                if (ok)
                {
                    //actualizarListadoCommand_Executed();
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
                    //confirmadoCorrectamente.Title = "Guardado";
                    //confirmadoCorrectamente.Content = "Se ha guardado correctamente";
                    //confirmadoCorrectamente.PrimaryButtonText = "Aceptar";
                    //ContentDialogResult resultado = await confirmadoCorrectamente.ShowAsync();
                }
            }
            catch (Exception e)
            {
                //TODO lanzar dialogo con error(message dialog)
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
            _manager = App.oAppManager;
            NotifyPropertyChanged("manager");
        }

        #endregion

        #region Otros métodos
        private int calcularEdad(int anioNac) {
            int age = (DateTime.Now.Year)-(anioNac);
            return age;
        }
        #endregion
    }
}
