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
        /// Metodo que devuelve un listado completo de notas
        /// </summary>
        /// <returns>List de clsNota</returns>
        public List<clsNota> listadoCompletoNotasDAL()
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
                miComando.CommandText = "SELECT * FROM Notas";
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
