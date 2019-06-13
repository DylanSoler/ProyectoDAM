using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTrainingManagerEntidades.Persistencia
{
    public class clsNota
    {
        #region Constructores
        public clsNota()
        { }


        public clsNota(int idNota, int idManager, String titulo, String texto, DateTime fechaCreacion)
        {
            this.idNota = idNota;
            this.idManager = idManager;
            this.titulo = titulo;
            this.texto = texto;
            this.fechaCreacion = fechaCreacion;
        }

        #endregion

        #region Propiedades
        public int idNota { get; set; }
        public int idManager { get; set; }
        public String titulo { get; set; }
        public String texto { get; set; }
        public DateTime fechaCreacion { get; set; }
        #endregion
    }
}
