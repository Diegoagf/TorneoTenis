using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        int[] generos = new int[] {0,1}; //REVISAR
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

        [HttpGet()]
        public async Task<IActionResult> ObtenerTorneoPorGenero([FromQuery]int genero)
        {
            try
            {
                if (!generos.Contains(genero))
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                    return new JsonResult("Genero debe ser un valor 0 o 1");
                }
                return Ok(await _db.ObtenerTorneoPorGenero(Helpers.Helper.RetornarGenero(genero)));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
        [HttpGet("fecha/{fecha}")]
        public async Task<IActionResult> ObtenerTorneoPorFecha(string fecha)
        {
            try
            {

                

                return Ok(await _db.ObtenerTorneoPorFecha(DateTime.Parse(fecha)));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
        /// <summary>
        /// Realiza un nuevo Torneo Masculino.
        /// </summary>
        /// <returns>Un nuevo Ganador del torneo</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Prueba
        ///     {
        ///       "tipo_Torneo": 1,
        ///       [
        ///             {
        ///             "fuerza": 82,
        ///             "velocidadDesplazamiento": 78,
        ///             "nombre":"Chance Adams",
        ///             "habilidad": 73
        ///             },
        ///             {
        ///             "fuerza": 80,
        ///             "velocidadDesplazamiento": 50,
        ///             "nombre": "Moises Hilll",
        ///             "habilidad": 90
        ///             }
        ///       ]
        ///       
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna el resultado del Torneo</response>
        /// <response code="400">Si hay algun error en el Request</response>
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

        /// <summary>
        /// Realiza un nuevo Torneo Femenino.
        /// </summary>
        /// <returns>Un nuevo Ganador del torneo</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Prueba
        ///     {
        ///       "tipo_Torneo": 1,
        ///       [
        ///             {
        ///             "fuerza": 82,
        ///             "velocidadDesplazamiento": 78,
        ///             "nombre":"Chance Adams",
        ///             "habilidad": 73
        ///             },
        ///             {
        ///             "fuerza": 80,
        ///             "velocidadDesplazamiento": 50,
        ///             "nombre": "Moises Hilll",
        ///             "habilidad": 90
        ///             }
        ///       ]
        ///       
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna el resultado del Torneo Femenino</response>
        /// <response code="400">Si hay algun error en el Request</response>
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
