using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestGeopagos.TorneoTenis.Models
{
    public class JugadorFemeninoDTO:JugadorDTO
    {
        [Range(0, 100, ConvertValueInInvariantCulture = true, ErrorMessage = "Debe estar en el rango entre 0-100 segundos")]
        public double TiempoReaccion { get; set; }
    }
}
