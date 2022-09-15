using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestGeopagos.TorneoTenis.Models
{
    public class JugadorDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Range(0,100,ConvertValueInInvariantCulture =true,ErrorMessage ="No se encuentra en el Rango  0-100")]
        public int  Habilidad { get; set; }
        public enum Genero
        {
            Femenino, Masculino
        }

    }
}
