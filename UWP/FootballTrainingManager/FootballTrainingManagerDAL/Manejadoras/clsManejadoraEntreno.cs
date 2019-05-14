using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using FootballTrainingManagerEntidades.Persistencia;

namespace FootballTrainingManagerDAL.Manejadoras
{
    public class clsManejadoraEntreno
    {
        
        /// <summary>
        /// Metodo que devuelve el entreno de un manager segun su id
        /// </summary>
        /// <param name="idManager">id del manager</param>
        /// <returns>clsManager</returns>
        public async Task<clsEntreno> obtenerEntrenoPorManagerIDDAL(int idManager)
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            
            clsEntreno entreno = new clsEntreno();

            HttpResponseMessage response = new HttpResponseMessage();

            try {
                response = await client.GetAsync($"{ruta}manager/{idManager}/entreno");
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode){
                string ent = await response.Content.ReadAsStringAsync();
                entreno = JsonConvert.DeserializeObject<clsEntreno>(ent);
            }

            return entreno;
        }
        
        /// <summary>
        /// Metodo que actualiza un entreno de un manager
        /// </summary>
        /// <param name="entreno">entreno a actualizar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<boolean> actualizarEntrenoDAL(clsEntreno entreno)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager/{entreno.idManager}/entreno");
            boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(entreno);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PutAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que inserta un entreno de un manager
        /// </summary>
        /// <param name="entreno">entreno a insertar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<boolean> insertarEntrenoDAL(clsEntreno entreno)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager/{entreno.idManager}/entreno");
            boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(entreno);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PostAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
    }
}
