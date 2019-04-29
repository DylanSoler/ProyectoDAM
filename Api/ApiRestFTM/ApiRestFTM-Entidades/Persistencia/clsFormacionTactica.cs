using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRestFTM_Entidades.Persistencia
{
    public class clsFormacionTactica
    {
        #region Constructores
        public clsFormacionTactica()
        { }


        public clsFormacionTactica(int id_manager, int id_tactica, String mentalidad, String descripcion)
        {
            this.id_manager = id_manager;
            this.id_tactica = id_tactica;
            this.mentalidad = mentalidad;
            this.descripcion = descripcion;
        }

        #endregion

        #region Propiedades
        public int id_manager { get; set; }
        public int id_tactica { get; set; }
        public String mentalidad { get; set; }
        public String descripcion { get; set; }
        #endregion
    }
}
