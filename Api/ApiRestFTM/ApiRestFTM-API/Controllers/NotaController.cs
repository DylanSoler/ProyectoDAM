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
                return Ok(oEntrenos); //200
            }
        }
        
    }
}
