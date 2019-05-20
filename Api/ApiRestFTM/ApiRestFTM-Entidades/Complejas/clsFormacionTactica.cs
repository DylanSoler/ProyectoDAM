using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRestFTM_Entidades.Complejas
{
    public class clsFormacionTactica
    {
        #region Constructores
        public clsFormacionTactica()
        { }


        public clsFormacionTactica(int idManager, int idTactica, String mentalidad, String descripcion, String sistemaTactico)
        {
            this.idManager = idManager;
            this.idTactica = idTactica;
            this.mentalidad = mentalidad;
            this.descripcion = descripcion;
            this.sistemaTactico = sistemaTactico;
        }

        #endregion

        #region Propiedades
        public int idManager { get; set; }
        public int idTactica { get; set; }
        public String mentalidad { get; set; }
        public String descripcion { get; set; }
        public String sistemaTactico { get; set; }
        #endregion
    }
}
