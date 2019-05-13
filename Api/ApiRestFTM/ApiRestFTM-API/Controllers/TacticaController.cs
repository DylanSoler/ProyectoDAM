using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestFTM_DAL.Listados;
using ApiRestFTM_Entidades.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestFTM_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TacticaController : ControllerBase
    {
        // GET Tactica
        [HttpGet]
        public IActionResult Get()
        {
            String accept = Request.Headers["Accept"].ToString();
            clsListadoTacticas oListTactica = new clsListadoTacticas();
            List<clsTactica> listado = new List<clsTactica>();
            
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable
            else
            {
                listado = oListTactica.listadoCompletoTacticasDAL();
                return Ok(listado);
            }
        }
        
    }
}
