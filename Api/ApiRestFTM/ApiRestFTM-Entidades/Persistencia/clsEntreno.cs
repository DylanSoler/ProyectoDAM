using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRestFTM_Entidades.Persistencia
{
    public class clsEntreno
    {
        #region Constructores
        public clsEntreno()
        { }

        
        public clsEntreno(int idManager, int dia, String sesion1, String sesion2, String sesionExtra)
        {
            this.idManager = idManager;
            this.dia = dia;
            this.sesion1 = sesion1;
            this.sesion2 = sesion2;
            this.sesionExtra = sesionExtra;
        }

        #endregion

        #region Propiedades
        public int idManager { get; set; }
        public int dia { get; set; }
        public String sesion1 { get; set; }
        public String sesion2 { get; set; }
        public String sesionExtra { get; set; }
        #endregion
    }
}
