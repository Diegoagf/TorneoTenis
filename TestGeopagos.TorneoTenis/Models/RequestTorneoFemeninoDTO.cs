using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Models
{
    public class RequestTorneoFemeninoDTO
    {
        [Required]
        [Range(0, 0, ConvertValueInInvariantCulture = true, ErrorMessage = "Debe ser VALOR 0 Para Femenino")]
        public Genero Tipo_Torneo { get; set; }
        [Required]
        public List<JugadorFemeninoDTO> Jugadores { get; set; }
    }
}
