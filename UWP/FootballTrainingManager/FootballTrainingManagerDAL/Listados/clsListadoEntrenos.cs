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
    public class clsListadoEntrenos
    {
        
        /// <summary>
        /// Metodo que devuelve el listado completo de entrenos
        /// </summary>
        /// <returns>List de clsEntreno</returns>
        public async Task<List<clsEntreno>> listadoCompletoEntrenosDAL(int idManager)
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            List<clsEntreno> listado = new List<clsEntreno>();

            //try catch, throw ex 
            HttpResponseMessage response = await client.GetAsync($"{ruta}manager/{idManager}/entreno");

            if (response.IsSuccessStatusCode){
                string lista = await response.Content.ReadAsStringAsync();
                listado = JsonConvert.DeserializeObject<List<clsEntreno>>(lista);
            }
            
            return listado;
        }
        
    }
}
