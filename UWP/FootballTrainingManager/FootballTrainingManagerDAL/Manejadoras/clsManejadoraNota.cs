using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using FootballTrainingManagerEntidades.Persistencia;
using FootballTrainingManagerDAL.Conexion;

namespace FootballTrainingManagerDAL.Manejadoras
{
    public class clsManejadoraNota
    {
        
        /// <summary>
        /// Metodo que devuelve una nota de un manager segun id del manager e id nota
        /// </summary>
        /// <param name="idManager">id del manager</param>
        /// <param name="idNota">id de la nota</param>
        /// <returns>clsNota</returns>
        public async Task<clsNota> obtenerNotaPorIDDAL(int idManager, int idNota)
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            
            clsNota nota = new clsNota();

            HttpResponseMessage response = new HttpResponseMessage();

            try {
                response = await client.GetAsync($"{ruta}manager/{idManager}/nota/{idNota}");
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode){
                string ent = await response.Content.ReadAsStringAsync();
                nota = JsonConvert.DeserializeObject<clsNota>(ent);
            }

            return nota;
        }
        
        /// <summary>
        /// Metodo que actualiza una nota de un manager
        /// </summary>
        /// <param name="nota">nota a actualizar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> actualizarNotaDAL(clsNota nota)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager/{nota.idManager}/nota");
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(nota);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PutAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que inserta una nota de un manager
        /// </summary>
        /// <param name="nota">nota a insertar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> insertarNotaDAL(clsNota nota)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager/{nota.idManager}/nota");
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(nota);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PostAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que elimina una nota segun id del manager e id de la nota
        /// </summary>
        /// <param name="idManager">id del manager</param>
        /// <param name="idNota">id de la nota</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> eliminarNotaDAL(int idManager, int idNota)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                response = await client.DeleteAsync($"{ruta}manager/{idManager}/nota/{idNota}");
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que elimina todas las notas de un manager
        /// </summary>
        /// <param name="idManager">id del manager</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> eliminarTodasLasNotasDAL(int idManager)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                response = await client.DeleteAsync($"{ruta}manager/{idManager}/nota/");
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        } 
        
    }
}
