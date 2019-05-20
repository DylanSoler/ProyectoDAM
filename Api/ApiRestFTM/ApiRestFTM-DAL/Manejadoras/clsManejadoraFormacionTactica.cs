using ApiRestFTM_DAL.Conexion;
using ApiRestFTM_Entidades.Complejas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ApiRestFTM_DAL.Manejadoras
{
    public class clsManejadoraFormacion
    {

        /// <summary>
        /// Metodo que obtiene una formacion tactica segun id del Manager
        /// </summary>
        /// <param name="idManager">int</param>
        /// <returns>clsFormacionTactica</returns>
        public clsFormacionTactica formacionTacticaPorIdManager(int idManager)
        {
            clsFormacionTactica oFormacion = null;

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT MT.*, T.Sistema FROM ManagersTacticas AS MT INNER JOIN Tacticas AS T ON MT.ID_Tactica=T.ID_Tactica WHERE ID_Manager = @idManager"; 
                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = idManager;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    oFormacion = new clsFormacionTactica();
                    oFormacion.idManager = (int)miLector["ID_Manager"];
                    oFormacion.idTactica = (byte)miLector["ID_Tactica"];
                    oFormacion.mentalidad = (string)miLector["Mentalidad"];
                    oFormacion.descripcion = (string)miLector["Descripcion"];
                    oFormacion.sistemaTactico = (string)miLector["Sistema"];
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

            return oFormacion;
        }
        

        /// <summary>
        /// Metodo que inserta una formacion tactica
        /// </summary>
        /// <param name="oFormacion">clsFormacionTactica</param>
        /// <returns>int</returns>
        public int insertarFormacionTactica(clsFormacionTactica oFormacion)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "INSERT INTO ManagersTacticas (ID_Manager,ID_Tactica,Mentalidad,Descripcion) VALUES(@idManager,@idTactica,@mentalidad,@descripcion)";

                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = oFormacion.idManager;
                miComando.Parameters.Add("@idTactica", System.Data.SqlDbType.Int).Value = oFormacion.idTactica;
                miComando.Parameters.Add("@mentalidad", System.Data.SqlDbType.NVarChar).Value = oFormacion.mentalidad;
                miComando.Parameters.Add("@descripcion", System.Data.SqlDbType.NVarChar).Value = oFormacion.descripcion;

                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                gestConexion.closeConnection(ref miConexion);
            }
            
            return filas;
        }
        

        /// <summary>
        /// Metodo que edita una formacion tactica
        /// </summary>
        /// <param name="oFormacion">clsFormacionTactica</param>
        /// <returns>int</returns>
        public int editarFormacionTactica(clsFormacionTactica oFormacion)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "UPDATE ManagersTacticas SET ID_Manager=@idManager, ID_Tactica=@idTactica, Mentalidad=@mentalidad, Descripcion=@descripcion WHERE ID_Manager=@idManager";

                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = oFormacion.idManager;
                miComando.Parameters.Add("@idTactica", System.Data.SqlDbType.Int).Value = oFormacion.idTactica;
                miComando.Parameters.Add("@mentalidad", System.Data.SqlDbType.NVarChar).Value = oFormacion.mentalidad;
                miComando.Parameters.Add("@descripcion", System.Data.SqlDbType.NVarChar).Value = oFormacion.descripcion;

                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                gestConexion.closeConnection(ref miConexion);
            }

            return filas;
        }

    }
}
