using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTrainingManagerEntidades.Persistencia
{
    /// <summary>
    /// Clase clsManager, de persistencia con la tabla de la base de datos Manager
    /// </summary>
    public class clsManager
    {
        #region Constructores
        public clsManager()
        { }

        public clsManager(int id, String correo, byte[] passwordManager, String nombre, String apellidos, String fotoPerfil, DateTime fechaNacimiento)
        {
            this.id = id;
            this.correo = correo;
            this.passwordManager = passwordManager;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fotoPerfil = fotoPerfil;
            this.fechaNacimiento = fechaNacimiento;
        }

        #endregion

        #region Propiedades
        public int id { get; set; }
        public String correo { get; set; }
        public byte[] passwordManager { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public String fotoPerfil { get; set; }
        public DateTime fechaNacimiento { get; set; }
        #endregion

    }
}
