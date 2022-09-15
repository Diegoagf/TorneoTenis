using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestGeopagos.TorneoTenis.Models
{
    public class JugadorMasculinoDTO: JugadorDTO
    {
        [Range(0, 100, ConvertValueInInvariantCulture = true, ErrorMessage = "No se encuentra en el Rango  0-100")]
        public int Fuerza { get; set; }
        [Range(0, 100, ConvertValueInInvariantCulture = true, ErrorMessage = "No se encuentra en el Rango  0-100")]
        public int VelocidadDesplazamiento { get; set; }
    }
}
