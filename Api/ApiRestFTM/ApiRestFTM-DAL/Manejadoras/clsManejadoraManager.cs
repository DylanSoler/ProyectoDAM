﻿using ApiRestFTM_DAL.Conexion;
using ApiRestFTM_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ApiRestFTM_DAL.Manejadoras
{
    public class clsManejadoraManager
    {

        /// <summary>
        /// Metodo que obtiene un manager segun id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>clsManager</returns>
        public clsManager managerPorId(int id)
        {
            clsManager oManager = null;

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
                    oManager.passwordManager = (String)miLector["PasswordManager"];
                    oManager.nombre = (string)miLector["Nombre"];
                    oManager.apellidos = (string)miLector["Apellidos"];
                    oManager.fotoPerfil = (string)miLector["FotoPerfil"];
                    oManager.fechaNacimiento = miLector["FechaNacimiento"] is DBNull ? new DateTime(): (DateTime)miLector["FechaNacimiento"];
                }
            } catch (SqlException exSql){
                throw exSql;
            }
            finally {
                miLector.Close();
                gestConexion.closeConnection(ref miConexion);
            }

            return oManager;
        }
        
        
        /// <summary>
        /// Metodo que elimina un manager segun id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>int</returns>
        public int borrarManagerPorID(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "DELETE FROM Managers WHERE ID = @id";
                miComando.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = id;
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
        /// Metodo que inserta un manager
        /// </summary>
        /// <param name="oManager">clsManager</param>
        /// <returns>int</returns>
        public int insertarManager(clsManager oManager)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = null;
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando = new SqlCommand("RegistroManager", miConexion);
                miComando.CommandType = CommandType.StoredProcedure;

                miComando.Parameters.AddWithValue("@correo", oManager.correo);
                miComando.Parameters.AddWithValue("@passwManager", oManager.passwordManager);
                miComando.Parameters.AddWithValue("@nombre", oManager.nombre);
                miComando.Parameters.AddWithValue("@apellidos", oManager.apellidos);
                miComando.Parameters.AddWithValue("@fotoPerfil", oManager.fotoPerfil);
                miComando.Parameters.AddWithValue("@fechaNac", oManager.fechaNacimiento);

                SqlParameter filasOutput = new SqlParameter("@filas", SqlDbType.Int);
                filasOutput.Direction = ParameterDirection.Output;
                miComando.Parameters.Add(filasOutput);

                miComando.ExecuteNonQuery();

                filas = (int)filasOutput.Value;

            } catch (SqlException exSql) {
                throw exSql;
            } finally {
                gestConexion.closeConnection(ref miConexion);
            }
           
            return filas;
        }
        
        /// <summary>
        /// Metodo que edita un manager existente
        /// </summary>
        /// <param name="oManager">clsManager</param>
        /// <returns>int</returns>
        public int editarManager(clsManager oManager)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "UPDATE Managers SET Correo=@correo, Nombre=@nombre, Apellidos=@apellidos, FotoPerfil=@fotoPerfil, FechaNacimiento=@fechaNac WHERE ID=@id";

                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = oManager.id;
                miComando.Parameters.Add("@correo",System.Data.SqlDbType.NVarChar).Value = oManager.correo;
                //miComando.Parameters.Add("@passwManager", System.Data.SqlDbType.Varchar).Value = oManager.passwordManager;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = oManager.nombre;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.NVarChar).Value = oManager.apellidos;
                miComando.Parameters.Add("@fotoPerfil", System.Data.SqlDbType.NVarChar).Value = oManager.fotoPerfil;
                miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.SmallDateTime).Value = oManager.fechaNacimiento;

                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();
            } catch (SqlException exSql) {
                throw exSql;
            } finally {
                gestConexion.closeConnection(ref miConexion);
            }

            return filas;
        }
        
        /// <summary>
        /// Metodo que actualiza la contrasenia de un manager segun id
        /// </summary>
        /// <param name="idManager">int</param>
        /// <param name="passw">byte[]</param>
        /// <returns>int</returns>
        public int editarPasswordManager(int idManager, String passw)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "UPDATE Managers SET PasswordManager=@passwManager WHERE ID=@id";

                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idManager;
                miComando.Parameters.Add("@passwManager", System.Data.SqlDbType.VarChar).Value = passw;

                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();
            } catch (SqlException exSql) {
                throw exSql;
            } finally {
                gestConexion.closeConnection(ref miConexion);
            }

            return filas;
        }

        public clsManager managerPorCorreo(String correo)
        {
            clsManager oManager = null;

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM managers WHERE Correo = @correo";
                miComando.Parameters.Add("@correo", System.Data.SqlDbType.NVarChar).Value = correo;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    oManager = new clsManager();
                    oManager.id = (int)miLector["ID"];
                    oManager.correo = (string)miLector["Correo"];
                    oManager.passwordManager = (String)miLector["PasswordManager"];
                    oManager.nombre = (string)miLector["Nombre"];
                    oManager.apellidos = (string)miLector["Apellidos"];
                    oManager.fotoPerfil = (string)miLector["FotoPerfil"];
                    oManager.fechaNacimiento = miLector["FechaNacimiento"] is DBNull ? new DateTime() : (DateTime)miLector["FechaNacimiento"];
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
