using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using FootballTrainingManagerEntidades.Persistencia;
using FootballTrainingManagerDAL.Conexion;
using System.Net.Http.Headers;

namespace FootballTrainingManagerDAL.Manejadoras
{
    public class clsManejadoraManager
    {
        
        /// <summary>
        /// Metodo que devuelve un manager segun id
        /// </summary>
        /// <param name="id">id del manager</param>
        /// <returns>clsManager</returns>
        public async Task<clsManager> obtenerManagerPorIDDAL(int id)
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            
            clsManager manager = null;

            HttpResponseMessage response = new HttpResponseMessage();

            try {
                response = await client.GetAsync($"{ruta}manager/{id}");
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode){
                string mng = await response.Content.ReadAsStringAsync();
                manager = JsonConvert.DeserializeObject<clsManager>(mng);
            }

            return manager;
        }
  
        /// <summary>
        /// Metodo que elimina un manager segun id
        /// </summary>
        /// <param name="id">id del manager</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> eliminarManagerDAL(int id)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            Boolean ret = false;

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
        public async Task<Boolean> actualizarManagerDAL(clsManager manager)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager");
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(manager);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PutAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que inserta un manager
        /// </summary>
        /// <param name="manager">manager a insertar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> insertarManagerDAL(clsManager manager)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager");
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(manager);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PostAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que actualiza la contrasenia de un manager
        /// </summary>
        /// <param name="idManager">ID manager a actualizar</param>
        /// <param name="passw">nueva password</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> actualizarPasswordManagerDAL(int idManager, String passw)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager/{idManager}");
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(passw);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PostAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }

        /// <summary>
        /// Metodo que devuelve un manager segun su correo
        /// </summary>
        /// <param name="correo">email del manager a consultar</param>
        /// <returns>clsManager</returns>
        public async Task<clsManager> obtenerManagerPorEmail(String correo)
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            Uri miUri = new Uri($"{ruta}manager/correo");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpContent contenido;
            String datos;

            clsManager manager = null;
            HttpResponseMessage response = new HttpResponseMessage();

            try {
                datos = JsonConvert.SerializeObject(correo);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                contenido.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode) {
                string mng = await response.Content.ReadAsStringAsync();
                manager = JsonConvert.DeserializeObject<clsManager>(mng);
            }

            return manager;
        }
                                
    }
}
