using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRestFTM_Entidades.Persistencia
{
    public class clsTactica
    {
        #region Constructores
        public clsTactica()
        { }

        public clsTactica(int id_tactica, String sistema)
        {
            this.id_tactica = id_tactica;
            this.sistema = sistema;
        }

        #endregion

        #region Propiedades
        public int id_tactica { get; set; }
        public String sistema { get; set; }
        #endregion
    }
}
