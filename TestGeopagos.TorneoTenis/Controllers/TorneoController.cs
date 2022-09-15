using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;
using TestGeopagos.TorneoTenis.Repositories;
using TestGeopagos.TorneoTenis.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestGeopagos.TorneoTenis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneoController : ControllerBase
    {
        private ITorneoCollection _db;
        private readonly ISimularTorneoService _simularTorneo;
        public TorneoController(ISimularTorneoService simularTorneo, ITorneoCollection db)
        {
            _simularTorneo = simularTorneo;
            _db = db;
        }


        [HttpGet("obtener-todos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                return Ok(await _db.ObtenerTodos());
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTorneo(string id)
        {
            try
            {
                return Ok(await _db.ObtenerTorneoPorId(id));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpPost("masculino/simular")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SimularTorneoMasculino([FromBody] RequestTorneoMasculinoDTO Request)
        {
            try
            {
                if (Request == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ResponseTorneoDTO response = Helpers.Helper.ArmarRespuesta(_simularTorneo.SimularTorneoMasculino(Request.Jugadores),Request.Tipo_Torneo);
                await _db.InsertarTorneo(response.Torneo_Realizado);
                return Created("Exito", response);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }           
            
        }

        [HttpPost("femenino/simular")]
        public async Task<IActionResult> SimularTorneoFemenino([FromBody] RequestTorneoFemeninoDTO Request)
        {
            try
            {
                if (Request == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ResponseTorneoDTO response = Helpers.Helper.ArmarRespuesta(_simularTorneo.SimularTorneoFemenino(Request.Jugadores), Request.Tipo_Torneo);
                await _db.InsertarTorneo(response.Torneo_Realizado);
                return Created("Exito",response);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
                        
           
        }
    }
}
