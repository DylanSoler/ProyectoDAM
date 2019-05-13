using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestFTM_DAL.Manejadoras;
using ApiRestFTM_Entidades.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestFTM_API.Controllers
{
    [Route("Manager/{id}/[controller]")]
    [ApiController]
    public class FormacionController : ControllerBase
    {
    
        [HttpGet]
        public IActionResult Get(int id)
        {
                String accept = Request.Headers["Accept"].ToString();
                clsManejadoraFormacion oManejadoraForm = new clsManejadoraFormacion();
                clsFormacionTactica oFormacion = new clsFormacionTactica();

                if (accept != "application/json" && accept != "*/*")
                    return StatusCode(406); //Not Acceptable
                else
                {
                    oFormacion = oManejadoraForm.formacionTacticaPorIdManager(id);

                    if (oFormacion != null)
                        return Ok(oFormacion);
                    else
                        return NotFound(id); //No encontrado
                }
        }
        
        
        [HttpPost]
        public IActionResult Post([FromBody] clsFormacionTactica oFormacionNueva)
        {
            String contentType = Request.Headers["Content-Type"].ToString();
            clsManejadoraFormacion gestFormacion = new clsManejadoraFormacion();

                if (contentType != "application/json" && contentType != "*/*")
                    return StatusCode(415); //Unsupported Media Type
                else
                {
                    int filas = gestFormacion.insertarFormacionTactica(oFormacionNueva);

                    if (filas == 1)
                        return Created(); //Created
                    else
                        return StatusCode(400); //Bad Request
                }
        }


        [HttpPut]
        public IActionResult Put(clsFormacionTactica oFormacion)
        {
            String contentType = Request.Headers["Content-Type"].ToString();
            clsManejadoraFormacion gestFormacion = new clsManejadoraFormacion();

            if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type
            else
            {
                int filas = gestFormacion.editarFormacionTactica(oFormacion);

                if (filas == 1)
                return NoContent(); //204 No content
                else
                return NotFound(oEntreno.idManager,oEntreno.dia); //404 No encontrado
            } 
        }
    
    }
}
