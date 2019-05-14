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
    public class clsManejadoraManager
    {
        
        /// <summary>
        /// Metodo que devuelve un manager segun id
        /// </summary>
        /// <returns>clsManager</returns>
        public async Task<clsManager> obtenerManagerPorIDDAL(int id)
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            
            clsManager manager = new clsManager();

            HttpResponseMessage response = new HttpResponseMessage();

            try {
                response = await client.GetAsync($"{ruta}Manager/{id}");
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode){
                string mng = await response.Content.ReadAsStringAsync();
                manager = JsonConvert.DeserializeObject<clsManager>(pers);
            }

            return manager;
        }
  
        /// <summary>
        /// Metodo que elimina un manager segun id
        /// </summary>
        /// <param name="id">id del manager</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<boolean> eliminarManagerDAL(int id)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                response = await client.DeleteAsync($"{ruta}manager/{id}");
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que actualiza un manager
        /// </summary>
        /// <param name="manager">manager a actualizar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<boolean> actualizarManagerDAL(clsManager manager)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager);
            boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(persona);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PutAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que actualiza un manager
        /// </summary>
        /// <param name="manager">manager a insertar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<boolean> insertarManagerDAL(clsManager manager)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager);
            boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(persona);
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
