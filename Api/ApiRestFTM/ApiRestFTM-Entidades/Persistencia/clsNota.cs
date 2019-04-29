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


        public clsNota(int id_nota, int id_manager, String titulo, String texto)
        {
            this.id_nota = id_nota;
            this.id_manager = id_manager;
            this.titulo = titulo;
            this.texto = texto;
        }

        #endregion

        #region Propiedades
        public int id_nota { get; set; }
        public int id_manager { get; set; }
        public String titulo { get; set; }
        public String texto { get; set; }
        #endregion
    }
}
