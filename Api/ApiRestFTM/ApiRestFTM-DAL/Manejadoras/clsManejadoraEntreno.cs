using ApiRestFTM_DAL.Conexion;
using ApiRestFTM_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ApiRestFTM_DAL.Manejadoras
{
    public class clsManejadoraEntreno
    {

        /// <summary>
        /// Metodo que obtiene un entreno segun id del Manager y dia
        /// </summary>
        /// <param name="idManager">int</param>
        /// <returns>clsEntreno</returns>
        public clsEntreno obtenerEntrenoPorIdManagerYdia(int idManager, int dia)
        {
            clsEntreno oEntreno = new clsEntreno();

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Entrenos WHERE ID_Manager = @idManager AND Dia=@dia"; 
                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = idManager;
                miComando.Parameters.Add("@dia",System.Data.SqlDbType.Int).Value = dia;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    oEntreno = new clsEntreno();
                    oEntreno.idManager = (int)miLector["ID_Manager"];
                    oEntreno.dia = (int)miLector["Dia"];
                    oEntreno.sesion1 = (string)miLector["Sesion1"];
                    oEntreno.sesion2 = (string)miLector["Sesion2"];
                    oEntreno.sesionExtra = (string)miLector["SesionExtra"];
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

            return oEntreno;
        }
        

        /// <summary>
        /// Metodo que inserta un entreno
        /// </summary>
        /// <param name="oEntreno">clsEntreno</param>
        /// <returns>int</returns>
        public int insertarEntreno(clsEntreno oEntreno)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "INSERT INTO Entrenos (ID_Manager,Dia,Sesion1,Sesion2,SesionExtra) VALUES(@idManager,@dia,@sesion1,@sesion2,@sesionExtra)";

                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = oEntreno.idManager;
                miComando.Parameters.Add("@dia", System.Data.SqlDbType.Int).Value = oEntreno.dia;
                miComando.Parameters.Add("@sesion1", System.Data.SqlDbType.NVarChar).Value = oEntreno.sesion1;
                miComando.Parameters.Add("@sesion2", System.Data.SqlDbType.NVarChar).Value = oEntreno.sesion2;
                miComando.Parameters.Add("@sesionExtra", System.Data.SqlDbType.NVarChar).Value = oEntreno.sesionExtra;

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
        /// Metodo que edita un entreno existente
        /// </summary>
        /// <param name="oEntreno">clsEntreno</param>
        /// <returns>int</returns>
        public int editarEntreno(clsEntreno oEntreno)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "UPDATE Entrenos SET Sesion1=@sesion1, Sesion2=@sesion2, SesionExtra=@sesionExtra WHERE ID_Manager=@idManager AND Dia=@dia";

                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = oEntreno.idManager;
                miComando.Parameters.Add("@dia", System.Data.SqlDbType.Int).Value = oEntreno.dia;
                miComando.Parameters.Add("@sesion1", System.Data.SqlDbType.NVarChar).Value = oEntreno.sesion1;
                miComando.Parameters.Add("@sesion2", System.Data.SqlDbType.NVarChar).Value = oEntreno.sesion2;
                miComando.Parameters.Add("@sesionExtra", System.Data.SqlDbType.NVarChar).Value = oEntreno.sesionExtra;

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
