using ApiRestFTM_DAL.Conexion;
using ApiRestFTM_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ApiRestFTM_DAL.Listados
{
    public class clsListadoNotas
    {

        /// <summary>
        /// Metodo que devuelve un listado completo de notas, segun idManager
        /// </summary>
        /// <param name="idManager">int</param>
        /// <returns>List de clsNota</returns>
        public List<clsNota> listadoCompletoNotas(int idManager)
        {
            List<clsNota> listado = new List<clsNota>();

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsNota oNota;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Notas WHERE ID_Manager = @id"; 
                miComando.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = idManager;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oNota = new clsNota();
                        oNota.idNota = (int)miLector["ID_nota"];
                        oNota.idManager = (int)miLector["ID_manager"];
                        oNota.titulo = (string)miLector["Titulo"];
                        oNota.texto = (string)miLector["TextoNota"];
                        oNota.fechaCreacion = miLector["FechaCreacion"] is DBNull ? new DateTime() : (DateTime)miLector["FechaCreacion"];
                        listado.Add(oNota);
                    }
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

            return listado;
        }

    }
}
