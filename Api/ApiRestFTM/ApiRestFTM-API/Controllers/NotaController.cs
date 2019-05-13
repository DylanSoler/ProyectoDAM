using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestFTM_DAL.Listados;
using ApiRestFTM_DAL.Manejadoras;
using ApiRestFTM_Entidades.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestFTM_API.Controllers
{
    [Route("Manager/{id}/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        //GET Manager/{id}/nota
        [HttpGet]
        public IActionResult Get(int id)
        {
            String accept = Request.Headers["Accept"].ToString();
            clsListadoNotas oListNotas = new clsListadoNotas();
            List<clsNota> oNotas = new List<clsNota>();

            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable
            else
            {
                oNotas = oListNotas.listadoCompletoEntrenos(id);

                if (oEntrenos.Count == 0)
                    return NotFound(id); //404
                else
                    return Ok(oNotas); //200
            }
        }
        
        
        //GET Manager/{id}/nota/{idNota}
        [HttpGet("{idNota}")]
		public ActionResult Get(int id, int idNota)
		{
            String accept = Request.Headers["Accept"].ToString();
            clsNota oNota = new clsNota();
            clsManejadoraNota gestNotas = new clsManejadoraNota();
            
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable

            oNota = gestNotas.obtenerNotaPorIdManager(id, idNota);
			
			if (result != null)
				return Ok(result); //200
			else
				return NotFound(id, idNota); //404
		}
        
        
        //PUT Manager/{id}/nota
        [HttpPut]
        public IActionResult Put(clsNota oNota)
        {
            String contentType = Request.Headers["Content-Type"].ToString();
            clsManejadoraNota gestNotas = new clsManejadoraNota();
            
            if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type (Formato no legible)
            else
            {
                int ret = gestNotas.editarNota(oNota);

                if (ret>0)
                    return StatusCode(204); //No Content(eliminado con exito)
                else
                    return NotFound(oNota.idManager, oNota.idNota); //No encontrado
            }
        }
        
        
        //POST Manager/{id}/nota
        [HttpPost]
        public IActionResult Post([FromBody] clsNota oNota)
        {
            String contentType = Request.Headers["Content-Type"].ToString();
            clsManejadoraNota gestNotas = new clsManejadoraNota();
            
            if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type (Formato no legible)
            else
            {
                int ret = gestNotas.insertarNota(oNota);

                if (ret>0)
                    return Created(); //Created
                else
                    return StatusCode(400); //Error inesperado
            }
        }
        
        //DELETE Manager/{id}/nota
        [HttpDelete]
		public ActionResult Delete(int id)
		{
			clsManejadoraNota gestNotas = new clsManejadoraNota();
            int ret = gestNotas.borradoCompletoNotasPorIdManager(id);

			if (ret>0)
                return StatusCode(204); //No Content(eliminado con exito)
            else
                return NotFound(id); //404 No encontrado
		}
        
        
        //DELETE Manager/{id}/nota/{idNota}
        [HttpDelete("{idNota}")]
		public ActionResult Delete(int id, int idNota)
		{
			clsManejadoraNota gestNotas = new clsManejadoraNota();
            int ret = gestNotas.borrarNotaPorIdManager(id, idNota);

			if (ret>0)
                return StatusCode(204); //No Content(eliminado con exito)
            else
                return NotFound(id); //404 No encontrado
		}
    }
}
