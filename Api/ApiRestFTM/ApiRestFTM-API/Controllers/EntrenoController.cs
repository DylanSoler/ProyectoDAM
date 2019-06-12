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
    public class EntrenoController : ControllerBase
    {

    [HttpGet]
	public IActionResult Get(int id)
	{
            String accept = Request.Headers["Accept"].ToString();
            clsListadoEntrenos oListEntrenos = new clsListadoEntrenos();
            List<clsEntreno> oEntrenos = new List<clsEntreno>();
            
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable
	    else
	    {
		    oEntrenos = oListEntrenos.listadoCompletoEntrenos(id);

		    if (oEntrenos.Count == 0)
			    return NotFound(id); //404
		    else
			    return Ok(oEntrenos); //200
	    }
	}
        
	[HttpPost]
	public IActionResult Post([FromBody] List<clsEntreno> oEntrenosNuevos)
	{
        String contentType = Request.Headers["Content-Type"].ToString();
	    clsManejadoraEntreno gestEntrenos = new clsManejadoraEntreno();
	    
        if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type
	    else
	    {
		    int filas = gestEntrenos.insertarEntreno(oEntrenosNuevos);

		    if (filas == 7)
			    return StatusCode(201);
		    else
			    return StatusCode(400); //Bad Request
	    }
	    
        }

	[HttpPut]
	public IActionResult Put([FromBody] List<clsEntreno> oEntrenos)
	{
        String contentType = Request.Headers["Content-Type"].ToString();
	    clsManejadoraEntreno gestEntrenos = new clsManejadoraEntreno();
	    
        if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type
	    else
	    {
		    int filas = gestEntrenos.editarEntreno(oEntrenos);

		    if (filas == 7)
			    return NoContent(); //204 No content
		    else
			    return NotFound(oEntrenos[1].idManager); //404 No encontrado
	    }
	    
	}
	
    }
}
