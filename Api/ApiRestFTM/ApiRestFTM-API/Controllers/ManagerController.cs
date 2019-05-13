﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestFTM_DAL.Manejadoras;
using ApiRestFTM_Entidades.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiRestFTM_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
    
        // GET Manager/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            String accept = Request.Headers["Accept"].ToString();
            clsManejadoraManager manejadora = new clsManejadoraManager();
            clsManager manager = null;
            
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable
            else
            {
                manager = manejadora.managerPorId(id);
                
                if (manager != null)
                    return Ok(manager);
                else
                    return NotFound(id); //No encontrado
            }

        }
        
        //DELETE Manager/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            clsManejadoraManager manejadora = new clsManejadoraManager();
            int ret = manejadora.borrarManagerPorId(id);
            
            if (ret>0)
                return StatusCode(204); //No Content(eliminado con exito)
            else
                return NotFound(id); //404 No encontrado
        }
        
        //POST Manager/
        [HttpPost]
        public IActionResult Post([FromBody] clsManager manager)
        {
            String contentType = Request.Headers["Content-Type"].ToString();
            clsManejadoraManager manejadora = new clsManejadoraManager();
           
            if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type (Formato no legible)
            else
            {
                int ret = manejadora.insertarManager(manager);

                if (ret>0)
                    return StatusCode(400); //Error inesperado
                else
                    return Created(); //Created    
            }
        }
        
        // PUT Manager/
        [HttpPut]
        public IActionResult Put(clsManager manager)
        {
            String contentType = Request.Headers["Content-Type"].ToString();
            clsManejadoraManager manejadora = new clsManejadoraManager();
            
            if (contentType != "application/json" && contentType != "*/*")
                return StatusCode(415); //Unsupported Media Type (Formato no legible)
            else
            {
                int ret = manejadora.actualizarManager(manager);

                if (ret>0)
                    return StatusCode(204); //No Content(eliminado con exito)
                else
                    return NotFound(manager.id); //No encontrado
            }
        }
        
    }
}