using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestGeopagos.TorneoTenis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly IJugadoresService _JugadoresService;
        public JugadoresController(IJugadoresService JugadoresService)
        {
            _JugadoresService = JugadoresService;
        }
        // GET: api/<JugadoresController>
        [HttpGet("masculino")]
        public JsonResult ObtenerJugadoresMasculino()
        {
            try
            {
               return new JsonResult(_JugadoresService.SimularListaJugadoresMasculinos());
            }
            catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
            
        }
        [HttpGet("femenino")]
        public JsonResult ObtenerJugadoresFemenino()
        {
            try
            {
                return new JsonResult(_JugadoresService.SimularListaJugadoresFemeninos());
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
            
        }
    }
}
