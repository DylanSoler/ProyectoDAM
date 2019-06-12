using FootballTrainingManagerDAL.Manejadoras;
using FootballTrainingManagerEntidades.Complejas;
using FootballTrainingManagerEntidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmFormTactica : clsVMBase
    {

        #region Propiedades privadas
        private NotifyTaskCompletion<clsFormacionTactica> _formTacticaAsin;
        private List<clsTactica> _listadoTacticas;
        private bool _formReadOnly;
        private Double _screenHeight;
        private Double _screenWidth;
        private String _comboBoxSistemaVisibility;
        private String _txbSistemaVisibility;
        private DelegateCommand _editarFormTactCommand;
        private DelegateCommand _guardarFormTactCommand;
        private DelegateCommand _cancelarCommand;
        #endregion

        #region Propiedades publicas
        public NotifyTaskCompletion<clsFormacionTactica> formTacticaAsin
        {
            get { return _formTacticaAsin; }
        }

        public List<clsTactica> listadoTacticas
        {
            get { return _listadoTacticas; }

            set { _listadoTacticas = value; }
        }

        public bool formReadOnly
        {
            get { return _formReadOnly; }

            set
            {
                _formReadOnly = value;
                NotifyPropertyChanged("formReadOnly");
            }
        }

        public String comboBoxSistemaVisibility
        {
            get { return _comboBoxSistemaVisibility; }

            set { _comboBoxSistemaVisibility = value; }
        }

        public String txbSistemaVisibility
        {
            get { return _txbSistemaVisibility; }

            set { _txbSistemaVisibility = value; }
        }

        public DelegateCommand editarFormTactCommand
        {
            get
            {
                _editarFormTactCommand = new DelegateCommand(editarFormTactCommand_Executed);
                return _editarFormTactCommand;
            }
        }

        public DelegateCommand guardarFormTactCommand
        {
            get
            {
                _guardarFormTactCommand = new DelegateCommand(guardarFormTactCommand_Executed, guardarFormTactCommand_CanExecuted);
                return _guardarFormTactCommand;
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
        public clsVmFormTactica()
        {
            _formReadOnly = true;
            clsManejadoraFormacionTactica gest = new clsManejadoraFormacionTactica();
            _formTacticaAsin = new NotifyTaskCompletion<clsFormacionTactica>(gest.obtenerFormacionTacticaPorManagerIDDAL(App.oAppManager.id));

            _listadoTacticas = new List<clsTactica>(App.oTacticas);

            _comboBoxSistemaVisibility = "Collapsed";
            _txbSistemaVisibility = "Visible";
        }
        #endregion

        #region Commands
        private void editarFormTactCommand_Executed()
        {
            _formReadOnly = false;
            NotifyPropertyChanged("formReadOnly");
            _comboBoxSistemaVisibility = "Visible";
            NotifyPropertyChanged("comboBoxSistemaVisibility");
            _txbSistemaVisibility = "Collapsed";
            NotifyPropertyChanged("txbSistemaVisibility");
            _guardarFormTactCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();
        }

        private bool guardarFormTactCommand_CanExecuted()
        {
            bool ret = false;

            if (_txbSistemaVisibility.Equals("Collapsed") && _comboBoxSistemaVisibility.Equals("Visible"))
                ret = true;

            return ret;
        }

        private async void guardarFormTactCommand_Executed()
        {
            clsManejadoraFormacionTactica manejadora = new clsManejadoraFormacionTactica();
            bool ret = await manejadora.actualizarFormacionTacticaDAL(_formTacticaAsin.Result);

            if (ret)
            {
                clsManejadoraFormacionTactica gest = new clsManejadoraFormacionTactica();
                _formTacticaAsin = new NotifyTaskCompletion<clsFormacionTactica>(gest.obtenerFormacionTacticaPorManagerIDDAL(App.oAppManager.id));
                NotifyPropertyChanged("formTacticaAsin");
                _formReadOnly = true;
                NotifyPropertyChanged("formReadOnly");
                _comboBoxSistemaVisibility = "Collapsed";
                NotifyPropertyChanged("comboBoxSistemaVisibility");
                _txbSistemaVisibility = "Visible";
                NotifyPropertyChanged("txbSistemaVisibility");
                _guardarFormTactCommand.RaiseCanExecuteChanged();
                _cancelarCommand.RaiseCanExecuteChanged();
            }
            else
            {
                var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                String errorGuardado = resourceLoader.GetString("strErrorActualizarFormTact");

                ContentDialog error = new ContentDialog();
                error.Title = "Error";
                error.Content = errorGuardado;
                error.PrimaryButtonText = "Ok";

                ContentDialogResult resultado = await error.ShowAsync();

                if (resultado == ContentDialogResult.Primary)
                    cancelarCommand_Executed();
            }
        }

        private bool cancelarCommand_CanExecuted()
        {
            bool ret = false;

            if (_txbSistemaVisibility.Equals("Collapsed") && _comboBoxSistemaVisibility.Equals("Visible"))
                ret = true;

            return ret;
        }

        private void cancelarCommand_Executed()
        {
            _formReadOnly = true;
            NotifyPropertyChanged("formReadOnly");
            _comboBoxSistemaVisibility = "Collapsed";
            NotifyPropertyChanged("comboBoxSistemaVisibility");
            _txbSistemaVisibility = "Visible";
            NotifyPropertyChanged("txbSistemaVisibility");
            _guardarFormTactCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region Otros métodos

        #endregion
    }
}
