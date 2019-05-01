using ApiRestFTM_DAL.Conexion;
using ApiRestFTM_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ApiRestFTM_DAL.Manejadoras
{
    public class clsManejadoraManager
    {

        /// <summary>
        /// Metodo que obtiene un manager segun id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsManager</returns>
        public clsManager managerPorId(int id)
        {

            clsManager oManager = new clsManager();

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM managers WHERE ID = @id"; 
                miComando.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    oManager = new clsManager();
                    oManager.id = (int)miLector["ID"];
                    oManager.correo = (string)miLector["Correo"];
                    oManager.passwordManager = (string)miLector["PasswordManager"];
                    oManager.nombre = (string)miLector["Nombre"];
                    oManager.apellidos = (string)miLector["Apellidos"];
                    oManager.fotoPerfil = (string)miLector["FotoPerfil"];
                    oManager.fechaNacimiento = (DateTime)miLector["FechaNacimiento"];

                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                miLector.Close();
                gestConexion.closeConnection(ref miConexion);
            }



            return oManager;

        }

    }
}
