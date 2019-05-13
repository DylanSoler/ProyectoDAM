using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTrainingManagerEntidades.Persistencia
{
    public class clsFormacionTactica
    {
        #region Constructores
        public clsFormacionTactica()
        { }


        public clsFormacionTactica(int idManager, int idTactica, String mentalidad, String descripcion)
        {
            this.idManager = idManager;
            this.idTactica = idTactica;
            this.mentalidad = mentalidad;
            this.descripcion = descripcion;
        }

        #endregion

        #region Propiedades
        public int idManager { get; set; }
        public int idTactica { get; set; }
        public String mentalidad { get; set; }
        public String descripcion { get; set; }
        #endregion
    }
}
