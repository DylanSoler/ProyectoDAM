using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRestFTM_Entidades.Persistencia
{
    public class clsNota
    {
        #region Constructores
        public clsNota()
        { }


        public clsNota(int idNota, int idManager, String titulo, String texto)
        {
            this.idNota = idNota;
            this.idManager = idManager;
            this.titulo = titulo;
            this.texto = texto;
        }

        #endregion

        #region Propiedades
        public int idNota { get; set; }
        public int idManager { get; set; }
        public String titulo { get; set; }
        public String texto { get; set; }
        #endregion
    }
}
