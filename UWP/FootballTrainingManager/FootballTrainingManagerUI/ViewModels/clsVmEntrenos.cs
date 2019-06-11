using FootballTrainingManagerDAL.Listados;
using FootballTrainingManagerDAL.Manejadoras;
using FootballTrainingManagerEntidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmEntrenos : clsVMBase
    {

        #region Propiedades privadas
        private NotifyTaskCompletion<List<clsEntreno>> _listadoEntrenos;
        private List<clsEntreno> _listadoEntrenosCopia;
        private Double _screenHeight;
        private Double _screenWidth;
        private String _entrenosSoloLecturaVisibility;
        private String _entrenosEditablesVisibility;
        private DelegateCommand _editarEntrenosCommand;
        private DelegateCommand _guardarEntrenosCommand;
        private DelegateCommand _cancelarCommand;
        #endregion

        #region Propiedades publicas
        public NotifyTaskCompletion<List<clsEntreno>> listadoEntrenos
        {
            get { return _listadoEntrenos; }
        }

        public List<clsEntreno> listadoEntrenosCopia
        {
            get { return _listadoEntrenosCopia; }

            set {
                _listadoEntrenosCopia = value;
                NotifyPropertyChanged("listadoEntrenosCopia");
                }
        }

        public String entrenosSoloLecturaVisibility
        {
            get { return _entrenosSoloLecturaVisibility; }

            set { _entrenosSoloLecturaVisibility = value; }
        }

        public String entrenosEditablesVisibility
        {
            get { return _entrenosEditablesVisibility; }

            set { _entrenosEditablesVisibility = value; }
        }

        public DelegateCommand editarEntrenosCommand
        {
            get
            {
                _editarEntrenosCommand = new DelegateCommand(editarEntrenosCommand_Executed);
                return _editarEntrenosCommand;
            }
        }

        public DelegateCommand guardarEntrenosCommand
        {
            get
            {
                _guardarEntrenosCommand = new DelegateCommand(guardarEntrenosCommand_Executed, guardarEntrenosCommand_CanExecuted);
                return _guardarEntrenosCommand;
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
        public clsVmEntrenos()
        {
            clsListadoEntrenos gest = new clsListadoEntrenos();
            _listadoEntrenos = new NotifyTaskCompletion<List<clsEntreno>>(gest.listadoCompletoEntrenosDAL(App.oAppManager.id));

            //_listadoEntrenosCopia = _listadoEntrenos.Result;

            _entrenosEditablesVisibility = "Collapsed";
            _entrenosSoloLecturaVisibility = "Visible";
        }
        #endregion

        #region Commands
        private void editarEntrenosCommand_Executed()
        {
            _listadoEntrenosCopia = _listadoEntrenos.Result;
            NotifyPropertyChanged("listadoEntrenosCopia");
            _entrenosEditablesVisibility = "Visible";
            NotifyPropertyChanged("entrenosEditablesVisibility");
            _entrenosSoloLecturaVisibility = "Collapsed";
            NotifyPropertyChanged("entrenosSoloLecturaVisibility");
            _guardarEntrenosCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();
        }

        private bool guardarEntrenosCommand_CanExecuted()
        {
            bool ret = false;

            if (_entrenosSoloLecturaVisibility.Equals("Collapsed") && _entrenosEditablesVisibility.Equals("Visible"))
                ret = true;

            return ret;
        }

        private void guardarEntrenosCommand_Executed()
        {
            clsManejadoraEntreno manejadora = new clsManejadoraEntreno();
            //manejadora.
        }

        private bool cancelarCommand_CanExecuted()
        {
            bool ret = false;

            if (_entrenosSoloLecturaVisibility.Equals("Collapsed") && _entrenosEditablesVisibility.Equals("Visible"))
                ret = true;

            return ret;
        }

        private void cancelarCommand_Executed()
        {
            _listadoEntrenosCopia = _listadoEntrenos.Result;
            NotifyPropertyChanged("listadoEntrenosCopia");
            _entrenosEditablesVisibility = "Collapsed";
            NotifyPropertyChanged("entrenosEditablesVisibility");
            _entrenosSoloLecturaVisibility = "Visible";
            NotifyPropertyChanged("entrenosSoloLecturaVisibility");
            _guardarEntrenosCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region Otros métodos

        #endregion

    }
}
