﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmFormTactica : clsVMBase
    {

        #region Propiedades privadas
        /*private NotifyTaskCompletion<List<clsEntreno>> _listadoEntrenos;
        private List<clsEntreno> _listadoEntrenosCopia;*/
        private Double _screenHeight;
        private Double _screenWidth;
        /*private String _entrenosSoloLecturaVisibility;
        private String _entrenosEditablesVisibility;*/
        private DelegateCommand _editarFormTactCommand;
        private DelegateCommand _guardarFormTactCommand;
        private DelegateCommand _cancelarCommand;
        #endregion

        #region Propiedades publicas
        /*public NotifyTaskCompletion<List<clsEntreno>> listadoEntrenos
        {
            get { return _listadoEntrenos; }
        }

        public List<clsEntreno> listadoEntrenosCopia
        {
            get { return _listadoEntrenosCopia; }

            set
            {
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
        }*/

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
            /*clsListadoEntrenos gest = new clsListadoEntrenos();
            _listadoEntrenos = new NotifyTaskCompletion<List<clsEntreno>>(gest.listadoCompletoEntrenosDAL(App.oAppManager.id));

            _entrenosEditablesVisibility = "Collapsed";
            _entrenosSoloLecturaVisibility = "Visible";*/
        }
        #endregion

        #region Commands
        private void editarFormTactCommand_Executed()
        {
            /*_listadoEntrenosCopia = _listadoEntrenos.Result;
            NotifyPropertyChanged("listadoEntrenosCopia");
            _entrenosEditablesVisibility = "Visible";
            NotifyPropertyChanged("entrenosEditablesVisibility");
            _entrenosSoloLecturaVisibility = "Collapsed";
            NotifyPropertyChanged("entrenosSoloLecturaVisibility");
            _guardarEntrenosCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();*/
        }

        private bool guardarFormTactCommand_CanExecuted()
        {
            bool ret = false;

            /*if (_entrenosSoloLecturaVisibility.Equals("Collapsed") && _entrenosEditablesVisibility.Equals("Visible"))
                ret = true;*/

            return ret;
        }

        private async void guardarFormTactCommand_Executed()
        {
            /*clsManejadoraEntreno manejadora = new clsManejadoraEntreno();
            bool ret = await manejadora.actualizarEntrenosDAL(_listadoEntrenosCopia);

            if (ret)
            {
                clsListadoEntrenos gest = new clsListadoEntrenos();
                _listadoEntrenos = new NotifyTaskCompletion<List<clsEntreno>>(gest.listadoCompletoEntrenosDAL(App.oAppManager.id));
                NotifyPropertyChanged("listadoEntrenos");
                _entrenosEditablesVisibility = "Collapsed";
                NotifyPropertyChanged("entrenosEditablesVisibility");
                _entrenosSoloLecturaVisibility = "Visible";
                NotifyPropertyChanged("entrenosSoloLecturaVisibility");
                _guardarEntrenosCommand.RaiseCanExecuteChanged();
                _cancelarCommand.RaiseCanExecuteChanged();
            }
            else
            {
                var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
                String errorGuardado = resourceLoader.GetString("strErrorActualizarEntrenos");

                ContentDialog error = new ContentDialog();
                error.Title = "Error";
                error.Content = errorGuardado;
                error.PrimaryButtonText = "Ok";

                ContentDialogResult resultado = await error.ShowAsync();

                if (resultado == ContentDialogResult.Primary)
                    cancelarCommand_Executed();
            }*/
        }

        private bool cancelarCommand_CanExecuted()
        {
            bool ret = false;

            /*if (_entrenosSoloLecturaVisibility.Equals("Collapsed") && _entrenosEditablesVisibility.Equals("Visible"))
                ret = true;*/

            return ret;
        }

        private void cancelarCommand_Executed()
        {
            /*_listadoEntrenosCopia = _listadoEntrenos.Result;
            NotifyPropertyChanged("listadoEntrenosCopia");
            _entrenosEditablesVisibility = "Collapsed";
            NotifyPropertyChanged("entrenosEditablesVisibility");
            _entrenosSoloLecturaVisibility = "Visible";
            NotifyPropertyChanged("entrenosSoloLecturaVisibility");
            _guardarEntrenosCommand.RaiseCanExecuteChanged();
            _cancelarCommand.RaiseCanExecuteChanged();*/
        }
        #endregion

        #region Otros métodos

        #endregion
    }
}
