using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmMainPage:clsVMBase
    {
        #region Propiedades privadas
        private String _imagenPerfil;
        private clsManager _manager;
        private int _edad;
        private bool _formReadOnly;
        private String _datePickerVisibility;
        private String _edadVisibility;
        private DelegateCommand _guardarCommand;
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
                App.oAppManager = _manager;
                _edad = calcularEdad(manager.fechaNacimiento.Year)
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
                    _guardarCommand.RaiseCanExecuteChanged();
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
        
        public DelegateCommand guardarCommand
        {
            get
            {
                _guardarCommand = new DelegateCommand(guardarCommand_Executed, guardarCommand_CanExecuted);
                return _guardarCommand;
            }
        }
        #endregion

        #region Constructor
        public clsVmMainPage() {
            _imagenPerfil = App.oAppManager.fotoPerfil;
            _edad = calcularEdad(manager.fechaNacimiento.Year);
            _manager = App.oAppManager;
            _datePickerVisibility = Collapsed;
            _formReadOnly = true;
            _edadVisibility = true;
        }
        #endregion
        
        #region Commands
        private bool guardarCommand_CanExecuted()
        {
            bool sePuedeGuardar = false;

            if (!_formReadOnly && manager.nombre!=null && manager.apellidos!=null && manager.correo!=null)
            {
                sePuedeGuardar = true;
            }

            return sePuedeGuardar;
        }
        
        private async void guardarCommand_Executed()
        {
            /*int filasAfectadas;
            clsManejadoraPersonasBL manejadora = new clsManejadoraPersonasBL();
            ContentDialog confirmadoCorrectamente = new ContentDialog();

            try
            {
                if (_esInsertar == false)
                {
                    filasAfectadas = await manejadora.actualizarPersonaBL(personaSeleccionada);
                    if (filasAfectadas == 1)
                    {
                        actualizarListadoCommand_Executed();

                        confirmadoCorrectamente.Title = "Guardado";
                        confirmadoCorrectamente.Content = "Se ha guardado correctamente";
                        confirmadoCorrectamente.PrimaryButtonText = "Aceptar";
                        ContentDialogResult resultado = await confirmadoCorrectamente.ShowAsync();
                    }
                }
                else
                {
                    filasAfectadas = await manejadora.insertarPersonaBL(personaSeleccionada);
                    if (filasAfectadas == 1)
                    {
                        actualizarListadoCommand_Executed();
                        personaSeleccionada = null;
                        personaSeleccionada = new clsPersona();

                        confirmadoCorrectamente.Title = "Guardado";
                        confirmadoCorrectamente.Content = "Se ha insertado correctamente";
                        confirmadoCorrectamente.PrimaryButtonText = "Aceptar";
                        ContentDialogResult resultado = await confirmadoCorrectamente.ShowAsync();
                    }
                }
            }
            catch (Exception e)
            {
                //TODO lanzar dialogo con error(message dialog)
            }*/
        }
        #endregion
        
        #region Otros métodos
        private int calcularEdad(DateTime fechaNac) {
            age = (DateTime.Now.Year)-(fechaNac.Year);
            return age;
        }
        #endregion
    }
}
