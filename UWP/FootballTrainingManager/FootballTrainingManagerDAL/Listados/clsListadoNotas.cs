using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using FootballTrainingManagerEntidades.Persistencia;

namespace FootballTrainingManagerDAL.Listados
{
    public class clsListadoNotas
    {
        
       /// <summary>
        /// Metodo que devuelve el listado completo de notas
        /// </summary>
        /// <returns>List de clsNota</returns>
        public async Task<List<clsNota>> listadoCompletoNotasDAL(int idManager)
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            List<clsNota> listado = new List<clsNota>();

            //try catch, throw ex 
            HttpResponseMessage response = await client.GetAsync($"{ruta}manager/{idManager}/nota");

            if (response.IsSuccessStatusCode){
                string lista = await response.Content.ReadAsStringAsync();
                listado = JsonConvert.DeserializeObject<List<clsNota>>(lista);
            }
            
            return listado;
        }
        
    }
}
