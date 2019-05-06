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
    [Route("api/Manager/{id}/[controller]")]
    [ApiController]
    public class EntrenoController : ControllerBase
    {
        [HttpGet]
	public ActionResult Get(int id)
	{
            String accept = Request.Headers["Accept"].ToString();
            clsListadoEntrenos oListEntrenos = new clsListadoEntrenos();
            List<clsEntreno> oEntrenos = new List<clsEntreno>();
            
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable

            oEntrenos = oListEntrenos.listadoCompletoEntrenos(id);

	    if (oEntrenos.Count == 0)
		return NotFound(id); //404
	    else
		return Ok(oEntrenos); //200
	}
        
	[HttpPost]
	public ActionResult Post([FromBody] clsEntreno oEntrenoNuevo)
	{
            String contentType = Request.Headers["Content-Type"].ToString();
	    clsManejadoraEntreno gestEntrenos = new clsManejadoraEntreno();
	    
            if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type

            int filas = gestEntrenos.insertarEntreno(oEntrenoNuevo);

	    if (filas == 1)
		return Created(); //Created
	    else
		return StatusCode(400); //Bad Request
        }

	[HttpPut]
	public ActionResult Put(clsEntreno oEntreno)
	{
            String contentType = Request.Headers["Content-Type"].ToString();
	    clsManejadoraEntreno gestEntrenos = new clsManejadoraEntreno();
	    
            if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type

            int filas = gestEntrenos.editarEntreno(oEntreno);

            if (filas == 1)
		return NoContent(); //204 No content
	    else
		return NotFound(oEntreno.idManager,oEntreno.dia); //404 No encontrado
	}
	
    }
}
