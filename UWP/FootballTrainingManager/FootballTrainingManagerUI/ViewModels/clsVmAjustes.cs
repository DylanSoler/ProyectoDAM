using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTrainingManagerUI.ViewModels
{
    public class clsVmAjustes : clsVMBase
    {

        #region Propiedades privadas
        private DelegateCommand _cambiarIdiomaCommand;
        #endregion

        #region Propiedades publicas
        public DelegateCommand cambiarIdioma
        {
            get
            {
                _cambiarIdiomaCommand = new DelegateCommand(cambiarIdiomaCommand_Executed);
                return _cambiarIdiomaCommand;
            }
        }
        #endregion

        #region Constructor
        public clsVmAjustes()
        {

        }
        #endregion

        #region Commands
        private void cambiarIdiomaCommand_Executed()
        {
            
        }
        #endregion

        #region Otros métodos

        #endregion

    }
}
