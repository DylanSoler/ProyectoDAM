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

        
        public clsEntreno(int id_manager, int dia, String sesion1, String sesion2, String sesionExtra)
        {
            this.id_manager = id_manager;
            this.dia = dia;
            this.sesion1 = sesion1;
            this.sesion2 = sesion2;
            this.sesionExtra = sesionExtra;
        }

        #endregion

        #region Propiedades
        public int id_manager { get; set; }
        public int dia { get; set; }
        public String sesion1 { get; set; }
        public String sesion2 { get; set; }
        public String sesionExtra { get; set; }
        #endregion
    }
}
