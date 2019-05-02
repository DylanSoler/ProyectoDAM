using ApiRestFTM_DAL.Conexion;
using ApiRestFTM_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ApiRestFTM_DAL.Manejadoras
{
    public class clsManejadoraNota
    {

        /// <summary>
        /// Metodo que obtiene una nota segun idNota y idManager
        /// </summary>
        /// <param name="idManager">int</param>
        /// <param name="idNota">int</param>
        /// <returns>clsNota</returns>
        public clsNota obtenerNotaPorIdManager(int idManager, int idNota)
        {
            clsNota oNota = new clsNota();

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM notas WHERE ID_Manager = @idManager AND ID_nota = @idNota"; 
                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = idManager;
                miComando.Parameters.Add("@idNota",System.Data.SqlDbType.Int).Value = idNota;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    oNota.idNota = (int)miLector["ID_nota"];
                    oNota.idManager = (int)miLector["ID_Manager"];
                    oNota.titulo = (string)miLector["Titulo"];
                    oNota.texto = (string)miLector["TextoNota"];
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

            return oNota;
        }
        
        
        /// <summary>
        /// Metodo que elimina una nota segun idManager e idNota
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>int</returns>
        public int borrarNotaPorIdManager(int idManager, int idNota)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "DELETE FROM Notas WHERE ID_Manager = @idManager AND ID_nota = @idNota";
                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = idManager;
                miComando.Parameters.Add("@idNota",System.Data.SqlDbType.Int).Value = idNota;
                miComando.Connection = miConexion;
                
                filas = miComando.ExecuteNonQuery();

            } catch (SqlException exSql){
                throw exSql;
            }
            finally{
                gestConexion.closeConnection(ref miConexion);
            }

            return filas;
        }
        
        
        /// <summary>
        /// Metodo que inserta una nota
        /// </summary>
        /// <param name="oNota">clsNota</param>
        /// <returns>int</returns>
        public int insertarNota(clsNota oNota)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "INSERT INTO Notas (ID_Manager,Titulo, TextoNota) VALUES(@idManager,@titulo,@texto)";

                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = oNota.idManager;
                miComando.Parameters.Add("@titulo",System.Data.SqlDbType.NVarChar).Value = oNota.titulo;
                miComando.Parameters.Add("@texto", System.Data.SqlDbType.NVarChar).Value = oNota.texto;

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
        /// Metodo que edita una nota existente
        /// </summary>
        /// <param name="oNota">clsNota</param>
        /// <returns>int</returns>
        public int editarNota(clsNota oNota)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "UPDATE Notas SET Titulo=@titulo, TextoNota=@texto WHERE ID_Manager = @idManager AND ID_nota = @idNota";

                miComando.Parameters.Add("@idManager", System.Data.SqlDbType.Int).Value = oNota.idManager;
                miComando.Parameters.Add("@idNota",System.Data.SqlDbType.Int).Value = oNota.idNota;
                miComando.Parameters.Add("@titulo", System.Data.SqlDbType.NVarChar).Value = oNota.titulo;
                miComando.Parameters.Add("@texto", System.Data.SqlDbType.NVarChar).Value = oNota.texto;

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
        /// Metodo que elimina todas las notas de un manager segun idManager
        /// </summary>
        /// <param name="idManager">int</param>
        /// <returns>int</returns>
        public int borradoCompletoNotasPorIdManager(int idManager)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "DELETE FROM Notas WHERE ID_Manager = @idManager";
                miComando.Parameters.Add("@idManager",System.Data.SqlDbType.Int).Value = idManager;
                miComando.Connection = miConexion;
                
                filas = miComando.ExecuteNonQuery();

            } catch (SqlException exSql){
                throw exSql;
            }
            finally{
                gestConexion.closeConnection(ref miConexion);
            }

            return filas;
        }

    }
}
