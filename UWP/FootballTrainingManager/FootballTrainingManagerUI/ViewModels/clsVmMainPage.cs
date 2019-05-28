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
        #endregion

        #region Propiedades publicas
        public String imagenPerfil
        {
            get { return _imagenPerfil; }

            set { _imagenPerfil = value; }
        }
        #endregion

        #region Constructor
        public clsVmMainPage() {
            _imagenPerfil = App.oAppManager.fotoPerfil;

        }
        #endregion
    }
}
