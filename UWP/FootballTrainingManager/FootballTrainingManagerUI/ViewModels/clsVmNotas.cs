using FootballTrainingManagerDAL.Listados;
using FootballTrainingManagerDAL.Manejadoras;
using FootballTrainingManagerEntidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmNotas : clsVMBase
    {

        #region Propiedades privadas
        private NotifyTaskCompletion<List<clsNota>> _listadoNotasAsincrono;
        private clsNota _notaSeleccionada;
        private bool _esInsertar;
        private Double _screenHeight;
        private Double _screenWidth;
        private String _stkBtnNotaSeleccionadaVisibility;
        private String _notaVisibility;
        private String _notaEditableVisibility;
        private DelegateCommand _insertarNotaCommand;
        private DelegateCommand _eliminarListaCommand;
        private DelegateCommand _guardarNotaCommand;
        private DelegateCommand _editarNotaCommand;
        private DelegateCommand _cancelarCommand;
        private DelegateCommand _eliminarNotaCommand;
        private DelegateCommand _deseleccionarNotaCommand;
        #endregion

        #region Propiedades publicas
        public NotifyTaskCompletion<List<clsNota>> listadoNotasAsincrono
        {
            get { return _listadoNotasAsincrono; }
        }
        
        public clsNota notaSeleccionada
        {
            get { return _notaSeleccionada; }

            set {
                  _notaSeleccionada = value;
                  NotifyPropertyChanged("notaSeleccionada");
                  _stkBtnNotaSeleccionadaVisibility = "Visible";
                  NotifyPropertyChanged("stkBtnNotaSeleccionadaVisibility");
                  _notaVisibility = "Visible";
                  NotifyPropertyChanged("notaVisibility");
                  _editarNotaCommand.RaiseCanExecuteChanged();
                  _eliminarNotaCommand.RaiseCanExecuteChanged();
                  _deseleccionarNotaCommand.RaiseCanExecuteChanged();
                  //Para volver a deshabilitarlo en el caso de que se pulsara en el listado mientras se editaba otra nota
                  _guardarNotaCommand.RaiseCanExecuteChanged();
                }
        }


        public String stkBtnNotaSeleccionadaVisibility
        {
            get { return _stkBtnNotaSeleccionadaVisibility; }

            set { _stkBtnNotaSeleccionadaVisibility = value; }
        }

        public String notaVisibility
        {
            get { return _notaVisibility; }

            set { _notaVisibility = value; }
        }

        public String notaEditableVisibility
        {
            get { return _notaEditableVisibility; }

            set { _notaEditableVisibility = value; }
        }

        public DelegateCommand insertarNotaCommand
        {
            get
            {
                _insertarNotaCommand = new DelegateCommand(insertarNotaCommand_Executed);
                return _insertarNotaCommand;
            }
        }

        public DelegateCommand eliminarListaCommand
        {
            get
            {
                _eliminarListaCommand = new DelegateCommand(eliminarListaCommand_Executed);
                return _eliminarListaCommand;
            }
        }

        public DelegateCommand guardarNotaCommand
        {
            get
            {
                _guardarNotaCommand = new DelegateCommand(guardarNotaCommand_Executed, guardarNotaCommand_CanExecuted);
                return _guardarNotaCommand;
            }
        }
        
        public DelegateCommand editarNotaCommand
        {
            get
            {
                _editarNotaCommand = new DelegateCommand(editarNotaCommand_Executed, editarNotaCommand_CanExecuted);
                return _editarNotaCommand;
            }
        }
        
        public DelegateCommand cancelarCommand
        {
            get
            {
                _cancelarCommand = new DelegateCommand(cancelarCommand_Executed, cancelarCommand_CanExecuted);
                return _cancelarCommand;
            }
        }

        public DelegateCommand eliminarNotaCommand
        {
            get
            {
                _eliminarNotaCommand = new DelegateCommand(eliminarNotaCommand_Executed, eliminarNotaCommand_CanExecuted);
                return _eliminarNotaCommand;
            }
        }
        public DelegateCommand deseleccionarNotaCommand
        {
            get
            {
                _deseleccionarNotaCommand = new DelegateCommand(deseleccionarNotaCommand_Executed, deseleccionarNotaCommand_CanExecuted);
                return _deseleccionarNotaCommand;
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

        #endregion

        #region Constructor
        public clsVmNotas()
        {
            clsListadoNotas gest = new clsListadoNotas();
            _listadoNotasAsincrono = new NotifyTaskCompletion<List<clsNota>>(gest.listadoCompletoNotasDAL(App.oAppManager.id));

            _esInsertar = false;
            _stkBtnNotaSeleccionadaVisibility = "Collapsed";
            _notaEditableVisibility = "Collapsed";
            _notaVisibility = "Collapsed";
        }
        #endregion

        #region Commands
        private async void eliminarListaCommand_Executed()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
            String confBorradoTituloNotas = resourceLoader.GetString("strConfBorradoTituloNotas");
            String confBorradoTextoNotas = resourceLoader.GetString("strConfBorradoTextoNotas");
            String contentDialogNotasCancelar = resourceLoader.GetString("strContentDialogNotasCancelar");

            ContentDialog confirmar = new ContentDialog();
            confirmar.Title = confBorradoTituloNotas;
            confirmar.Content = confBorradoTextoNotas;
            confirmar.PrimaryButtonText = "Ok";
            confirmar.SecondaryButtonText = contentDialogNotasCancelar;

            ContentDialogResult resultado = await confirmar.ShowAsync();

            if (resultado == ContentDialogResult.Primary)
            {
                clsManejadoraNota manej = new clsManejadoraNota();
                bool ok = await manej.eliminarTodasLasNotasDAL(App.oAppManager.id);

                if (ok) {
                    clsListadoNotas gest = new clsListadoNotas();
                    _listadoNotasAsincrono = new NotifyTaskCompletion<List<clsNota>>(gest.listadoCompletoNotasDAL(App.oAppManager.id));
                    NotifyPropertyChanged("listadoNotasAsincrono");
                }
            }

        }

        private bool guardarNotaCommand_CanExecuted()
        {
            bool ret = false;

            if (_stkBtnNotaSeleccionadaVisibility.Equals("Visible") && _notaEditableVisibility.Equals("Visible"))
                ret = true;

            return ret;
        }

        private async void guardarNotaCommand_Executed()
        {
            if(_notaSeleccionada.titulo==null)
                _notaSeleccionada.titulo = "";

            if(_notaSeleccionada.texto == null)
                _notaSeleccionada.texto = "";

            if (_esInsertar)
            {
                clsManejadoraNota manejadora = new clsManejadoraNota();
                bool ret = await manejadora.insertarNotaDAL(_notaSeleccionada);

                if (ret)
                {
                    clsListadoNotas gest = new clsListadoNotas();
                    _listadoNotasAsincrono = new NotifyTaskCompletion<List<clsNota>>(gest.listadoCompletoNotasDAL(App.oAppManager.id));
                    NotifyPropertyChanged("listadoNotasAsincrono");
                    _stkBtnNotaSeleccionadaVisibility = "Collapsed";
                    NotifyPropertyChanged("stkBtnNotaSeleccionadaVisibility");
                    _notaEditableVisibility = "Collapsed";
                    NotifyPropertyChanged("notaEditableVisibility");
                    _notaVisibility = "Collapsed";
                    NotifyPropertyChanged("notaVisibility");
                    _esInsertar = false;
                }
                else
                {
                    var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                    String errorGuardado = resourceLoader.GetString("strErrorGuardarNota");

                    ContentDialog error = new ContentDialog();
                    error.Title = "Error";
                    error.Content = errorGuardado;
                    error.PrimaryButtonText = "Ok";

                    ContentDialogResult resultado = await error.ShowAsync();

                    if (resultado == ContentDialogResult.Primary)
                        cancelarCommand_Executed();
                }
            }
            else
            {
                _notaSeleccionada.fechaCreacion = DateTime.Now;

                clsManejadoraNota manejadora = new clsManejadoraNota();
                bool ret = await manejadora.actualizarNotaDAL(_notaSeleccionada);

                if (ret)
                {
                    clsListadoNotas gest = new clsListadoNotas();
                    _listadoNotasAsincrono = new NotifyTaskCompletion<List<clsNota>>(gest.listadoCompletoNotasDAL(App.oAppManager.id));
                    NotifyPropertyChanged("listadoNotasAsincrono");
                    _stkBtnNotaSeleccionadaVisibility = "Collapsed";
                    NotifyPropertyChanged("stkBtnNotaSeleccionadaVisibility");
                    _notaEditableVisibility = "Collapsed";
                    NotifyPropertyChanged("notaEditableVisibility");
                    _notaVisibility = "Collapsed";
                    NotifyPropertyChanged("notaVisibility");
                }
                else
                {
                    var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                    String errorGuardado = resourceLoader.GetString("strErrorGuardarNota");

                    ContentDialog error = new ContentDialog();
                    error.Title = "Error";
                    error.Content = errorGuardado;
                    error.PrimaryButtonText = "Ok";

                    ContentDialogResult resultado = await error.ShowAsync();

                    if (resultado == ContentDialogResult.Primary)
                        cancelarCommand_Executed();
                }
            }
        }

        private bool editarNotaCommand_CanExecuted()
        {
            bool ret = false;
            if (_stkBtnNotaSeleccionadaVisibility.Equals("Visible") && _notaVisibility.Equals("Visible") && _esInsertar==false)
                ret = true;

            return ret;
        }

        private void editarNotaCommand_Executed()
        {
            _notaEditableVisibility = "Visible";
            NotifyPropertyChanged("notaEditableVisibility");
            _notaVisibility = "Collapsed";
            NotifyPropertyChanged("notaVisibility");
            _guardarNotaCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();
            _deseleccionarNotaCommand.RaiseCanExecuteChanged();
        }

        private void insertarNotaCommand_Executed()
        {
            _notaSeleccionada = new clsNota();
            _notaSeleccionada.fechaCreacion = DateTime.Now;
            _notaSeleccionada.idManager = App.oAppManager.id;
            NotifyPropertyChanged("notaSeleccionada");
            _stkBtnNotaSeleccionadaVisibility = "Visible";
            NotifyPropertyChanged("stkBtnNotaSeleccionadaVisibility");
            _notaEditableVisibility = "Visible";
            NotifyPropertyChanged("notaEditableVisibility");
            _esInsertar = true;
            _guardarNotaCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();

            if (_notaVisibility.Equals("Visible"))
            {
                _notaVisibility = "Collapsed";
                NotifyPropertyChanged("notaVisibility");
            }
        }

        private bool eliminarNotaCommand_CanExecuted()
        {
            bool ret = false;
            if (_stkBtnNotaSeleccionadaVisibility.Equals("Visible") && _notaVisibility.Equals("Visible") && _esInsertar == false)
                ret = true;

            return ret;
        }

        private async void eliminarNotaCommand_Executed()
        {
            clsManejadoraNota manejadora = new clsManejadoraNota();
            bool ret = await manejadora.eliminarNotaDAL(_notaSeleccionada.idManager, _notaSeleccionada.idNota);

            if (ret)
            {
                clsListadoNotas gest = new clsListadoNotas();
                _listadoNotasAsincrono = new NotifyTaskCompletion<List<clsNota>>(gest.listadoCompletoNotasDAL(App.oAppManager.id));
                NotifyPropertyChanged("listadoNotasAsincrono");
                _stkBtnNotaSeleccionadaVisibility = "Collapsed";
                NotifyPropertyChanged("stkBtnNotaSeleccionadaVisibility");
                _notaEditableVisibility = "Collapsed";
                NotifyPropertyChanged("notaEditableVisibility");
                _notaVisibility = "Collapsed";
                NotifyPropertyChanged("notaVisibility");
            }
            else
            {
                var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                String errorEliminar = resourceLoader.GetString("strErrorEliminarNota");

                ContentDialog error = new ContentDialog();
                error.Title = "Error";
                error.Content = errorEliminar;
                error.PrimaryButtonText = "Ok";

                ContentDialogResult resultado = await error.ShowAsync();

                if (resultado == ContentDialogResult.Primary)
                    cancelarCommand_Executed();
            }
        }

        private bool cancelarCommand_CanExecuted()
        {
            bool ret = false;

            if (_stkBtnNotaSeleccionadaVisibility.Equals("Visible") && _notaEditableVisibility.Equals("Visible"))
                ret = true;

            return ret;
        }

        private void cancelarCommand_Executed()
        {
            if (_esInsertar)
                _esInsertar = false;
            else
                _editarNotaCommand.RaiseCanExecuteChanged();

            _stkBtnNotaSeleccionadaVisibility = "Collapsed";
            NotifyPropertyChanged("stkBtnNotaSeleccionadaVisibility");
            _notaEditableVisibility = "Collapsed";
            NotifyPropertyChanged("notaEditableVisibility");
            _guardarNotaCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();
            _eliminarNotaCommand.RaiseCanExecuteChanged();
        }

        private bool deseleccionarNotaCommand_CanExecuted()
        {
            bool ret = false;

            if (_stkBtnNotaSeleccionadaVisibility.Equals("Visible") && _notaVisibility.Equals("Visible"))
                ret = true;

            return ret;
        }

        private void deseleccionarNotaCommand_Executed()
        {
            _stkBtnNotaSeleccionadaVisibility = "Collapsed";
            NotifyPropertyChanged("stkBtnNotaSeleccionadaVisibility");
            _notaVisibility = "Collapsed";
            NotifyPropertyChanged("notaVisibility");
        }

        #endregion

        #region Otros métodos

        #endregion
    }
}
