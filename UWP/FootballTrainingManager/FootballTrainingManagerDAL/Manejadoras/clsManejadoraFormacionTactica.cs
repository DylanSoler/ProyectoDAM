using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using FootballTrainingManagerEntidades.Persistencia;
using FootballTrainingManagerDAL.Conexion;
using FootballTrainingManagerEntidades.Complejas;

namespace FootballTrainingManagerDAL.Manejadoras
{
    public class clsManejadoraFormacionTactica
    {
        
        /// <summary>
        /// Metodo que devuelve la formacion tactica de un manager segun su id
        /// </summary>
        /// <param name="idManager">id del manager</param>
        /// <returns>clsFormacionTactica</returns>
        public async Task<clsFormacionTactica> obtenerFormacionTacticaPorManagerIDDAL(int idManager)
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            
            clsFormacionTactica formTactica = new clsFormacionTactica();

            HttpResponseMessage response = new HttpResponseMessage();

            try {
                response = await client.GetAsync($"{ruta}manager/{idManager}/formacion");
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode){
                string ft = await response.Content.ReadAsStringAsync();
                formTactica = JsonConvert.DeserializeObject<clsFormacionTactica>(ft);
            }

            return formTactica;
        }
        
        /// <summary>
        /// Metodo que actualiza la formacion tactica de un manager
        /// </summary>
        /// <param name="formTactica">formacion tactica a actualizar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> actualizarFormacionTacticaDAL(clsFormacionTactica formTactica)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager/{formTactica.idManager}/entreno");
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(formTactica);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                response = await client.PutAsync(miUri, contenido);
            } catch (Exception ex) {
                
            }

            if (response.IsSuccessStatusCode)
                ret = true;

            return ret;
        }
        
        /// <summary>
        /// Metodo que inserta la formacion tactica de un manager
        /// </summary>
        /// <param name="entreno">formacion tactica a insertar</param>
        /// <returns>boolean true si todo va bien, false si no</returns>
        public async Task<Boolean> insertarFormacionTacticaDAL(clsFormacionTactica formTactica)
        {
            HttpClient client = new HttpClient();
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();
            String datos;
            HttpContent contenido;
            Uri miUri = new Uri($"{ruta}manager/{formTactica.idManager}/formacion");
            Boolean ret = false;

            HttpResponseMessage response = new HttpResponseMessage();

            try{
                datos = JsonConvert.SerializeObject(formTactica);
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
