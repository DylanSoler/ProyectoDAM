using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTrainingManagerEntidades.Persistencia
{
    public class clsTactica
    {
        #region Constructores
        public clsTactica()
        { }

        public clsTactica(int idTactica, String sistema)
        {
            this.idTactica = idTactica;
            this.sistema = sistema;
        }

        #endregion

        #region Propiedades
        public int idTactica { get; set; }
        public String sistema { get; set; }
        #endregion
    }
}
