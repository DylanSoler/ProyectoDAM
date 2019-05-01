using ApiRestFTM_DAL.Conexion;
using ApiRestFTM_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ApiRestFTM_DAL.Listados
{
    public class clsListadoTacticas
    {
        /// <summary>
        /// Metodo que devuelve un listado completo de tácticas
        /// </summary>
        /// <returns>List de clsTactica</returns>
        public List<clsTactica> listadoCompletoTacticasDAL() {

            List<clsTactica> listado = new List<clsTactica>();

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsTactica oTactica;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Tacticas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oTactica = new clsTactica();
                        oTactica.idTactica = (int)miLector["ID_Tactica"];
                        oTactica.sistema = (string)miLector["Sistema"];
                        listado.Add(oTactica);
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
