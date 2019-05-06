using ApiRestFTM_DAL.Conexion;
using ApiRestFTM_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ApiRestFTM_DAL.Listados
{
    public class clsListadoEntrenos
    {

        /// <summary>
        /// Metodo que devuelve un listado completo de entrenos, segun idManager
        /// </summary>
        /// <param name="idManager">int</param>
        /// <returns>List de clsEntreno</returns>
        public List<clsEntreno> listadoCompletoEntrenos(int idManager)
        {
            List<clsEntreno> listado = new List<clsEntreno>();

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsEntreno oEntreno;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Entrenos WHERE ID_Manager = @id"; 
                miComando.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = idManager;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oEntreno = new clsEntreno();
                        oEntreno.idManager = (int)miLector["ID_manager"];
                        oEntreno.dia = (int)miLector["Dia"];
                        oEntreno.sesion1 = (string)miLector["Sesion1"];
                        oEntreno.sesion2 = (string)miLector["Sesion2"];
                        oEntreno.sesionExtra = (string)miLector["SesionExtra"];
                        listado.Add(oEntreno);
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
