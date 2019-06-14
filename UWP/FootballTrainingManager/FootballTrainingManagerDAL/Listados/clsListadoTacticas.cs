using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using FootballTrainingManagerEntidades.Persistencia;
using FootballTrainingManagerDAL.Conexion;

namespace FootballTrainingManagerDAL.Listados
{
    public class clsListadoTacticas
    {
        
        /// <summary>
        /// Metodo que devuelve el listado completo de tacticas
        /// </summary>
        /// <returns>List de clsTactica</returns>
        public async Task<List<clsTactica>> listadoCompletoTacticasDAL()
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            List<clsTactica> listado = new List<clsTactica>();

            HttpResponseMessage response = await client.GetAsync($"{ruta}tactica");

            if (response.IsSuccessStatusCode){
                string lista = await response.Content.ReadAsStringAsync();
                listado = JsonConvert.DeserializeObject<List<clsTactica>>(lista);
            }
            
            return listado;
        }
        
    }
}
