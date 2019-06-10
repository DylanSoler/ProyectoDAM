using FootballTrainingManagerDAL.Listados;
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
        private Double _screenHeight;
        private Double _screenWidth;
        private bool _entrenoReadOnly;
        #endregion

        #region Propiedades publicas

        public NotifyTaskCompletion<List<clsEntreno>> listadoEntrenos
        {
            get { return _listadoEntrenos; }
        }

        public bool entrenoReadOnly
        {
            get { return _entrenoReadOnly; }

            set
            {
                _entrenoReadOnly = value;
                NotifyPropertyChanged("entrenoReadOnly");
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

            _entrenoReadOnly = true;

            _listadoEntrenos = new NotifyTaskCompletion<List<clsEntreno>>(gest.listadoCompletoEntrenosDAL(App.oAppManager.id));
        }
        #endregion

        #region Commands

        #endregion

        #region Otros métodos

        #endregion

    }
}
