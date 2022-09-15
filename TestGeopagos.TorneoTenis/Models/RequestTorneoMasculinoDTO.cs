using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Models
{
    public class RequestTorneoMasculinoDTO
    {
        [Required]
        [Range(1, 1, ConvertValueInInvariantCulture = true, ErrorMessage = "Debe ser VALOR 1 Para Masculino")]
        public Genero Tipo_Torneo { get; set; }
        [Required]
        public List<JugadorMasculinoDTO> Jugadores { get; set; }
    }
}
